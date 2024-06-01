using SmallFactory.DTOs;
using SmallFactory.Models;

namespace SmallFactory.Interfaces
{
    public interface IShopItemsRepository
    {
        public Task<IEnumerable<ShopItem>> GetShopItemsAsync();
        public Task<ShopItem> GetShopItemByIdAsync(int id);
        public Task<ShopItem> CreateShopItemAsync(CreateShopItemDto createShopItemDto);
        public Task<ShopItem> UpdateShopItemAsync(int id, UpdateShopItemDto updateShopItemDto);
        public Task DeleteShopItemAsync(int id);
    }
}
