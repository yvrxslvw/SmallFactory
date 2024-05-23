using Microsoft.EntityFrameworkCore;
using SmallFactory.Models;

namespace SmallFactory.Data
{
    public class FactoriesContext(DbContextOptions<FactoriesContext> options) : DbContext(options)
    {
        public DbSet<Factory> Factories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factory>()
                .HasMany(f => f.ProductionChains)
                .WithOne(pc => pc.Factory)
                .HasForeignKey(pc => pc.FactoryId);
        }
    }
}
