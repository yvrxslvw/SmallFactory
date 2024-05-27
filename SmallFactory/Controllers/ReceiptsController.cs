using Microsoft.AspNetCore.Mvc;

namespace SmallFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("get all receipts");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok($"get {id} receipt");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok("create receipt");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok($"update {id} receipt");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok($"delete {id} receipt");
        }
    }
}
