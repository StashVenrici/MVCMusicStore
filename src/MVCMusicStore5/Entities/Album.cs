using System.ComponentModel.DataAnnotations.Schema;

namespace MVCMusicStore5.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class Album
    {
        public Album()
        {
            this.Carts = new HashSet<Cart>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public Artist Artist { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
