using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace coursework
{
    public partial class AnnounceAddForm : Form
    {
        public Data.ApplicationContext db;

        public AnnounceAddForm(Data.ApplicationContext db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void AdditionButtonClickHandler(object sender, EventArgs e)
        {
            var addedAnnounce = AddAnnounce();
            if (addedAnnounce != null)
            {
                Close();
            }
        }

        private Entities.Announce AddAnnounce()
        {
            var announceName = announceNameTextBox.Text;
            if (announceName.Length == 0)
            {
                MessageBox.Show(@"Поле ""Название"" не должно быть пустым");
                return null;
            }
            var announceLink = announceLinkTextBox.Text;
            if (announceLink.Length == 0)
            {
                MessageBox.Show(@"Поле ""Ссылка"" не должно быть пустым");
                return null;
            }
            var announcePrice = announcePriceTextBox.Text;
            if (announcePrice.Length == 0)
            {
                MessageBox.Show(@"Поле ""Цена"" не должно быть пустым");
                return null;
            }
            var announceCategory = categoriesComboBox.SelectedItem as Entities.Category;
            if (announceCategory == null)
            {
                MessageBox.Show("Выберите категорию объявления");
                return null;
            }
            var announceOwner = ownersComboBox.SelectedItem as Entities.Owner;
            if (announceOwner == null)
            {
                MessageBox.Show("Выберите продавца объявления");
                return null;
            }
            var announce = new Entities.Announce() {
                Name = announceName,
                Url = announceLink,
                Price = announcePrice,
                Category = announceCategory,
                Owner = announceOwner,
            };

            var createdAnnounce = db.Announces.Add(announce);
            db.SaveChanges();
            return createdAnnounce.Entity;
        }

        private void AnnounceAddForm_Load(object sender, EventArgs e)
        {
            ownersSource.DataSource = db.Owners.Local.ToBindingList();
            db.Owners.Load();
            ownersComboBox.DataSource = ownersSource;

            categoriesSource.DataSource = db.Categories.Local.ToBindingList();
            db.Categories.Load();
            categoriesComboBox.DataSource = categoriesSource;
        }
    }
}
