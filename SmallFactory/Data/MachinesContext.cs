using Microsoft.EntityFrameworkCore;
using SmallFactory.Models;

namespace SmallFactory.Data
{
    public class MachinesContext(DbContextOptions<MachinesContext> options) : DbContext(options)
    {
        public DbSet<Machine> Machines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Machine>()
                .HasOne(m => m.Receipt)
                .WithMany()
                .HasForeignKey(m => m.ReceiptId);
        }
    }
}
