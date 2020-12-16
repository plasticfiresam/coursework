using coursework.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Table;
using System.Collections.Generic;

namespace coursework.Reporter
{
    public class ExcelSaver
    {
        public void SaveAnnouncementsVisitorsData(List<Announcement> announcements, string savePath = @"C:\report_with_chart.xlsx")
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string tableRange = $"A1:C{announcements.Count + 1}";
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Объявления");
            ExcelTable table = sheet.Tables.Add(sheet.Cells[tableRange], "Объявления");
            table.Columns[0].Name = "Посещений";
            table.Columns[1].Name = "Номер объявления";

            for (int i = 2; i <= announcements.Count + 1; i++)
            {
                var announcement = announcements[i - 2];
                sheet.Cells[$"A{i}"].Value = announcement.TotalVisitors;
                sheet.Cells[$"B{i}"].Value = announcement.AnnouncementNumber;
            }

            //create chart
            ExcelChart chart = sheet.Drawings.AddChart("example", eChartType.CylinderCol);
            chart.XAxis.Title.Text = "Номер объявления";
            chart.XAxis.Title.Font.Size = 10;
            chart.YAxis.Title.Text = "Посещения";
            chart.YAxis.Title.Font.Size = 10;
            chart.SetSize(500, 300);
            chart.SetPosition(0, 0, 4, 0);

            //add chart series
            string xValuesRange = $"B1:B{announcements.Count + 1}";
            chart.Series.Add($"A1:A{announcements.Count + 1}", xValuesRange);
            chart.Legend.Position = eLegendPosition.Right;

            //automatically adjust columns width to text
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

            package.SaveAs(new System.IO.FileInfo(savePath));

        }
    }
}
