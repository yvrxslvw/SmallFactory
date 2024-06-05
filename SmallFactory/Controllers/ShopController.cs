using Microsoft.AspNetCore.Mvc;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;

namespace SmallFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController(IShopService shopService) : ControllerBase
    {
        private readonly IShopService _shopService = shopService;

        [HttpPost("buy")]
        public async Task<IActionResult> BuyPart([FromBody] BuyPartDto buyPartDto)
        {
            try
            {
                string result = await _shopService.BuyPartAsync(buyPartDto);
                return Ok(result);
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPost("sell")]
        public async Task<IActionResult> SellPart([FromBody] SellPartDto sellPartDto)
        {
            try
            {
                string result = await _shopService.SellPartAsync(sellPartDto);
                return Ok(result);
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }
    }
}
