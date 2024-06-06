using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    [Table("parts")]
    [Index(nameof(Name), IsUnique = true)]
    public class Part
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        public ShopItem ShopItem { get; set; }

        public List<Storage> Storages { get; set; } = [];
    }
}
