using AngleSharp;
using AngleSharp.Dom;
using coursework.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using coursework.Models;
using System.Threading;

namespace coursework.Parser
{
    /// <summary>
    /// Главный класс парсера объявлений
    /// </summary>
    public class ProductParser
    {
        private static IConfiguration configuration = Configuration.Default.WithDefaultLoader();

        private static IBrowsingContext context = BrowsingContext.New(configuration);
        /// <summary>
        /// Парсинг объявлений по указанной в аргументах ссылке
        /// </summary>
        /// <param name="url">Ссылка на страницу, на которой будет производиться парсинг объявлений из списка</param>
        /// <param name="recordsPerPage">Ограничение количества записей, о которых будет собрана детальная информация за одну страницу</param>
        /// <param name="maxPages">Ограничение количества страниц, которые будут обработаны</param>
        /// <param name="limitDetailedParsing">Ограничение количества записей, о которых будет собрана детальная информация</param>
        /// <param name="enableTimeout">Использовать ли тайм-аут при парсинге детальных страниц объявлений</param>
        /// <param name="timeoutDuration">Продолжительность тайм-аута, в миллисекундах</param>
        /// <returns>Список объявлений</returns>
        public async Task<Collection<Announce>> ParseAnnouncesFromList(string url, int recordsPerPage = 5, int maxPages = 2, int limitDetailedParsing = 5, bool enableTimeout = true, int timeoutDuration = 2000)
        {
            Collection<Announce> parsedAnnounces = new Collection<Announce>();

            for (int pageNumber = 1; pageNumber < maxPages + 1; pageNumber++)
            {
                /// Загружаем страницу, на которой будет происходить парсинг
                IDocument document = await ParsePage(url + $"?p={pageNumber}");
                if (document != null)
                {
                    /// Выбираем все элементы со страницы, которые подходят по селектору под элемент с данными об объявлении
                    var announceElements = document.QuerySelectorAll(DataSelectors.AnnounceSelector).ToCollection<IElement>();
                    /// Если не нашлось объявлений на странице - возвращается пустая коллекция
                    if (announceElements.Length == 0)
                    {
                        return new Collection<Announce>();
                    }
                    /// Итоговый список объявлений для детального парсинга
                    var announcesToParseDetailed = new Collection<IElement>();
                    for (int i = 0; i < limitDetailedParsing; i++)
                    {
                        announcesToParseDetailed.Add(announceElements[i]);
                    }

                    foreach (var element in announcesToParseDetailed)
                    {
                        var announceData = Announce.ParseAnnounceFromListElement(element);
                        if (enableTimeout)
                        {
                            /// Для уменьшения шанса блокировки используется таймаут
                            Thread.Sleep(timeoutDuration);
                        }
                        var detailedPage = await ParsePage(announceData.Url);
                        var announceDetails = AnnounceDetailsInfo.ParseFromDetailedPage(detailedPage);
                        announceData.Owner = announceDetails.OwnerData;
                        announceData.Description = announceDetails.Description;
                        announceData.VisitorsTotal = announceDetails.VisitorsTotal;
                        announceData.VisitorsDaily = announceDetails.VisitorsDaily;
                        parsedAnnounces.Add(announceData);
                    }

                }
            }
            return parsedAnnounces;

        }

        /// <summary>
        /// Парсинг отдельной страницы
        /// </summary>
        /// <param name="url">Ссылка на страницу для парсинга</param>
        /// <returns>Объект документа страницы</returns>
        private async Task<IDocument> ParsePage(string url)
        {
            try
            {
                var document = await context.OpenAsync(url);

                return document;
            }
            catch
            {
                return null;
            }
        }
    }


}
