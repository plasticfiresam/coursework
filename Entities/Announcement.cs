namespace coursework.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Url { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public string? OwnerGuid { get; set; }
        public Owner Owner { get; set; }
    }
}
