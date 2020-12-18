using System;
using System.Linq;
using System.Windows.Forms;

namespace coursework
{
    public partial class CategoryAddForm : Form
    {
        public Data.ApplicationContext db;
        public CategoryAddForm(Data.ApplicationContext db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            var additionResult = AddCategory();
            if (additionResult != null)
            {
                Close();
            }
        }

        private Entities.Category AddCategory()
        {
            var categoryName = categoryNameTextBox.Text;
            if (categoryName.Length == 0)
            {
                MessageBox.Show("Название категории должно быть заполнено");
                return null;
            }
            var categorySlug = categorySlugTextBox.Text;
            if (categorySlug.Length == 0)
            {
                MessageBox.Show("Маркер должен быть заполнен");
                return null;
            }
            var category = new Entities.Category()
            {
                Name = categoryName,
                Slug = categorySlug,
            };

            var categoryWithSameSlug = db.Categories.FirstOrDefault(c => c.Slug == categorySlug);
            if (categoryWithSameSlug == null)
            {
                var cat = db.Categories.Add(category);
                db.SaveChanges();
                return cat.Entity;
            }
            else
            {
                MessageBox.Show("Категория с таким маркером уже существует");
                return null;
            }
        }
    }
}
