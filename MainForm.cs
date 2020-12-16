using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using coursework.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Drawing.Chart;
using coursework.Reporter;

namespace coursework
{
    public partial class MainForm : Form
    {
        private ProductParser productsParser = new ProductParser();
        private readonly Data.ApplicationContext db = new Data.ApplicationContext();
        int selectedRowIndex;
        public MainForm()
        {
            InitializeComponent();
        }

        private async void StartParsingButton_Click(object sender, EventArgs e)
        {
            var parsingSucceed = await StartParsing();
        }

        private async Task<bool> StartParsing()
        {
            startParsingButton.Enabled = false;
            announcementsGrid.Enabled = false;
            progressBar.Value = 10;
            var category = await db.Categories.FirstOrDefaultAsync();
            var value = await productsParser.ParseProducts(ProductParser.homePage);
            progressBar.Value = 70;

            foreach (var notebook in value)
            {
                notebook.Category = category;
                if (notebook.Owner != null)
                {
                    notebook.OwnerGuid = notebook.Owner.ProfileGuid;
                    var existingOwner = db.Owners.FirstOrDefault(o => o.ProfileGuid == notebook.OwnerGuid);
                    if (existingOwner == null)
                    {
                        db.Owners.Add(notebook.Owner);
                        db.SaveChanges();
                    }
                    else
                    {
                        notebook.Owner = existingOwner;
                    }
                }
            }
            try
            {
                db.Announcements.AddRange(value);
                db.SaveChanges();
                progressBar.Value = 100;
                startParsingButton.Enabled = true;
                announcementsGrid.Enabled = true;
                return true;
            }
            catch (Exception e)
            {
                progressBar.Value = 100;
                startParsingButton.Enabled = true;
                MessageBox.Show(e.Message);
                announcementsGrid.Enabled = true;
                return false;
            }
            
        }

        private void DataBindingInitial(object sender, EventArgs e)
        {
            notebooksSource.DataSource = db.Announcements.Local.ToBindingList();
            db.Announcements.Include(n => n.Owner).Include(n => n.Category).Load();
            announcementsGrid.DataSource = notebooksSource;

            announcementsGrid.Columns[0].Visible = false;
            announcementsGrid.Columns[3].Visible = false;
            announcementsGrid.Columns[5].Visible = false;
            announcementsGrid.Columns[6].Visible = false;
            announcementsGrid.Columns[7].Visible = false;
            announcementsGrid.Columns[8].Visible = false;
            announcementsGrid.Columns[9].Visible = false;
            announcementsGrid.Columns[10].Visible = false;
            announcementsGrid.Columns[11].Visible = false;

            //categoriesSource.DataSource = db.Categories.Local.ToBindingList();
            //db.Categories.Load();
            //categoriesGridView.DataSource = categoriesSource;

            //sellersSource.DataSource = db.Owners.Local.ToBindingList();
            //db.Owners.Load();
            //sellersGridView.DataSource = sellersSource;

            //sellersGridView.Columns[1].ReadOnly = true;

            //categoriesGridView.Columns[0].ReadOnly = true;

            //notebooksGridView.Columns[4].Visible = false;
            //notebooksGridView.Columns[6].Visible = false;
            //notebooksGridView.Columns[0].ReadOnly = true;
            //notebooksGridView.Columns[5].ReadOnly = true;
            //notebooksGridView.Columns[7].ReadOnly = true;
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
            //startParsingButton.Enabled = false;
            //progressBar.Value = 25;
            //Thread.Sleep(500);
            //progressBar.Value = 50;
            //db.SaveChanges();
            //progressBar.Value = 100;
            //startParsingButton.Enabled = true;
        }

        private void announcementsGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            createReportButton.Visible = true;
            createReportButton.Enabled = true;
            selectedRowIndex = e.RowIndex;
        }

        private void createReportButtonClick(object sender, EventArgs e)
        {
            var selectedAnnouncement = announcementsGrid.Rows[selectedRowIndex].DataBoundItem as Announcement;
            var formatter = new WordSaver();

            var result = formatter.SaveToFile(selectedAnnouncement);
            if (result)
            {
                MessageBox.Show("Отчет сохранён");
            } else
            {
                MessageBox.Show("Ошибка сохранения отчёта, шаблон не найден");
            }
        }

        private void announcementsGrid_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// общий отчет

            //using var workbook = new XLWorkbook();
            //var worksheet = workbook.Worksheets.Add("Отчет");
            //for (int i = 1; i <= announcements.Count; i++)
            //{
            //    var announcement = announcements[i - 1];
            //    worksheet.Cell(1, i).SetValue(announcement.TotalVisitors);
            //    worksheet.Cell(2, i).SetValue(announcement.AnnouncementNumber);
            //}
            //workbook.SaveAs(@"D:\WordTemplates\report.xlsx");
            var announcements = db.Announcements.OrderBy(a => a.TotalVisitors).ToList();

            var excelSaver = new ExcelSaver();

            excelSaver.SaveAnnouncementsVisitorsData(announcements);
        }
    }
}
