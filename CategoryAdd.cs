using coursework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace coursework
{
    public partial class CategoryAdd : Form
    {
        private Data.ApplicationContext db = new Data.ApplicationContext();
        public CategoryAdd()
        {
            InitializeComponent();
        }

        private async void SaveCategoryButtonClick(object sender, EventArgs e)
        {
            saveButton.Enabled = false;
            var categoryName = textBox1.Text;
            if (categoryName.Length == 0)
            {
                saveButton.Enabled = true;

                MessageBox.Show("Название категории не должно быть пустой строкой");
            }
            var categoryCode = textBox2.Text;
            if (categoryCode.Length == 0)
            {
                saveButton.Enabled = true;
                MessageBox.Show("Код категории не должен быть пустой строкой");
            }
            if (categoryCode.Length > 0 && categoryName.Length > 0)
            {
                saveButton.Enabled = false;
                var newCategory = new Category() { 
                    Name = categoryName, Code = categoryCode
                };
                var existingCategory = db.Categories.FirstOrDefault(c => c.Name == categoryName || c.Code == categoryCode);
                if (existingCategory == null)
                {
                    try
                    {

                        await db.Categories.AddAsync(newCategory);

                        await db.SaveChangesAsync();

                        MessageBox.Show($"Категория \"${categoryName}\" добавлена");
                        saveButton.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Произошла ошибка при добавлении категории");
                        saveButton.Enabled = true;
                    }
                } else
                {
                    MessageBox.Show("Категория с таким названием или кодом уже существует");
                    saveButton.Enabled = true;
                }
                
            }
        }
    }
}
