using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    [Table("factories")]
    public class Factory
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("budget")]
        public decimal Budget { get; set; }

        public List<ProductionChain> ProductionChains { get; set; } = [];

        public List<Storage> Storages { get; set; } = [];
    }
}
