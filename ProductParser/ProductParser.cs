using AngleSharp;
using AngleSharp.Dom;
using coursework.Entities;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using System.Security.Cryptography;
using System.Text;

namespace coursework
{
    public class ProductParser
    {
        private static IConfiguration configuration = Configuration.Default.WithDefaultLoader();
        
        private static IBrowsingContext context = BrowsingContext.New(configuration);

        public static string homePage = "https://www.avito.ru/tomsk/noutbuki";

        public async Task<Collection<Announcement>> ParseProducts(string url)
        {
            IDocument document = await context.OpenAsync(url);
            var elements = document.QuerySelectorAll(DataSelectors.ProductSelector).ToCollection<IElement>();
            var lessElements = new Collection<IElement>() { 
                elements[0], 
                elements[1], 
                elements[2],
                elements[3],
                elements[4],
                elements[5],
                elements[6]
            };
            
            
            Collection<Announcement> notebooks = new Collection<Announcement>();

            foreach (var element in lessElements)
            {
                var notebook = ParseNotebookData(element);
                var sellerData = await ParseDetailedData(notebook.Url);
                notebook.Owner = sellerData.Owner;
                notebook.DailyVisitorsDynamic = sellerData.AnnounceVisitorsData.DailyGrowth;
                notebook.TotalVisitors = sellerData.AnnounceVisitorsData.Total;
                notebook.Description = sellerData.Description;
                notebooks.Add(notebook);
            }

                    return notebooks;
        }
        private Announcement ParseNotebookData(IElement element)
        {
            var name = element.QuerySelector(DataSelectors.NameSelector).TextContent;
            var link = element.QuerySelector<IHtmlAnchorElement>(DataSelectors.NameSelector).Href;
            var linkParts = link.Split("_");
            var announcementNumber = linkParts[linkParts.Length - 1];
            var price = element.QuerySelector(DataSelectors.PriceSelector).TextContent;
            return new Announcement() { 
                Name = name,
                Price = price,
                Url = link,
                AnnouncementNumber = announcementNumber,
            };
        }
        private async Task<DetailedAnnounceData> ParseDetailedData(string url)
        {
            var announcementDetailedData = new DetailedAnnounceData();
            IDocument detailPage = await context.OpenAsync(url);
            var description = detailPage.QuerySelector<IHtmlDivElement>(DataSelectors.DescriptionSelector);
            announcementDetailedData.Description = description.TextContent.Trim();
            var visitorsBloc = detailPage.QuerySelector<IHtmlDivElement>(DataSelectors.VisitorsSelector);
            if (visitorsBloc != null)
            {
                var visitorsString = visitorsBloc.TextContent.Trim();
                var totalVisitorsNumber = int.Parse(visitorsString.Split(" ")[0]);
                var dynamicsValue = visitorsString.Split(" ")[1].Replace("(", "").Replace(")", "");
                var isPositive = dynamicsValue.Contains("+");
                var dynamicsNumber = int.Parse(dynamicsValue.Replace("+", "").Replace("-", ""));
                announcementDetailedData.AnnounceVisitorsData = new AnnounceVisitorsData()
                {
                    Total = totalVisitorsNumber,
                    DailyGrowth = dynamicsNumber,
                    IsPositive = isPositive
                };
            }

            var sellerDiv = detailPage.QuerySelector<IHtmlDivElement>(DataSelectors.SellerSelector);
            if (sellerDiv != null && sellerDiv.Children.Length > 0)
            {
                var sellerLink = (detailPage.QuerySelector<IHtmlDivElement>(DataSelectors.SellerSelector).Children[0] as IHtmlAnchorElement).Href;
                var sellerName = detailPage.QuerySelector(DataSelectors.SellerSelector).TextContent;
                announcementDetailedData.Owner = new Owner() { 
                    Name = sellerName.Trim(), 
                    Url = sellerLink, 
                    ProfileGuid = GenerateSellerGuid(sellerName).ToString() 
                };
            } else
            {
                return null;
            }
            return announcementDetailedData;
        }

        private Guid GenerateSellerGuid(string sellerName)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(sellerName));
            return new Guid(data);
        }
    }

    
}
