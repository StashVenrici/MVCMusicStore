
namespace MVCMusicStore5.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    
        public virtual Album Album { get; set; }
        public virtual Order Order { get; set; }
    }
}
