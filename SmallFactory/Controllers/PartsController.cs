using Microsoft.AspNetCore.Mvc;

namespace SmallFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("get all parts");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok($"get {id} part");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok("create part");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok($"update {id} part");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok($"delete {id} part");
        }
    }
}
