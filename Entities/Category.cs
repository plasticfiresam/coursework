using System.Collections.Generic;

namespace coursework.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Announcement> Announcements { get; set; } = new List<Announcement>();
        public override string ToString()
        {
            return Name;
        }
    }
}
