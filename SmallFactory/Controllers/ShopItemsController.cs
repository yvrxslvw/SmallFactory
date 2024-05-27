using Microsoft.AspNetCore.Mvc;

namespace SmallFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("get all shop items");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok($"get {id} shop item");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok("create shop item");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok($"update {id} shop item");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok($"delete {id} shop item");
        }
    }
}
