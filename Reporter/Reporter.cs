using coursework.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.IO;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace coursework.Reporter
{
    public class Reporter
    {

        public static bool SaveCategoryStatisticsRepors(List<Category> categories, string outputFilePath = @"D:\report-categories-output.docx", string templateFilePath = @"D:\report-categories.doc")
        {
            var categoriesCount = categories.Count;
            var announcesCount = 0;

            foreach (var category in categories)
            {
                announcesCount += category.Announcements.Count;
            }

            try
            {
                if (File.Exists(templateFilePath))
                {
                    File.Delete(outputFilePath);
                    File.Delete(@"D:\report-categories-output.xlsx");

                    DocX templateDoc = DocX.Load(templateFilePath);
                    var bookmarks = templateDoc.Bookmarks;
                    templateDoc.Bookmarks["AC"].SetText(announcesCount.ToString());
                    templateDoc.Bookmarks["CC"].SetText(categoriesCount.ToString());
                    foreach (var category in categories)
                    {
                        var categoryRow = templateDoc.Tables[0].InsertRow();
                        categoryRow.Cells[0].InsertParagraph(category.Name);
                        categoryRow.Cells[1].InsertParagraph(category.Announcements.Count.ToString());
                    }
                    templateDoc.SaveAs(outputFilePath);

                    string tableRange = $"A1:B{categoriesCount}";
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Categories");
                    ExcelTable table = sheet.Tables.Add(sheet.Cells[tableRange], "Categories");
                    table.Columns[0].Name = "Категория";
                    table.Columns[1].Name = "Количество объявлений";

                    int firstDataRowIndex = 2;

                    foreach (var category in categories)
                    {
                        sheet.Cells[$"A{firstDataRowIndex}"].Value = category.Name;
                        sheet.Cells[$"B{firstDataRowIndex}"].Value = category.Announcements.Count;
                        firstDataRowIndex++;
                    }

                    OfficeOpenXml.Drawing.Chart.ExcelChart chart = sheet.Drawings.AddChart("Категории и объявления", eChartType.ColumnClustered);
                    chart.XAxis.Title.Text = "Категория";
                    chart.XAxis.Title.Font.Size = 10;
                    chart.YAxis.Title.Text = "Объявления";
                    chart.YAxis.Title.Font.Size = 10;
                    chart.SetSize(500, 300);
                    chart.SetPosition(0, 0, 4, 0);

                    string xValuesRange = $"A2:A{categoriesCount + 1}";
                    chart.Series.Add($"A2:A{categoriesCount + 1}", xValuesRange);
                    chart.Series.Add($"B2:B{categoriesCount + 1}", xValuesRange);
                    chart.Legend.Position = eLegendPosition.Right;

                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();
                    package.SaveAs(new FileInfo(@"D:\report-categories-output.xlsx"));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool SaveReports(List<Announce> announces, string outputFilePath = @"D:\report-output.docx", string templateFilePath = @"D:\report.doc")
        {
            try
            {
                if (File.Exists(templateFilePath))
                {
                    File.Delete(outputFilePath);

                    DocX templateDoc = DocX.Load(templateFilePath);

                    DocX newDocument = DocX.Create(outputFilePath);
                    var templateTable = templateDoc.Tables[0];
                    templateTable.Design = TableDesign.TableGrid;
                    foreach (var announce in announces)
                    {
                        var tempDoc = DocX.Create(@"D:\report-temp.docx");
                        tempDoc.InsertParagraph().InsertTableAfterSelf(templateTable);
                        FillAnnounceInTable(tempDoc, announce);
                        tempDoc.Save();
                        var readyTable = tempDoc.Tables[0];
                        readyTable.Design = TableDesign.TableGrid;
                        readyTable.Rows[0].Cells[0].Paragraphs[0].FontSize(28);
                        readyTable.Rows[1].Cells[0].Paragraphs[0].Bold().FontSize(11);
                        readyTable.Rows[2].Cells[0].Paragraphs[0].Bold().FontSize(11);
                        readyTable.Rows[3].Cells[0].Paragraphs[0].Bold().FontSize(11);
                        newDocument.InsertParagraph().InsertTableAfterSelf(readyTable);
                        File.Delete(@"D:\report-temp.docx");
                    }

                    newDocument.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static void FillAnnounceInTable(DocX document, Announce announce)
        {
            var bookmarks = document.Bookmarks;
            bookmarks["announceName"].SetText(announce.Name);
            bookmarks["description"].SetText(announce.Description);
            bookmarks["announcePrice"].SetText(announce.Price);
            bookmarks["announcePriceText"].SetText(announce.Price);
            bookmarks["ownerName"].SetText(announce.Owner.Name);
            bookmarks["visitorsTotal"].SetText(announce.VisitorsTotal.ToString());
            bookmarks["visitorsTotalText"].SetText(announce.VisitorsTotal.ToString());
            bookmarks["visitorsDynamics"].SetText(announce.VisitorsDaily.ToString());
        }

    }
}
