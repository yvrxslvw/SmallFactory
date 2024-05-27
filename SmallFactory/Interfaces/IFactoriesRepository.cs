using SmallFactory.Models;

namespace SmallFactory.Interfaces
{
    public interface IFactoriesRepository
    {
        public Task<IEnumerable<Factory>> GetFactoriesAsync();
        public Task<Factory> GetFactoryByIdAsync(int id);
        public Task<Factory> CreateFactoryAsync();
        public Task<Factory> UpdateFactoryAsync(int id);
        public Task DeleteFactoryAsync(int id);
    }
}
