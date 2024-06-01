using SmallFactory.DTOs;
using SmallFactory.Models;

namespace SmallFactory.Interfaces
{
    public interface IStoragesRepository
    {
        public Task<IEnumerable<Storage>> GetStoragesAsync();
        public Task<Storage> GetStorageByIdAsync(int id);
        public Task<Storage> CreateStorageAsync(CreateStorageDto createStorageDto);
        public Task<Storage> UpdateStorageAsync(int id, UpdateStorageDto updateStorageDto);
        public Task DeleteStorageAsync(int id);
    }
}
