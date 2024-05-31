using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    [Table("production_chains")]
    [Index(nameof(Name), IsUnique = true)]
    public class ProductionChain
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("factory_id")]
        public int FactoryId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public Factory Factory { get; set; }

        public List<Machine> Machines { get; set; } = [];
    }
}
