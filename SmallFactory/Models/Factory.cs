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
        public int Budget { get; set; }
    }
}
