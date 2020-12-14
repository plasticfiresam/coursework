using AngleSharp;
using AngleSharp.Dom;
using coursework.Entities;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

namespace coursework.Parser
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
                var sellerData = await ParseSellerData(notebook.Url);
                notebook.Owner = sellerData;
                notebooks.Add(notebook);
            }

            return notebooks;
        }
        private Announcement ParseNotebookData(IElement element)
        {
            var name = element.QuerySelector(DataSelectors.NameSelector).TextContent;
            var link = element.QuerySelector<IHtmlAnchorElement>(DataSelectors.NameSelector).Href;
            var price = element.QuerySelector(DataSelectors.PriceSelector).TextContent;
            return new Announcement() { 
                Name = name,
                Price = price,
                Url = link,
            };
        }
        private async Task<Owner> ParseSellerData(string url)
        {
            IDocument detailPage = await context.OpenAsync(url);
            var sellerDiv = detailPage.QuerySelector<IHtmlDivElement>(DataSelectors.SellerSelector);
            if (sellerDiv != null && sellerDiv.Children.Length > 0)
            {
                var sellerLink = (detailPage.QuerySelector<IHtmlDivElement>(DataSelectors.SellerSelector).Children[0] as IHtmlAnchorElement).Href;
                var sellerName = detailPage.QuerySelector(DataSelectors.SellerSelector).TextContent;
            return new Owner() { Name = sellerName.Trim(), Url = sellerLink, ProfileGuid = GenerateSellerGuid(sellerName).ToString() };
            } else
            {
                return null;
            }
        }

        private Guid GenerateSellerGuid(string sellerName)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(sellerName));
            return new Guid(data);
        }
    }

    
}
