namespace MVCMusicStore5.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class Genre
    {
        public Genre()
        {
            this.Albums = new HashSet<Album>();
        }
    
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Album> Albums { get; set; }

    }
}
