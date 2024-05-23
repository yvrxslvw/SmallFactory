using Microsoft.EntityFrameworkCore;
using SmallFactory.Models;

namespace SmallFactory.Data
{
    public class ProductionChainsContext(DbContextOptions<ProductionChainsContext> options) : DbContext(options)
    {
        public DbSet<ProductionChain> ProductionChains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductionChain>()
                .HasMany(pc => pc.Machines)
                .WithOne(m => m.ProductionChain)
                .HasForeignKey(m => m.ProductionChainId);
        }
    }
}
