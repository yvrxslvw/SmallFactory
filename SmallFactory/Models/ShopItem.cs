using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    [Table("shop")]
    public class ShopItem
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("part_id")]
        public int PartId { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("count")]
        public int Count { get; set; }

        [Column("cooldown")]
        public int CoolDown { get; set; }
    }
}
