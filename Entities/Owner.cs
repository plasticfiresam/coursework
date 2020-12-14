using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace coursework.Entities
{
    public class Owner
    {
        public string Name { get; set; }
        [Key]
        public string ProfileGuid { get; set; }
        public string Url { get; set; }

        public List<Announcement> Announcements { get; set; } = new List<Announcement>();

        public override string ToString()
        {
            return Name;
        }
    }
}
