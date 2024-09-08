using Microsoft.EntityFrameworkCore;
namespace Shop.DataModels.Models
{
    public class ShoppingCartDBContext : DbContext
    {
        public ShoppingCartDBContext(DbContextOptions<ShoppingCartDBContext> options)
           : base(options)
        {
        }

        public DbSet<AdminInfo> AdminInfo { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-5M2TL6A\\TM_DAILY_TRACKR;Database=ShopCartDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
