using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using coursework.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace coursework.Entities
{
    /// <summary>
    /// Сущность владельца объявления
    /// </summary>
    public class Owner
    {
        /// <summary>
        /// Название владельца объявления
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// GUID продавца в строковом виде
        /// </summary>
        [Key]
        public string ProfileGuid { get; set; }
        /// <summary>
        /// Ссылка на детальную страницу владельца объявления
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Связанные сущности объявлений
        /// </summary>
        public List<Announce> Announces { get; set; } = new List<Announce>();

        public override string ToString()
        {
            return Name;
        }

        public static Guid GenerateSellerGuid(string sellerName)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(sellerName));
            return new Guid(data);
        }
        public static Owner? ParseFromDetailPage(IDocument detailedPage)
        {
            var ownerDataElement = detailedPage.QuerySelector<IHtmlDivElement>(DataSelectors.SellerSelector);
            if (ownerDataElement != null && ownerDataElement.Children.Length > 0)
            {
                /// Парсинг ссылки на детальную страницу продавца
                var sellerLink = (detailedPage.QuerySelector<IHtmlDivElement>(DataSelectors.SellerSelector).Children[0] as IHtmlAnchorElement).Href;
                /// Парсинг названия/имени продавца
                var sellerName = detailedPage.QuerySelector(DataSelectors.SellerSelector).TextContent;

                return new Owner() { 
                    Name = sellerName.Trim(), 
                    Url = sellerLink, 
                    ProfileGuid = GenerateSellerGuid(sellerName).ToString() 
                };
            }
            else
            {
                return null;
            }
        }
    }
}
