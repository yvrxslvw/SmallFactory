using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    [Table("parts")]
    public class Part
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ShopItem ShopItem { get; set; }

        public List<Receipt> Receipts { get; set; } = [];

        public List<Storage> Storages { get; set; } = [];
    }
}
