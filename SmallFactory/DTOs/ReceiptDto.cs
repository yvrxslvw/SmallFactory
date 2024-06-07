using SmallFactory.Models;

namespace SmallFactory.DTOs
{
    public class ReceiptDto
    {
        public int Id { get; set; }

        public MachineTypes ProductionType { get; set; }

        public double ProductionRate { get; set; }

        public PartDto ManufacturedPart { get; set; }

        public PartDto Material1Part { get; set; }

        public PartDto Material2Part { get; set; }

        public PartDto Material3Part { get; set; }

        public PartDto Material4Part { get; set; }

        public int Material1Count { get; set; }

        public int Material2Count { get; set; }

        public int Material3Count { get; set; }

        public int Material4Count { get; set; }
    }
}
