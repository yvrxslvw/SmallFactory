using SmallFactory.Models;

namespace SmallFactory.DTOs
{
    public class ReceiptDto
    {
        public int Id { get; set; }

        public MachineTypes ProductionType { get; set; }

        public int ManufacturedPartId { get; set; }

        public int Material1PartId { get; set; }

        public int Material2PartId { get; set; }

        public int Material3PartId { get; set; }

        public int Material4PartId { get; set; }

        public double ProductionRate { get; set; }
    }
}
