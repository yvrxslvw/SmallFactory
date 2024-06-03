namespace SmallFactory.DTOs
{
    public class FactoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Budget { get; set; }

        public List<ProductionChainDto> ProductionChains { get; set; } = [];

        public List<StorageDto> Storages { get; set; } = [];
    }
}
