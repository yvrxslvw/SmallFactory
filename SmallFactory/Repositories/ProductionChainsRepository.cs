using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class ProductionChainsRepository(AppDbContext context) : IProductionChainsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ProductionChain> CreateProductionChainAsync(CreateProductionChainDto createProductionChainDto)
        {
            if (await IsProductChainExists(createProductionChainDto.Name))
                throw new ApiException(403, "Производственная цепочка с таким названием уже существует.");
            Factory? factory = await _context.Factories.FirstOrDefaultAsync(f => f.Id == createProductionChainDto.FactoryId);
            if (factory == null)
                throw new ApiException(404, "Завода с таким ID не существует.");
            ProductionChain productionChain = new()
            {
                FactoryId = factory.Id,
                Name = createProductionChainDto.Name
            };
            _context.ProductionChains.Add(productionChain);
            await Save();
            return productionChain;
        }

        public async Task DeleteProductionChainAsync(int id)
        {
            ProductionChain? productionChain = await _context.ProductionChains
                .Include(pc => pc.Machines)
                .FirstOrDefaultAsync(pc => pc.Id == id);
            if (productionChain == null)
                throw new ApiException(404, "Производственной цепочки с таким ID не существует.");
            _context.ProductionChains.Remove(productionChain);
            await Save();
        }

        public async Task<ProductionChain> GetProductionChainByIdAsync(int id)
        {
            ProductionChain? productionChain = await _context.ProductionChains
                .Include(pc => pc.Machines)
                .FirstOrDefaultAsync(pc => pc.Id == id);
            if (productionChain == null)
                throw new ApiException(404, "Производственной цепочки с таким ID не существует.");
            return productionChain;
        }

        public async Task<IEnumerable<ProductionChain>> GetProductionChainsAsync()
        {
            List<ProductionChain> productionChains = await _context.ProductionChains
                .Include(pc => pc.Machines)
                .OrderBy(pc => pc.Id)
                .ToListAsync();
            return productionChains;
        }

        public async Task<ProductionChain> UpdateProductionChainAsync(int id, UpdateProductionChainDto updateProductionChainDto)
        {
            ProductionChain? productionChain = await _context.ProductionChains
                .Include(pc => pc.Machines)
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
            ProductionChain? productionChain = await _context.ProductionChains.FirstOrDefaultAsync(pc => pc.Id == id);
            if (productionChain == null) return false;
            else return true;
        }

        private async Task<bool> IsProductChainExists(string name)
        {
            ProductionChain? productionChain = await _context.ProductionChains.FirstOrDefaultAsync(pc => pc.Name == name);
            if (productionChain == null) return false;
            else return true;
        }

        private async Task Save()
        {
            int result = await _context.SaveChangesAsync();
            if (result == 0)
                throw new ApiUnexpectedException();
        }
    }
}
