using System.ComponentModel.DataAnnotations.Schema;

namespace SmallFactory.Models
{
    public enum MachineTypes
    {
        CONSTRUCTOR,
        ASSEMBLER,
        MANUFACTURER
    }

    public enum MachineStatus
    {
        ERROR,
        WAITING,
        PROCESSING
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

        [Column("status")]
        public MachineStatus Status { get; set; }

        [Column("receipt_id")]
        public int ReceiptId { get; set; }

        public ProductionChain ProductionChain { get; set; }

        public Receipt Receipt { get; set; }
    }
}
