using Microsoft.EntityFrameworkCore;
using SmallFactory.Models;

namespace SmallFactory.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Factory> Factories { get; set; }
        public DbSet<ProductionChain> ProductionChains { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factory>()
                .HasMany(f => f.ProductionChains)
                .WithOne(pc => pc.Factory)
                .HasForeignKey(pc => pc.FactoryId);

            modelBuilder.Entity<ProductionChain>()
                .HasMany(pc => pc.Machines)
                .WithOne(m => m.ProductionChain)
                .HasForeignKey(m => m.ProductionChainId);

            modelBuilder.Entity<Machine>()
                .HasOne(m => m.Receipt)
                .WithMany()
                .HasForeignKey(m => m.ReceiptId);

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

            modelBuilder.Entity<ShopItem>()
                .HasOne(si => si.Part)
                .WithOne(p => p.ShopItem)
                .HasForeignKey<ShopItem>(si => si.PartId);

            modelBuilder.Entity<Storage>()
                .HasOne(s => s.Factory)
                .WithMany(f => f.Storages)
                .HasForeignKey(s => s.FactoryId);

            modelBuilder.Entity<Storage>()
                .HasOne(s => s.Part)
                .WithMany()
                .HasForeignKey(s => s.PartId);
        }
    }
}
