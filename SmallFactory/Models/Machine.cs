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

        [Column("input_1_count")]
        public int Input1Count { get; set; }

        [Column("input_2_count")]
        public int Input2Count { get; set; }

        [Column("input_3_count")]
        public int Input3Count { get; set; }

        [Column("input_4_count")]
        public int Input4Count { get; set; }

        [Column("output_count")]
        public int OutputCount { get; set; }

        public ProductionChain ProductionChain { get; set; }

        public Receipt Receipt { get; set; }

        public Storage Storage { get; set; }
    }
}
