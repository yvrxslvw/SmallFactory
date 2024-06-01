using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmallFactory.DTOs;
using SmallFactory.Exceptions;
using SmallFactory.Interfaces;
using SmallFactory.Models;

namespace SmallFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemsController(IMapper mapper, IShopItemsRepository shopItemsRepository) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IShopItemsRepository _shopItemsRepository = shopItemsRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ShopItem> shopItems = (await _shopItemsRepository.GetShopItemsAsync()).ToList();
                return Ok(_mapper.Map<List<ShopItemDto>>(shopItems));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ShopItem shopItem = await _shopItemsRepository.GetShopItemByIdAsync(id);
                return Ok(_mapper.Map<ShopItemDto>(shopItem));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateShopItemDto createShopItemDto)
        {
            try
            {
                ShopItem shopItem = await _shopItemsRepository.CreateShopItemAsync(createShopItemDto);
                return Ok(_mapper.Map<ShopItemDto>(shopItem));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateShopItemDto updateShopItemDto)
        {
            try
            {
                ShopItem shopItem = await _shopItemsRepository.UpdateShopItemAsync(id, updateShopItemDto);
                return Ok(_mapper.Map<ShopItemDto>(shopItem));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shopItemsRepository.DeleteShopItemAsync(id);
                return Ok($"Товар с ID: {id} успешно удалён.");
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }
    }
}
