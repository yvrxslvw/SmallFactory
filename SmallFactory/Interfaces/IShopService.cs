using SmallFactory.DTOs;

namespace SmallFactory.Interfaces
{
    public interface IShopService
    {
        public Task<string> BuyPartAsync(BuyPartDto buyPartDto);
    }
}
