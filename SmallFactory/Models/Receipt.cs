using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    [Table("receipts")]
    public class Receipt
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("production_type")]
        public MachineTypes ProductionType { get; set; }

        [Column("manufactured_part_id")]
        public int ManufacturedPartId { get; set; }

        [Column("material_1_part_id")]
        public int Material1PartId { get; set; }

        [Column("material_2_part_id")]
        public int Material2PartId { get; set; }

        [Column("material_3_part_id")]
        public int Material3PartId { get; set; }

        [Column("material_4_part_id")]
        public int Material4PartId { get; set; }

        [Column("production_rate")]
        [Comment("Per minute")]
        public double ProductionRate { get; set; }
    }
}
