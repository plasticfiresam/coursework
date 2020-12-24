﻿using coursework.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace coursework.Reporter
{
    public class Reporter
    {

        public static bool SaveCategoryStatisticsRepors(List<Category> categories, string outputFilePath = @"D:\report-categories-output.docx", string templateFilePath = @"D:\report-categories.doc") {
            var categoriesCount = categories.Count;
            var announcesCount = 0;

            foreach (var category in categories) {
                announcesCount += category.Announcements.Count;
            }
            
            try {
                if (File.Exists(templateFilePath)) {
                    File.Delete(outputFilePath);

                    DocX templateDoc = DocX.Load(templateFilePath);
                    var bookmarks = templateDoc.Bookmarks;
                    templateDoc.Bookmarks["AC"].SetText(announcesCount.ToString());
                    templateDoc.Bookmarks["CC"].SetText(categoriesCount.ToString());
                    foreach (var category in categories) {
                        var categoryRow = templateDoc.Tables[0].InsertRow();
                        categoryRow.Cells[0].InsertParagraph(category.Name);
                        categoryRow.Cells[1].InsertParagraph(category.Announcements.Count.ToString());
                    }
                    templateDoc.SaveAs(outputFilePath);
                }
                return true;
            } catch {
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
            } catch (Exception e)
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
