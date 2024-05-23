using Microsoft.EntityFrameworkCore;
using SmallFactory.Models;

namespace SmallFactory.Data
{
    public class ShopItemsContext(DbContextOptions<ShopItemsContext> options) : DbContext(options)
    {
        public DbSet<ShopItem> ShopItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopItem>()
                .HasOne(si => si.Part)
                .WithOne(p => p.ShopItem)
                .HasForeignKey<ShopItem>(si => si.PartId);
        }
    }
}
