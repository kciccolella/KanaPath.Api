using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using KanaPath.Api.Models;

namespace KanaPath.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            return Ok();
        }
    }
}
