using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class StoragesRepository(StoragesContext storagesContext, FactoriesContext factoriesContext, PartsContext partsContext) : IStoragesRepository
    {
        private readonly StoragesContext _storagesContext = storagesContext;
        private readonly FactoriesContext _factoriesContext = factoriesContext;
        private readonly PartsContext _partsContext = partsContext;

        public async Task<Storage> CreateStorageAsync(CreateStorageDto createStorageDto)
        {
            if (!(await IsFactoryExists(createStorageDto.FactoryId)))
                throw new ApiException(404, "Завода с таким ID не существует.");
            if (!(await IsPartExists(createStorageDto.PartId)))
                throw new ApiException(404, "Детали с таким ID не существует.");
            Storage storage = new()
            {
                FactoryId = createStorageDto.FactoryId,
                PartId = createStorageDto.PartId,
                Count = 0,
                Max = createStorageDto.Max
            };
            _storagesContext.Storages.Add(storage);
            await Save();
            return storage;
        }

        public async Task DeleteStorageAsync(int id)
        {
            Storage? storage = await _storagesContext.Storages
                .Include(s => s.Part)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (storage == null)
                throw new ApiException(404, "Хранилища с таким ID не существует.");
            _storagesContext.Storages.Remove(storage);
            await Save();
        }

        public async Task<Storage> GetStorageByIdAsync(int id)
        {
            Storage? storage = await _storagesContext.Storages
                .Include(s => s.Part)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (storage == null)
                throw new ApiException(404, "Хранилища с таким ID не существует.");
            return storage;
        }

        public async Task<IEnumerable<Storage>> GetStoragesAsync()
        {
            List<Storage> storages = await _storagesContext.Storages
                .Include(s => s.Part)
                .OrderBy(s => s.Id)
                .ToListAsync();
            return storages;
        }

        public async Task<Storage> UpdateStorageAsync(int id, UpdateStorageDto updateStorageDto)
        {
            Storage? storage = await _storagesContext.Storages
                .Include(s => s.Part)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (storage == null)
                throw new ApiException(404, "Хранилища с таким ID не существует.");
            if (updateStorageDto.PartId != 0)
            {
                if (!(await IsPartExists(updateStorageDto.PartId)))
                    throw new ApiException(404, "Детали с таким ID не существует.");
                storage.PartId = updateStorageDto.PartId;
            }
            if (updateStorageDto.Max != 0)
            {
                storage.Max = updateStorageDto.Max;
            }
            await Save();
            return storage;
        }

        private async Task Save()
        {
            int result = await _storagesContext.SaveChangesAsync();
            if (result == 0)
                throw new ApiUnexpectedException();
        }

        private async Task<bool> IsFactoryExists(int factoryId)
        {
            Factory? factory = await _factoriesContext.Factories.FirstOrDefaultAsync(f => f.Id == factoryId);
            if (factory == null) return false;
            else return true;
        }

        private async Task<bool> IsPartExists(int partId)
        {
            Part? part = await _partsContext.Parts.FirstOrDefaultAsync(p => p.Id == partId);
            if (part == null) return false;
            else return true;
        }
    }
}
