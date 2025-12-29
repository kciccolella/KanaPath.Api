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
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest("Email and password are required.");
            }

            return Ok();
        }
    }
}
