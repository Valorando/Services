using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MainService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        // GET: api/HelloWorld
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, World!");
        }
    }
}
