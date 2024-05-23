using Microsoft.EntityFrameworkCore;
using SmallFactory.Models;

namespace SmallFactory.Data
{
    public class PartsContext(DbContextOptions<PartsContext> options) : DbContext(options)
    {
        public DbSet<Part> Parts { get; set; }
    }
}
