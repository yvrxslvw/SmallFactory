using Microsoft.AspNetCore.Mvc;

namespace SmallFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("get all factories");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok($"get {id} factory");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok("create factory");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok($"update {id} factory");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok($"delete {id} factory");
        }
    }
}
