

namespace MVCMusicStore5.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class Artist
    {
        public Artist()
        {
            this.Albums = new HashSet<Album>();
        }
    
        public int ArtistId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Album> Albums { get; set; }
    }
}
