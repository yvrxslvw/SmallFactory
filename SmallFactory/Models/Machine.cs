using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    public enum MachineTypes
    {
        CONSTRUCTOR,
        ASSEMBLER,
        MANUFACTURER
    }

    [Table("machines")]
    public class Machine
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("production_chain_id")]
        public int ProductionChainId { get; set; }

        [Column("type")]
        public MachineTypes Type { get; set; }

        [Column("receipt_id")]
        public int ReceiptId { get; set; }
    }
}
