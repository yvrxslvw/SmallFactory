using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Services
{
    public class ShopService(StoragesContext storagesContext) : IShopService
    {
        private readonly StoragesContext _storagesContext = storagesContext;

        public async Task<string> BuyPartAsync(BuyPartDto buyPartDto)
        {
            Storage? storage = await _storagesContext.Storages
                .Include(s => s.Factory)
                .Include(s => s.Part)
                .ThenInclude(p => p.ShopItem)
                .FirstOrDefaultAsync(s => s.Id == buyPartDto.StorageId);
            if (storage == null)
                throw new ApiException(404, "Хранилища с таким ID не существует.");
            Factory factory = storage.Factory;
            ShopItem shopItem = storage.Part.ShopItem;

            if (buyPartDto.Quantity <= 0)
                throw new ApiException(400, "Некорректное количество покупаемого товара.");
            if (shopItem.Count < buyPartDto.Quantity)
                throw new ApiException(403, "В магазине недостаточно товара.");
            if (buyPartDto.Quantity + storage.Count > storage.Max)
                throw new ApiException(403, "В хранилище не хватит места.");
            if (factory.Budget - shopItem.Price * buyPartDto.Quantity < 0)
                throw new ApiException(403, "Недостаточно средств.");

            decimal price = shopItem.Price * buyPartDto.Quantity;

            factory.Budget -= price;
            shopItem.Count -= buyPartDto.Quantity;
            storage.Count += buyPartDto.Quantity;

            await Save();
            return $"Успешная покупка \"{shopItem.Part.Name}\" {buyPartDto.Quantity}шт на сумму ${price}.\nБаланс: ${factory.Budget}\nДеталей на складе: {storage.Count}";
        }

        public async Task<string> SellPartAsync(SellPartDto sellPartDto)
        {
            Storage? storage = await _storagesContext.Storages
                .Include(s => s.Factory)
                .Include(s => s.Part)
                .ThenInclude(p => p.ShopItem)
                .FirstOrDefaultAsync(s => s.Id == sellPartDto.StorageId);
            if (storage == null)
                throw new ApiException(404, "Хранилища с таким ID не существует.");
            Factory factory = storage.Factory;
            ShopItem shopItem = storage.Part.ShopItem;

            if (sellPartDto.Quantity <= 0)
                throw new ApiException(400, "Некорректное количество продаваемого товара.");
            if (storage.Count - sellPartDto.Quantity < 0)
                throw new ApiException(403, "В хранилище недостаточно деталей.");

            decimal price = (shopItem.Price - (shopItem.Price / 100 * 5)) * sellPartDto.Quantity;

            factory.Budget += price;
            shopItem.Count += sellPartDto.Quantity;
            storage.Count -= sellPartDto.Quantity;

            await Save();
            return $"Успешная продажа \"{shopItem.Part.Name}\" {sellPartDto.Quantity}шт на сумму ${price}.\nБаланс: ${factory.Budget}\nДеталей на складе: {storage.Count}";
        }

        private async Task Save()
        {
            int result = await _storagesContext.SaveChangesAsync();
            if (result == 0)
                    throw new ApiUnexpectedException();
        }
    }
}
