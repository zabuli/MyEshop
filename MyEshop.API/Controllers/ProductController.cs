using Microsoft.AspNetCore.Mvc;

namespace MyEshop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome!");
        }
    }
}
