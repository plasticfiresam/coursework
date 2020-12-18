using coursework.Entities;
using System;
using System.Linq;
using System.Windows.Forms;

namespace coursework
{
    public partial class OwnerAddForm : Form
    {
        public Data.ApplicationContext db;
        public OwnerAddForm(Data.ApplicationContext db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void OwnerAddHandler(object sender, EventArgs e)
        {
            var additionResult = OwnerAddition();

            if (additionResult != null)
            {
                Close();
            }
        }

        private Owner OwnerAddition()
        {
            var ownerName = ownerNameTextBox.Text;
            if (ownerName.Length == 0)
            {
                MessageBox.Show("Введите название продавца");
                return null;
            }
            var ownerLink = ownerUrlTextBox.Text;
            if (ownerLink.Length == 0)
            {
                MessageBox.Show("Введите ссылку на страницу продавца");
                return null;
            }

            var owner = new Owner()
            {
                Name = ownerName,
                Url = ownerLink,
                ProfileGuid = Entities.Owner.GenerateSellerGuid(ownerName).ToString(),
            };
            var existingSeller = db.Owners.FirstOrDefault(o => o.ProfileGuid == owner.ProfileGuid);
            if (existingSeller != null)
            {
                MessageBox.Show("Продавец с таким именем уже добавлен в БД");
                return null;
            }
            else
            {
                try
                {
                    db.Owners.Add(owner);
                    db.SaveChanges();

                    MessageBox.Show("Продавец успешно добавлен");
                    return owner;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return null;
                }
            }
        }
    }
}
