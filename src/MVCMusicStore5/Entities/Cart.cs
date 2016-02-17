
namespace MVCMusicStore5.Entities
{
    using System;
    using System.Collections.Generic;
    
    public class Cart
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
    
        public virtual Album Album { get; set; }
    }
}
