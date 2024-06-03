namespace SmallFactory.DTOs
{
    public class ProductionChainDto
    {
        public int Id { get; set; }

        public int FactoryId { get; set; }

        public string Name { get; set; }

        public List<MachineDto> Machines { get; set; } = [];
    }
}
