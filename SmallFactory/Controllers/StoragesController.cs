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
    public class StoragesController(IMapper mapper, IStoragesRepository storagesRepository) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IStoragesRepository _storagesRepository = storagesRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Storage> storages = (await _storagesRepository.GetStoragesAsync()).ToList();
                return Ok(_mapper.Map<List<StorageDto>>(storages));
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
                Storage storage = await _storagesRepository.GetStorageByIdAsync(id);
                return Ok(_mapper.Map<StorageDto>(storage));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateStorageDto createStorageDto)
        {
            try
            {
                Storage storage = await _storagesRepository.CreateStorageAsync(createStorageDto);
                return Ok(_mapper.Map<StorageDto>(storage));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateStorageDto updateStorageDto)
        {
            try
            {
                Storage storage = await _storagesRepository.UpdateStorageAsync(id, updateStorageDto);
                return Ok(_mapper.Map<StorageDto>(storage));
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
                await _storagesRepository.DeleteStorageAsync(id);
                return Ok($"Хранилище с ID: {id} успешно удалено.");
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }
    }
}
