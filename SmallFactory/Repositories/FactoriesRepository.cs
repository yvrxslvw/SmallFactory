using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class FactoriesRepository(AppDbContext context) : IFactoriesRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<Factory> CreateFactoryAsync(CreateFactoryDto createFactoryDto)
        {
            if (await IsFactoryExists(createFactoryDto.Name))
                throw new ApiException(403, "Завод с таким названием уже существует.");
            Factory factory = new()
            {
                Name = createFactoryDto.Name,
                Budget = 12000
            };
            _context.Factories.Add(factory);
            await Save();
            return factory;
        }

        public async Task DeleteFactoryAsync(int id)
        {
            Factory? factory = await _context.Factories
                .Include(f => f.ProductionChains)
                .ThenInclude(pc => pc.Machines)
                .ThenInclude(m => m.Receipt)
                .Include(f => f.Storages)
                .ThenInclude(s => s.Part)
                .FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) throw new ApiException(404, "Завода с таким ID не существует.");
            _context.Factories.Remove(factory);
            await Save();
        }

        public async Task<IEnumerable<Factory>> GetFactoriesAsync()
        {
            List<Factory> factories = await _context.Factories
                .Include(f => f.ProductionChains)
                .ThenInclude(pc => pc.Machines)
                .ThenInclude(m => m.Receipt)
                .Include(f => f.Storages)
                .ThenInclude(s => s.Part)
                .OrderBy(f => f.Id)
                .ToListAsync();
            return factories;
        }

        public async Task<Factory> GetFactoryByIdAsync(int id)
        {
            Factory? factory = await _context.Factories
                .Include(f => f.ProductionChains)
                .ThenInclude(pc => pc.Machines)
                .ThenInclude(m => m.Receipt)
                .Include(f => f.Storages)
                .ThenInclude(s => s.Part)
                .FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) throw new ApiException(404, "Завода с таким ID не существует.");
            return factory;
        }

        public async Task<Factory> UpdateFactoryAsync(int id, UpdateFactoryDto updateFactoryDto)
        {
            Factory? factory = await _context.Factories
                .Include(f => f.ProductionChains)
                .ThenInclude(pc => pc.Machines)
                .ThenInclude(m => m.Receipt)
                .Include(f => f.Storages)
                .ThenInclude(s => s.Part)
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
            Factory? factory = await _context.Factories.FirstOrDefaultAsync(f => f.Id == id);
            if (factory == null) return false;
            else return true;
        }

        private async Task<bool> IsFactoryExists(string name)
        {
            Factory? factory = await _context.Factories.FirstOrDefaultAsync(f => f.Name == name);
            if (factory == null) return false;
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
