using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class FactoriesRepository(FactoriesContext factoriesContext) : IFactoriesRepository
    {
        private readonly FactoriesContext _factoriesContext = factoriesContext;

        public Task<Factory> CreateFactoryAsync()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteFactoryAsync(int id)
        {
            Factory? factory = await _factoriesContext.Factories
                .FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) throw new ApiException(404, "Завода с таким ID не существует.");
        }

        public async Task<IEnumerable<Factory>> GetFactoriesAsync()
        {
            List<Factory> factories = await _factoriesContext.Factories
                .OrderBy(f => f.Id)
                .ToListAsync();
            return factories;
        }

        public async Task<Factory> GetFactoryByIdAsync(int id)
        {
            Factory? factory = await _factoriesContext.Factories
                .FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) throw new ApiException(404, "Завода с таким ID не существует.");
            return factory;
        }

        public async Task<Factory> UpdateFactoryAsync(int id)
        {
            Factory? factory = await _factoriesContext.Factories
                .FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) throw new ApiException(404, "Завода с таким ID не существует.");
            return factory;
        }
    }
}
