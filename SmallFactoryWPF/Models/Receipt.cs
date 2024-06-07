namespace SmallFactoryWPF.Models
{
    internal class Receipt
    {
        public ProductionType ProductionType { get; set; }

        public Part ManufacturedPart { get; set; }

        public Part Material1Part { get; set; }

        public Part Material2Part { get; set; }

        public Part Material3Part { get; set; }

        public Part Material4Part { get; set; }

        public double ProductionRate { get; set; }
    }
}
