using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCMusicStore5.Models.AlbumModels;

namespace MVCMusicStore5.Models.OrderModels
{
    public class CartItemModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal ItemSubtotal { get; set; }
    }
}
