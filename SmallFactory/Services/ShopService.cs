using Microsoft.EntityFrameworkCore;
using SmallFactory.Data;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Services
{
    public class ShopService(FactoriesContext factoriesContext, ShopItemsContext shopItemsContext, StoragesContext storagesContext) : IShopService
    {
        private readonly FactoriesContext _factoriesContext = factoriesContext;
        private readonly ShopItemsContext _shopItemsContext = shopItemsContext;
        private readonly StoragesContext _storagesContext = storagesContext;

        public async Task<string> BuyPartAsync(BuyPartDto buyPartDto)
        {
            Factory? factory = await _factoriesContext.Factories
                .FirstOrDefaultAsync(f => f.Id == buyPartDto.FactoryId);
            ShopItem? shopItem = await _shopItemsContext.ShopItems
                .Include(si => si.Part)
                .FirstOrDefaultAsync(si => si.Id == buyPartDto.ShopItemId);
            Storage? storage = await _storagesContext.Storages
                .FirstOrDefaultAsync(s => s.Id == buyPartDto.StorageId);

            if (factory == null)
                throw new ApiException(404, "Завода с таким ID не существует.");
            if (shopItem == null)
                throw new ApiException(404, "Товара с таким ID не существует.");
            if (storage == null)
                throw new ApiException(404, "Хранилища с таким ID не существует.");
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
            return $"Успешная покупка \"{shopItem.Part.Name}\" {buyPartDto.Quantity}шт.\nБаланс: ${factory.Budget}";
        }

        private async Task SaveAll()
        {
            int factoriesResult = await _factoriesContext.SaveChangesAsync();
            int shopItemsResult = await _shopItemsContext.SaveChangesAsync();
            int storagesResult = await _storagesContext.SaveChangesAsync();
            if (factoriesResult == 0 || shopItemsResult == 0 || storagesResult == 0)
                throw new ApiUnexpectedException();
        }
    }
}
