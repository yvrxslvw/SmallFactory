using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    [Table("storage")]
    public class Storage
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("factory_id")]
        public int FactoryId { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [Column("count")]
        public int Count { get; set; }

        [Column("max")]
        public int Max { get; set; }

        public Factory Factory { get; set; }

        public Part Part { get; set; }
    }
}
