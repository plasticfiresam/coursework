using System.Collections.Generic;

namespace coursework.Entities
{
    /// <summary>
    /// Сущность категории товаров
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор категории товаров
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Краткое обозначение категории в адресной строке
        /// </summary>
        public string Slug { get; set; }
        public bool CanBeDeleted { get; set; } = true;
        /// <summary>
        /// Связанные сущности объявлений
        /// </summary>
        public List<Announce> Announcements { get; set; } = new List<Announce>();
        public override string ToString()
        {
            return Name;
        }
    }
}
