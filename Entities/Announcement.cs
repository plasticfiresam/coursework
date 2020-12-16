using System.ComponentModel.DataAnnotations;

namespace coursework.Entities
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Url { get; set; }
        public string AnnouncementNumber { get; set; }
        [MaxLength(1000000)]
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string? OwnerGuid { get; set; }
        public Owner Owner { get; set; }
        public int? TotalVisitors { get; set; } = 0;
        public int? DailyVisitorsDynamic { get; set; } = 0;
    }
}
