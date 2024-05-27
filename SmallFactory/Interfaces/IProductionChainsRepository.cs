using SmallFactory.DTOs;
using SmallFactory.Models;

namespace SmallFactory.Interfaces
{
    public interface IProductionChainsRepository
    {
        public Task<IEnumerable<ProductionChain>> GetProductionChainsAsync();
        public Task<ProductionChain> GetProductionChainByIdAsync(int id);
        public Task<ProductionChain> CreateProductionChainAsync(CreateProductionChainDto createProductionChainDto);
        public Task<ProductionChain> UpdateProductionChainAsync(int id, UpdateProductionChainDto updateProductionChainDto);
        public Task DeleteProductionChainAsync(int id);
    }
}
