using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using coursework.Entities;
using coursework.Parser;

namespace coursework.Models
{
    public class AnnounceDetailsInfo
    {
        public Owner? OwnerData { get; set; }
        public string Description { get; set; }
        public int VisitorsTotal { get; set; }
        public int VisitorsDaily { get; set; }
        public static AnnounceDetailsInfo ParseFromDetailedPage(IDocument detailedPage)
        {
            var owner = Owner.ParseFromDetailPage(detailedPage);
            var description = detailedPage.QuerySelector<IHtmlDivElement>(DataSelectors.DescriptionSelector).TextContent.Trim();

            var visitorsBloc = detailedPage.QuerySelector<IHtmlDivElement>(DataSelectors.VisitorsSelector);
            if (visitorsBloc != null)
            {
                var visitorsString = visitorsBloc.TextContent.Trim();
                var totalVisitorsNumber = int.Parse(visitorsString.Split(" ")[0]);
                var dynamicsValue = visitorsString.Split(" ")[1].Replace("(", "").Replace(")", "");
                var isPositive = dynamicsValue.Contains("+");
                var dynamicsNumber = int.Parse(dynamicsValue.Replace("+", "").Replace("-", ""));
                
                return new AnnounceDetailsInfo()
                {
                    OwnerData = owner,
                    Description = description,
                    VisitorsDaily = dynamicsNumber,
                    VisitorsTotal = totalVisitorsNumber,
                };
            }
            else
            {
                return new AnnounceDetailsInfo()
                {
                    OwnerData = owner,
                    Description = description,
                };
            }

        }
    }
}
