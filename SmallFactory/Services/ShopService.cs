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
            if (storage.PartId != shopItem.PartId)
                throw new ApiException(403, "Покупаемый товар не совпадает с типом деталей в хранилище.");
            if (shopItem.Count < buyPartDto.Quantity)
                throw new ApiException(403, "В магазине недостаточно товара.");
            if (buyPartDto.Quantity + storage.Count > storage.Max)
                throw new ApiException(403, "В хранилище не хватит места.");
            if (factory.Budget - shopItem.Price * buyPartDto.Quantity < 0)
                throw new ApiException(403, "Недостаточно средств.");

            factory.Budget -= shopItem.Price * buyPartDto.Quantity;
            shopItem.Count -= buyPartDto.Quantity;
            storage.Count += buyPartDto.Quantity;

            await SaveAll();
            return $"Успешная покупка \"{shopItem.Part.Name}\" {buyPartDto.Quantity}шт на ${shopItem.Price * buyPartDto.Quantity}.\nБаланс: ${factory.Budget}";
        }

        public Task<string> SellPartAsync(SellPartDto sellPartDto)
        {
            throw new NotImplementedException();
        }

        private async Task SaveAll()
        {
            int result = await _storagesContext.SaveChangesAsync();
            if (result == 0)
                    throw new ApiUnexpectedException();
        }
    }
}
