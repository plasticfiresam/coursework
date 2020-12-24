using coursework.Parser;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.ObjectModel;
using coursework.Entities;
using System.Collections.Generic;

namespace coursework
{
    public partial class MainForm : Form
    {
        private readonly Data.ApplicationContext db = new Data.ApplicationContext();
        public MainForm()
        {
            InitializeComponent();
            Text = "Парсер";
        }

        private async void StartParsingButton_Click(object sender, EventArgs e)
        {
            startParsingButton.Enabled = false;
            Enabled = false;
            progressBar.Value = 10;

            var categories = db.Categories.ToList();
            if (categories.Count == 0)
            {
                MessageBox.Show("Добавьте категории для парсинга");
                Enabled = true;
                progressBar.Value = 100;
                startParsingButton.Enabled = true;
            }
            else
            {

                var announces = await new ProductParser().ParseAnnouncesFromList(categories);
                progressBar.Value = 70;
                if (announces.Count > 0)
                {
                    var savingSucceeded = AddParsingResultsToDatabase(announces);
                    if (savingSucceeded)
                    {
                        MessageBox.Show("Данные успешно сохранены");
                    }
                    else
                    {
                        MessageBox.Show("Возникла ошибка при сохранении данных");
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось считать данные");
                }

                Enabled = true;
                progressBar.Value = 100;
                startParsingButton.Enabled = true;
            }

        }

        private bool AddParsingResultsToDatabase(Collection<Announce> announcesToAdd)
        {
            /// Берем для товаров заранее добавленную категорию - Ноутубки, из БД и отбираем её по слагу
            foreach (var announce in announcesToAdd)
            {
                if (announce.Owner != null)
                {
                    announce.OwnerGuid = announce.Owner.ProfileGuid;

                    /// Проверяем на наличие владельца объявлений в БД, если есть - берем для связки запись оттуда
                    var existingOwner = db.Owners.FirstOrDefault(o => o.ProfileGuid == announce.OwnerGuid);
                    /// Если владельца нет ещё в базе
                    if (existingOwner == null)
                    {
                        /// То сохраняем его в БД
                        db.Owners.Add(announce.Owner);
                        db.SaveChanges();
                    }
                    else
                    {
                        /// Если уже есть владелец, присваиваем его запись в БД навигационному свойству объявления
                        announce.Owner = existingOwner;
                    }
                }
            }
            try
            {
                /// После того как прошли по всем записям и разобрались со связанными сущностями - добавляем пачкой объявления в БД
                db.Announces.AddRange(announcesToAdd);
                /// Сохраняем данные в БД
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGridViews();
        }

        /// <summary>
        /// Инициализация таблиц и привязка к ним данных из БД в отдельном методе
        /// </summary>
        private void InitializeGridViews()
        {
            sellersSource.DataSource = db.Owners.Local.ToBindingList();
            db.Owners.Load();
            ownersGridView.DataSource = sellersSource;

            ownersGridView.Columns[0].HeaderText = "Название";
            ownersGridView.Columns[1].Visible = false;
            ownersGridView.Columns[1].HeaderText = "GUID";
            ownersGridView.Columns[2].HeaderText = "Ссылка на страницу";
            ownersGridView.AllowUserToAddRows = false;

            categoriesSource.DataSource = db.Categories.Local.ToBindingList();
            db.Categories.Load();
            categoriesGridView.DataSource = categoriesSource;

            categoriesGridView.Columns[0].ReadOnly = true;
            categoriesGridView.Columns[0].Visible = false;
            categoriesGridView.Columns[1].HeaderText = "Название";
            categoriesGridView.Columns[2].ReadOnly = true;
            categoriesGridView.Columns[2].HeaderText = "Маркер";
            categoriesGridView.Columns[3].HeaderText = "Может быть удалена";
            categoriesGridView.AllowUserToAddRows = false;

            notebooksSource.DataSource = db.Announces.Local.ToBindingList();
            /// Используем Include чтобы подтянуть и сущность категории и сущность продавца в модель
            db.Announces.Include(n => n.Owner).Include(n => n.Category).Load();
            announcesGridView.DataSource = notebooksSource;


            announcesGridView.Columns[0].HeaderText = "Идентификатор";
            announcesGridView.Columns[1].HeaderText = "Название";
            announcesGridView.Columns[2].HeaderText = "Цена";
            announcesGridView.Columns[3].HeaderText = "Ссылка";
            announcesGridView.Columns[4].HeaderText = "ID категории";
            announcesGridView.Columns[5].HeaderText = "Категория";
            announcesGridView.Columns[6].HeaderText = "GUID продавца";
            announcesGridView.Columns[7].HeaderText = "Продавец";
            announcesGridView.Columns[0].Visible = false;
            announcesGridView.Columns[4].Visible = false;
            announcesGridView.Columns[6].Visible = false;
            announcesGridView.Columns[8].Visible = false;
            announcesGridView.Columns[9].Visible = false;
            announcesGridView.Columns[10].Visible = false;
            announcesGridView.Columns[0].ReadOnly = true;
            announcesGridView.Columns[5].ReadOnly = true;
            announcesGridView.Columns[7].ReadOnly = true;
            announcesGridView.AllowUserToAddRows = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Dispose();
        }

        private void DataGridViewCellEndEditHandler(object sender, DataGridViewCellEventArgs e)
        {
            db.SaveChanges();
        }

        /// <summary>
        /// Обработчик клика кнопки добавления сущности
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Параметры события</param>
        private void AddEntityButtonClickHandler(object sender, EventArgs e)
        {
            switch (tabsWithDataGridViews.SelectedIndex)
            {
                case 0:
                    {
                        AddAnnounce();
                        break;
                    }
                case 1:
                    {
                        AddCategory();
                        break;
                    }
                case 2:
                    {
                        AddOwner();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Создание и отображение формы добавления владельца объявления
        /// </summary>
        private void AddOwner()
        {
            Enabled = false;
            var ownerAdditionForm = new OwnerAddForm(db);
            ownerAdditionForm.FormClosed += FormClosingHandler;
            ownerAdditionForm.Show();
        }

        /// <summary>
        /// Создание и отображение формы добавления объявления
        /// </summary>
        private void AddAnnounce()
        {
            Enabled = false;
            var announceAdditionForm = new AnnounceAddForm(db);
            announceAdditionForm.FormClosed += FormClosingHandler;
            announceAdditionForm.Show();
        }

        /// <summary>
        /// Создание и отображение формы добавления категории
        /// </summary>
        private void AddCategory()
        {
            Enabled = false;
            var categoryAdditionForm = new CategoryAddForm(db);
            categoryAdditionForm.FormClosed += FormClosingHandler;
            categoryAdditionForm.Show();
        }

        /// <summary>
        /// Обработчик события закрытия форм изменений данных, после закрытия обновляет вывод данных из БД в таблицы
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Параметры события</param>
        private void FormClosingHandler(object sender, FormClosedEventArgs e)
        {
            db.Owners.Load();
            db.Announces.Load();
            db.Categories.Load();
            Enabled = true;
        }

        /// <summary>
        /// Обработчик клика кнопки удаления сущности
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Параметры события</param>
        private void RemoveEntityButtonClickHandler(object sender, EventArgs e)
        {
            switch (tabsWithDataGridViews.SelectedIndex)
            {
                case 0:
                    {
                        DeleteAnnounce();
                        break;
                    }
                case 1:
                    {
                        DeleteCategory();
                        break;
                    }
                case 2:
                    {
                        DeleteOwner();
                        break;
                    }
            }
        }

        /// <summary>
        /// Удаление продавца
        /// </summary>
        private void DeleteOwner()
        {
            var dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    {
                        Enabled = false;
                        var selectedOwnersFromGridView = ownersGridView.SelectedRows;
                        if (selectedOwnersFromGridView.Count == 0)
                        {
                            Enabled = true;
                            MessageBox.Show("Выберите продавца для удаления");
                        }
                        else
                        {
                            var selectedOwner = selectedOwnersFromGridView[0].DataBoundItem as Entities.Owner;
                            try
                            {
                                db.Owners.Remove(selectedOwner);
                                db.SaveChanges();
                                db.Owners.Load();
                                Enabled = true;
                                MessageBox.Show("Удаление завершено, данные обновлены");
                            }
                            catch
                            {
                                Enabled = true;
                                MessageBox.Show("Возникла ошибка при удалении");
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
        /// <summary>
        /// Удаление категории
        /// </summary>
        private void DeleteCategory()
        {
            var dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    {
                        Enabled = false;
                        var selectedCategoriesFromGridView = categoriesGridView.SelectedRows;
                        if (selectedCategoriesFromGridView.Count == 0)
                        {
                            Enabled = true;
                            MessageBox.Show("Выберите продавца для удаления");
                        }
                        else
                        {
                            var selectedCategory = selectedCategoriesFromGridView[0].DataBoundItem as Entities.Category;
                            try
                            {
                                db.Categories.Remove(selectedCategory);
                                db.SaveChanges();
                                db.Categories.Load();
                                Enabled = true;
                                MessageBox.Show("Удаление завершено, данные обновлены");
                            }
                            catch
                            {
                                Enabled = true;
                                MessageBox.Show("Возникла ошибка при удалении");
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }

        private void DeleteAnnounce()
        {
            var dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление записи", MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    {
                        Enabled = false;
                        var selectedAnnouncesFromGridView = announcesGridView.SelectedRows;
                        if (selectedAnnouncesFromGridView.Count == 0)
                        {
                            Enabled = true;
                            MessageBox.Show("Выберите объявление для удаления");
                        }
                        else
                        {
                            var selectedAnnounce = selectedAnnouncesFromGridView[0].DataBoundItem as Announce;
                            try
                            {
                                db.Announces.Remove(selectedAnnounce);
                                db.SaveChanges();
                                db.Announces.Load();
                                Enabled = true;
                                MessageBox.Show("Удаление завершено, данные обновлены");
                            }
                            catch
                            {
                                Enabled = true;
                                MessageBox.Show("Возникла ошибка при удалении");
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void MenuStripActionClickHandler(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag.ToString() == "wipe")
            {
                var dialogResult = MessageBox.Show("Очистить базу данных?", "Все данные и результаты поиска будут удалены", MessageBoxButtons.OKCancel);
                switch (dialogResult)
                {
                    case DialogResult.OK:
                        {
                            db.Owners.RemoveRange(db.Owners);
                            db.Announces.RemoveRange(db.Announces);
                            db.SaveChanges();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void SaveReportButtonClickHandler(object sender, EventArgs e)
        {
            var categories = db.Categories.ToList();
            var res = Reporter.Reporter.SaveCategoryStatisticsRepors(categories);
            var i = 5;
            // var announces = db.Announces.ToList();
            // var res = Reporter.Reporter.SaveReports(announces);
            // var i = 5;
        }
    }
}
