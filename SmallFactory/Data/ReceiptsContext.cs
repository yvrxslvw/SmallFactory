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
                .WithMany()
                .HasForeignKey(r => r.ManufacturedPartId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Material1Part)
                .WithMany()
                .HasForeignKey(r => r.Material1PartId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Material2Part)
                .WithMany()
                .HasForeignKey(r => r.Material2PartId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Material3Part)
                .WithMany()
                .HasForeignKey(r => r.Material3PartId);

            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Material4Part)
                .WithMany()
                .HasForeignKey(r => r.Material4PartId);
        }
    }
}
