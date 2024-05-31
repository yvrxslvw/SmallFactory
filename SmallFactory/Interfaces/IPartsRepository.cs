using SmallFactory.DTOs;
using SmallFactory.Models;

namespace SmallFactory.Interfaces
{
    public interface IPartsRepository
    {
        public Task<IEnumerable<Part>> GetPartsAsync();
        public Task<Part> GetPartByIdAsync(int id);
        public Task<Part> CreatePartAsync(CreatePartDto createPartDto);
        public Task<Part> UpdatePartAsync(int id, UpdatePartDto updatePartDto);
        public Task DeletePartAsync(int id);
    }
}
