using coursework.Entities;
using Xceed.Words.NET;
using System.IO;

namespace coursework
{
    public class WordSaver
    {
        public const string DefaultTemplatePlacement = @"C:\report.doc";

        public bool SaveToFile(Announcement announcement, string path = DefaultTemplatePlacement)
        {
            DocX doc;
            try
            {
                if (File.Exists(path))
                {
                    doc = DocX.Load(path);
                    var bookmarks = doc.Bookmarks;
                    bookmarks["announceName"].SetText(announcement.Name);
                    bookmarks["description"].SetText(announcement.Description);
                    bookmarks["announcePrice"].SetText(announcement.Price);
                    bookmarks["announcePriceText"].SetText(announcement.Price);
                    bookmarks["ownerName"].SetText(announcement.Owner.Name);
                    bookmarks["visitorsTotal"].SetText(announcement.TotalVisitors.ToString());
                    bookmarks["visitorsTotalText"].SetText(announcement.TotalVisitors.ToString());
                    bookmarks["visitorsDynamics"].SetText(announcement.DailyVisitorsDynamic.ToString());
                    doc.SaveAs(@"C:\report_word.doc");
                    return true;
                }
                else
                {
                    return false;
                }
            } catch
            {
                return false;
            }


        }
    }
}
