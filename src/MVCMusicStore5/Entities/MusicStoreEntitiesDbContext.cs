using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using MVCMusicStore5.Repositories;

namespace MVCMusicStore5.Entities
{

    public class MusicStoreEntitiesDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LAPTOP-6RLIUI13\SQLSERVEREXPRESS;Database=MVCMusicStore;Trusted_Connection=True;MultipleActiveResultSets=true");
        }


    }
}
