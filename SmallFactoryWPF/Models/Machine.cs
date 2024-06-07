namespace SmallFactoryWPF.Models
{
    public enum ProductionType
    {
        CONSTRUCTOR,
        ASSEMBLER,
        MANUFACTURER
    }

    public enum MachineStatus
    {
        WAITING,
        PROCESSING
    }

    internal class Machine
    {
        public ProductionType MachineType { get; set; }

        public Receipt Receipt { get; set; }

        public MachineStatus Status { get; set; }
    }
}
