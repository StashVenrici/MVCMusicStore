using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCMusicStore5.BusinessLogic;
using MVCMusicStore5.Models.AlbumModels;

namespace MVCMusicStore5.Models.OrderModels
{
    public class OrderModel
    {
        public List<CartItemModel> CartItems { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
