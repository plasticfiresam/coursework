using AngleSharp.Dom;
using coursework.Entities;

namespace coursework.Models
{
    public class AnnounceDetailsInfo
    {
        public Owner? OwnerData { get; set; }
        public static AnnounceDetailsInfo ParseFromDetailedPage(IDocument detailedPage)
        {
            var owner = Owner.ParseFromDetailPage(detailedPage);

            return new AnnounceDetailsInfo() { 
                OwnerData = owner,
            };
        }
    }
}
