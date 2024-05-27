using Microsoft.EntityFrameworkCore;
using SmallFactory.Models;

namespace SmallFactory.Data
{
    public class StoragesContext(DbContextOptions<StoragesContext> options) : DbContext(options)
    {
        public DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
