using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Repositories
{
    public class ShopItemsRepository(AppDbContext context) : IShopItemsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ShopItem> CreateShopItemAsync(CreateShopItemDto createShopItemDto)
        {
            if (!(await IsPartExists(createShopItemDto.PartId)))
                throw new ApiException(404, "Детали с таким ID не существует.");
            if (createShopItemDto.Price == 0)
                throw new ApiException(400, "Поле 'Цена товара' обязательно для заполнения.");
            if (createShopItemDto.CoolDown == 0)
                throw new ApiException(400, "Поле 'Время обновления' обязательно для заполнения.");
            ShopItem shopItem = new()
            {
                PartId = createShopItemDto.PartId,
                Price = createShopItemDto.Price,
                CoolDown = createShopItemDto.CoolDown,
                Count = 0,
                LastReplineshment = DateTime.Now.ToUniversalTime()
            };
            _context.ShopItems.Add(shopItem);
            await Save();
            return shopItem;
        }

        public async Task DeleteShopItemAsync(int id)
        {
            ShopItem? shopItem = await _context.ShopItems
                .Include(si => si.Part)
                .FirstOrDefaultAsync(si => si.Id == id);
            if (shopItem == null)
                throw new ApiException(404, "Товара с таким ID не существует.");
            _context.ShopItems.Remove(shopItem);
            await Save();
        }

        public async Task<ShopItem> GetShopItemByIdAsync(int id)
        {
            ShopItem? shopItem = await _context.ShopItems
                .Include(si => si.Part)
                .FirstOrDefaultAsync(si => si.Id == id);
            if (shopItem == null)
                throw new ApiException(404, "Товара с таким ID не существует.");
            return shopItem;
        }

        public async Task<IEnumerable<ShopItem>> GetShopItemsAsync()
        {
            List<ShopItem> shopItems = await _context.ShopItems
                .Include(si => si.Part)
                .OrderBy(si => si.Id)
                .ToListAsync();
            return shopItems;
        }

        public async Task<ShopItem> UpdateShopItemAsync(int id, UpdateShopItemDto updateShopItemDto)
        {
            ShopItem? shopItem = await _context.ShopItems
                .Include(si => si.Part)
                .FirstOrDefaultAsync(si => si.Id == id);
            if (shopItem == null)
                throw new ApiException(404, "Товара с таким ID не существует.");
            if (updateShopItemDto.Price != 0)
                shopItem.Price = updateShopItemDto.Price;
            if (updateShopItemDto.CoolDown != 0)
                shopItem.CoolDown = updateShopItemDto.CoolDown;
            await Save();
            return shopItem;
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private async Task<bool> IsPartExists(int partId)
        {
            Part? part = await _context.Parts.FirstOrDefaultAsync(p => p.Id == partId);
            if (part == null) return false;
            else return true;
        }
    }
}
