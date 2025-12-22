using Microsoft.AspNetCore.Mvc;
using KanaPath.Api.Models;

namespace KanaPath.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KanaController : ControllerBase
{
    [HttpGet]
    public IEnumerable<Kana> Get()
    {
        return new List<Kana>
        {
            new() { Symbol = "あ", Romaji = "a" },
            new() { Symbol = "い", Romaji = "i" },
            new() { Symbol = "う", Romaji = "u" },
            new() { Symbol = "え", Romaji = "e" },
            new() { Symbol = "お", Romaji = "o" }
        };
    }
}
