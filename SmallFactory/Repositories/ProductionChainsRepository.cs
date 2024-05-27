using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class ProductionChainsRepository(ProductionChainsContext productionChainsContext, FactoriesContext factoriesContext) : IProductionChainsRepository
    {
        private readonly ProductionChainsContext _productionChainsContext = productionChainsContext;
        private readonly FactoriesContext _factoriesContext = factoriesContext;

        public async Task<ProductionChain> CreateProductionChainAsync(CreateProductionChainDto createProductionChainDto)
        {
            if (await IsProductChainExists(createProductionChainDto.Name))
                throw new ApiException(403, "Производственная цепочка с таким названием уже существует.");
            Factory? factory = await _factoriesContext.Factories.FirstOrDefaultAsync(f => f.Id == createProductionChainDto.FactoryId);
            if (factory == null)
                throw new ApiException(404, "Завода с таким ID не существует.");
            ProductionChain productionChain = new()
            {
                FactoryId = factory.Id,
                Name = createProductionChainDto.Name
            };
            _productionChainsContext.ProductionChains.Add(productionChain);
            await Save();
            productionChain.Factory = factory;
            return productionChain;
        }

        public async Task DeleteProductionChainAsync(int id)
        {
            ProductionChain? productionChain = await _productionChainsContext.ProductionChains.FirstOrDefaultAsync(pc => pc.Id == id);
            if (productionChain == null)
                throw new ApiException(404, "Производственной цепочки с таким ID не существует.");
            _productionChainsContext.ProductionChains.Remove(productionChain);
            await Save();
        }

        public async Task<ProductionChain> GetProductionChainByIdAsync(int id)
        {
            ProductionChain? productionChain = await _productionChainsContext.ProductionChains
                .Include(pc => pc.Factory)
                .FirstOrDefaultAsync(pc => pc.Id == id);
            if (productionChain == null)
                throw new ApiException(404, "Производственной цепочки с таким ID не существует.");
            return productionChain;
        }

        public async Task<IEnumerable<ProductionChain>> GetProductionChainsAsync()
        {
            List<ProductionChain> productionChains = await _productionChainsContext.ProductionChains
                .Include(pc => pc.Factory)
                .OrderBy(pc => pc.Id)
                .ToListAsync();
            return productionChains;
        }

        public async Task<ProductionChain> UpdateProductionChainAsync(int id, UpdateProductionChainDto updateProductionChainDto)
        {
            ProductionChain? productionChain = await _productionChainsContext.ProductionChains
                .Include(pc => pc.Factory)
                .FirstOrDefaultAsync(pc => pc.Id == id);
            if (productionChain == null)
                throw new ApiException(404, "Производственной цепочки с таким ID не существует.");
            if (updateProductionChainDto.Name == productionChain.Name) return productionChain;
            else if (await IsProductChainExists(updateProductionChainDto.Name))
                throw new ApiException(403, "Производственная цепочка с таким названием уже существует.");
            productionChain.Name = updateProductionChainDto.Name ?? productionChain.Name;
            await Save();
            return productionChain;
        }

        private async Task<bool> IsProductChainExists(int id)
        {
            ProductionChain? productionChain = await _productionChainsContext.ProductionChains.FirstOrDefaultAsync(pc => pc.Id == id);
            if (productionChain == null) return false;
            else return true;
        }

        private async Task<bool> IsProductChainExists(string name)
        {
            ProductionChain? productionChain = await _productionChainsContext.ProductionChains.FirstOrDefaultAsync(pc => pc.Name == name);
            if (productionChain == null) return false;
            else return true;
        }

        private async Task Save()
        {
            int result = await _productionChainsContext.SaveChangesAsync();
            if (result == 0)
                throw new ApiUnexpectedException();
        }
    }
}
