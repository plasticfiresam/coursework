using coursework.Parser;
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;

namespace coursework
{
    public partial class MainForm : Form
    {
        private ProductParser productsParser = new ProductParser();
        private readonly Data.ApplicationContext db = new Data.ApplicationContext();
        public MainForm()
        {
            InitializeComponent();
        }

        private async void StartParsingButton_Click(object sender, EventArgs e)
        {
            startParsingButton.Enabled = false;
            progressBar.Value = 10;
            var category = await db.Categories.FirstOrDefaultAsync();
            var value = await productsParser.ParseProducts(ProductParser.homePage);
            progressBar.Value = 70;

            foreach (var notebook in value)
            {
                notebook.Category = category;
                if (notebook.Owner != null) {
                    try
                    {
                        notebook.OwnerGuid = notebook.Owner.ProfileGuid;
                        var existingOwner = db.Owners.FirstOrDefault(o => o.ProfileGuid == notebook.OwnerGuid);
                        if (existingOwner == null)
                        {
                            db.Owners.Add(notebook.Owner);
                        }
                        else
                        {
                            notebook.Owner = existingOwner;
                        }
                    } catch
                    {

                    }
                }
            }
            try
            {
                db.Announcements.AddRange(value);
                db.SaveChanges();
            } catch
            {
                MessageBox.Show("Возникла ошибка при сохранении данных");
            }
            progressBar.Value = 100;
            startParsingButton.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notebooksSource.DataSource = db.Announcements.Local.ToBindingList();
            db.Announcements.Include(n => n.Owner).Include(n => n.Category).Load();
            notebooksGridView.DataSource = notebooksSource;

            categoriesSource.DataSource = db.Categories.Local.ToBindingList();
            db.Categories.Load();
            categoriesGridView.DataSource = categoriesSource;

            sellersSource.DataSource = db.Owners.Local.ToBindingList();
            db.Owners.Load();
            sellersGridView.DataSource = sellersSource;
            
            sellersGridView.Columns[1].ReadOnly = true;

            categoriesGridView.Columns[0].ReadOnly = true;

            notebooksGridView.Columns[4].Visible = false;
            notebooksGridView.Columns[6].Visible = false;
            notebooksGridView.Columns[0].ReadOnly = true;
            notebooksGridView.Columns[5].ReadOnly = true;
            notebooksGridView.Columns[7].ReadOnly = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.Dispose();
        }

        private void DataGridViewCellEndEditHandler(object sender, DataGridViewCellEventArgs e)
        {
            db.SaveChanges();
        }

        private void DataGridViewRowDeletionHandler(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            startParsingButton.Enabled = false;
            progressBar.Value = 25;
            Thread.Sleep(500);
            progressBar.Value = 50;
            db.SaveChanges();
            progressBar.Value = 100;
            startParsingButton.Enabled = true;
        }

        private void AddEntityButtonClickHandler(object sender, EventArgs e)
        {
            var currentTabIndex = tabControl1.SelectedIndex;

            switch (currentTabIndex)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        var categoryAdditionForm = new CategoryAdd();
                        categoryAdditionForm.Show();
                        
                        break;
                    }
                case 2:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
