using SmallFactory.DTOs;
using SmallFactory.Models;

namespace SmallFactory.Interfaces
{
    public interface IReceiptsRepository
    {
        public Task<IEnumerable<Receipt>> GetReceiptsAsync();
        public Task<Receipt> GetReceiptByIdAsync(int id);
        public Task<Receipt> CreateReceiptAsync(CreateReceiptDto createReceiptDto);
        public Task<Receipt> UpdateReceiptAsync(int id, UpdateReceiptDto updateReceiptDto);
        public Task DeleteReceiptAsync(int id);
    }
}
