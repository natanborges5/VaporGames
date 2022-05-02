using Microsoft.EntityFrameworkCore;
using VaporGames.Models;

namespace VaporGames.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        //public DbSet<Cart> Cart { get; set; }
        //public DbSet<Review> Reviews { get; set; }
    }
}
