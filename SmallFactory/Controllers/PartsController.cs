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
    public class PartsController(IMapper mapper, IPartsRepository partsRepository) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IPartsRepository _partsRepository = partsRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Part> parts = (await _partsRepository.GetPartsAsync()).ToList();
                return Ok(_mapper.Map<List<PartDto>>(parts));
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
                Part part = await _partsRepository.GetPartByIdAsync(id);
                return Ok(_mapper.Map<PartDto>(part));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePartDto createPartDto)
        {
            try
            {
                Part part = await _partsRepository.CreatePartAsync(createPartDto);
                return Ok(_mapper.Map<PartDto>(part));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdatePartDto updatePartDto)
        {
            try
            {
                Part part = await _partsRepository.UpdatePartAsync(id, updatePartDto);
                return Ok(_mapper.Map<PartDto>(part));
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
                await _partsRepository.DeletePartAsync(id);
                return Ok($"Деталь с ID: {id} успешно удалена.");
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }
    }
}
