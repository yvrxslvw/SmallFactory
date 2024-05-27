using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class FactoriesRepository(FactoriesContext factoriesContext) : IFactoriesRepository
    {
        private readonly FactoriesContext _factoriesContext = factoriesContext;

        public async Task<Factory> CreateFactoryAsync(CreateFactoryDto createFactoryDto)
        {
            if (await IsFactoryExists(createFactoryDto.Name))
                throw new ApiException(403, "Завод с таким названием уже существует.");
            Factory factory = new()
            {
                Name = createFactoryDto.Name,
                Budget = 12000
            };
            _factoriesContext.Factories.Add(factory);
            await Save();
            return factory;
        }

        public async Task DeleteFactoryAsync(int id)
        {
            Factory? factory = await _factoriesContext.Factories
                .Include(f => f.ProductionChains)
                .FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) throw new ApiException(404, "Завода с таким ID не существует.");
            _factoriesContext.Factories.Remove(factory);
            await Save();
        }

        public async Task<IEnumerable<Factory>> GetFactoriesAsync()
        {
            List<Factory> factories = await _factoriesContext.Factories
                .Include(f => f.ProductionChains)
                .OrderBy(f => f.Id)
                .ToListAsync();
            return factories;
        }

        public async Task<Factory> GetFactoryByIdAsync(int id)
        {
            Factory? factory = await _factoriesContext.Factories
                .Include(f => f.ProductionChains)
                .FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) throw new ApiException(404, "Завода с таким ID не существует.");
            return factory;
        }

        public async Task<Factory> UpdateFactoryAsync(int id, UpdateFactoryDto updateFactoryDto)
        {
            Factory? factory = await _factoriesContext.Factories
                .Include(f => f.ProductionChains)
                .FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) throw new ApiException(404, "Завода с таким ID не существует.");
            if (updateFactoryDto.Name == factory.Name) return factory;
            else if (await IsFactoryExists(updateFactoryDto.Name))
                throw new ApiException(403, "Завод с таким названием уже существует.");
            factory.Name = updateFactoryDto.Name ?? factory.Name;
            await Save();
            return factory;
        }

        private async Task<bool> IsFactoryExists(int id)
        {
            Factory? factory = await _factoriesContext.Factories.FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) return false;
            else return true;
        }

        private async Task<bool> IsFactoryExists(string name)
        {
            Factory? factory = await _factoriesContext.Factories.FirstOrDefaultAsync(f => f.Name == name);
            if (factory == null) return false;
            else return true;
        }

        private async Task Save()
        {
            int result = await _factoriesContext.SaveChangesAsync();
            if (result == 0)
                throw new ApiUnexpectedException();
        }
    }
}
