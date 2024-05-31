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
    public class MachinesController(IMachinesRepository machinesRepository, IMapper mapper) : ControllerBase
    {
        private readonly IMachinesRepository _machinesRepository = machinesRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Machine> machines = (await _machinesRepository.GetMachinesAsync()).ToList();
                return Ok(_mapper.Map<List<MachineDto>>(machines));
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
                Machine machine = await _machinesRepository.GetMachineByIdAsync(id);
                return Ok(_mapper.Map<MachineDto>(machine));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMachineDto createMachineDto)
        {
            try
            {
                Machine machine = await _machinesRepository.CreateMachineAsync(createMachineDto);
                return Ok(_mapper.Map<MachineDto>(machine));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateMachineDto updateMachineDto)
        {
            try
            {
                Machine machine = await _machinesRepository.UpdateMachineAsync(id, updateMachineDto);
                return Ok(_mapper.Map<MachineDto>(machine));
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
                await _machinesRepository.DeleteMachineAsync(id);
                return Ok($"Станок с ID: {id} успешно удалён.");
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }
    }
}
