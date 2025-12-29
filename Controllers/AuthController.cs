using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KanaPath.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }
    }
}
