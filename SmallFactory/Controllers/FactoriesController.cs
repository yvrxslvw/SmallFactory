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
    public class FactoriesController(IFactoriesRepository factoriesRepository, IMapper mapper) : ControllerBase
    {
        private readonly IFactoriesRepository _factoriesRepository = factoriesRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Factory> factories = (await _factoriesRepository.GetFactoriesAsync()).ToList();
                return Ok(_mapper.Map<List<FactoryDto>>(factories));
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
                Factory factory = await _factoriesRepository.GetFactoryByIdAsync(id);
                return Ok(_mapper.Map<FactoryDto>(factory));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateFactoryDto createFactoryDto)
        {
            try
            {
                Factory factory = await _factoriesRepository.CreateFactoryAsync(createFactoryDto);
                return Ok(_mapper.Map<FactoryDto>(factory));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateFactoryDto updateFactoryDto)
        {
            try
            {
                Factory factory = await _factoriesRepository.UpdateFactoryAsync(id, updateFactoryDto);
                return Ok(_mapper.Map<FactoryDto>(factory));
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
                await _factoriesRepository.DeleteFactoryAsync(id);
                return Ok($"Завод с ID: {id} успешно удалён.");
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }
    }
}
