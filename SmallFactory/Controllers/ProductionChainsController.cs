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
    public class ProductionChainsController(IProductionChainsRepository productionChainsRepository, IMapper mapper) : ControllerBase
    {
        private readonly IProductionChainsRepository _productionChainsRepository = productionChainsRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<ProductionChain> productionChains = (await _productionChainsRepository.GetProductionChainsAsync()).ToList();
                return Ok(_mapper.Map<List<ProductionChainDto>>(productionChains));
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
                ProductionChain productionChain = await _productionChainsRepository.GetProductionChainByIdAsync(id);
                return Ok(_mapper.Map<ProductionChainDto>(productionChain));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductionChainDto createProductionChainDto)
        {
            try
            {
                ProductionChain productionChain = await _productionChainsRepository.CreateProductionChainAsync(createProductionChainDto);
                return Ok(_mapper.Map<ProductionChainDto>(productionChain));
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductionChainDto updateProductionChainDto)
        {
            try
            {
                ProductionChain productionChain = await _productionChainsRepository.UpdateProductionChainAsync(id, updateProductionChainDto);
                return Ok(_mapper.Map<ProductionChainDto>(productionChain));
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
                await _productionChainsRepository.DeleteProductionChainAsync(id);
                return Ok($"Производственная цепочка с ID: {id} успешно удалена.");
            }
            catch (ApiException exc)
            {
                return StatusCode(exc.Code, exc.Message);
            }
        }
    }
}
