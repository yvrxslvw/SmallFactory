using Microsoft.AspNetCore.Mvc;

namespace SmallFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionChainsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("get all production chains");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok($"get {id} production chain");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok("create production chain");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok($"update {id} production chain");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok($"delete {id} production chain");
        }
    }
}
