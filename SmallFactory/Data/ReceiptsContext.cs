using Microsoft.EntityFrameworkCore;
using SmallFactory.Models;

namespace SmallFactory.Data
{
    public class ReceiptsContext(DbContextOptions<ReceiptsContext> options) : DbContext(options)
    {
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.ManufacturedPart)
                .WithMany(p => p.Receipts)
                .HasForeignKey(r => r.ManufacturedPartId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Material1Part)
                .WithMany(p => p.Receipts)
                .HasForeignKey(r => r.Material1PartId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Material2Part)
                .WithMany(p => p.Receipts)
                .HasForeignKey(r => r.Material2PartId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Material3Part)
                .WithMany(p => p.Receipts)
                .HasForeignKey(r => r.Material3PartId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Material4Part)
                .WithMany(p => p.Receipts)
                .HasForeignKey(r => r.Material4PartId);
        }
    }
}
