using SmallFactory.Models;

namespace SmallFactory.DTOs
{
    public class MachineDto
    {
        public int Id { get; set; }

        public int ProductionChainId { get; set; }

        public MachineTypes Type { get; set; }

        public int ReceiptId { get; set; }
    }
}
