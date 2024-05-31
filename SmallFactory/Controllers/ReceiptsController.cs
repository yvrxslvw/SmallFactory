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
    public class ReceiptsController(IMapper mapper, IReceiptsRepository receiptsRepository) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IReceiptsRepository _receiptsRepository = receiptsRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Receipt> receipts = (await _receiptsRepository.GetReceiptsAsync()).ToList();
                return Ok(_mapper.Map<List<ReceiptDto>>(receipts));
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
                Receipt receipt = await _receiptsRepository.GetReceiptByIdAsync(id);
                return Ok(_mapper.Map<ReceiptDto>(receipt));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReceiptDto createReceiptDto)
        {
            try
            {
                Receipt receipt = await _receiptsRepository.CreateReceiptAsync(createReceiptDto);
                return Ok(_mapper.Map<ReceiptDto>(receipt));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateReceiptDto updateReceiptDto)
        {
            try
            {
                Receipt receipt = await _receiptsRepository.UpdateReceiptAsync(id, updateReceiptDto);
                return Ok(_mapper.Map<ReceiptDto>(receipt));
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
                await _receiptsRepository.DeleteReceiptAsync(id);
                return Ok($"Рецепт с ID: {id} успешно удалён.");
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }
    }
}
