using SmallFactory.DTOs;
using SmallFactory.Models;

namespace SmallFactory.Interfaces
{
    public interface IFactoriesRepository
    {
        public Task<IEnumerable<Factory>> GetFactoriesAsync();
        public Task<Factory> GetFactoryByIdAsync(int id);
        public Task<Factory> CreateFactoryAsync(CreateFactoryDto createFactoryDto);
        public Task<Factory> UpdateFactoryAsync(int id, UpdateFactoryDto updateFactoryDto);
        public Task DeleteFactoryAsync(int id);
    }
}
