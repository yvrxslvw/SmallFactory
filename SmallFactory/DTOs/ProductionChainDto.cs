using SmallFactory.Models;

namespace SmallFactory.DTOs
{
    public class ProductionChainDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public FactoryDto Factory { get; set; }
    }
}
