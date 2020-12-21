using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using coursework.Parser;

namespace coursework.Entities
{
    /// <summary>
    /// Сущность объявления для добавления в БД
    /// </summary>
    public class Announce
    {
        /// <summary>
        /// Внутренний идентификатор объявления
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// Ссылка на детальную страницу
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Идентификатор категории объявления
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Сущность категории объявления
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// GUID продавца, генерируется при парсинге
        /// </summary>
        public string? OwnerGuid { get; set; }
        /// <summary>
        /// Сущность владельца объявления, может быть равен null
        /// </summary>
        public Owner? Owner { get; set; }

        public string Description { get; set; }

        public int VisitorsTotal { get; set; }
        public int VisitorsDaily { get; set; }
        /// <summary>
        /// Парсинг информации с карточки объявления на странице со списком объявлений
        /// </summary>
        /// <param name="announceElement">Элемент с карточкой объявления</param>
        /// <returns>Частично заполненный объект объявления</returns>
        public static Announce ParseAnnounceFromListElement(IElement announceElement)
        {
            /// Выборка из карточки названия
            var announceTitle = announceElement.QuerySelector(DataSelectors.NameSelector).TextContent.Trim();
            /// Выборка ссылки на детальную страницу товара
            var announceUrl = announceElement.QuerySelector<IHtmlAnchorElement>(DataSelectors.NameSelector).Href;
            /// Выборка цены в строковом виде из карточки товара
            var announcePrice = announceElement.QuerySelector(DataSelectors.PriceSelector).TextContent.Replace(" ", "").Replace("₽", "");

            return new Announce()
            {
                Name = announceTitle,
                Price = announcePrice,
                Url = announceUrl,
            };
        }
    }
}
