using Microsoft.AspNetCore.Mvc;
using KanaPath.Api.Models;

namespace KanaPath.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KanaController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Kana>> Get([FromQuery] string? row = null, [FromQuery] int count = 1)
    {
        var allKana = GetKanaList();

        // Filter by row if provided
        var filtered = string.IsNullOrWhiteSpace(row)
            ? allKana
            : allKana.Where(k => string.Equals(k.Row, row, StringComparison.OrdinalIgnoreCase)).ToList();

        // If row doesn't exist, return a helpful 400
        if (filtered.Count == 0)
            return BadRequest(new { message = $"Unknown row '{row}'. Try: a, ka, sa, ta, na, ha, ma, ya, ra, wa (once added)." });

        // Normalize count
        if (count < 1) count = 1;
        if (count > filtered.Count) count = filtered.Count;

        // Return unique random selection
        var random = new Random();
        var result = filtered
            .OrderBy(_ => random.Next())
            .Take(count)
            .ToList();

        return Ok(result);
    }

    private List<Kana> GetKanaList()
    {
        return new List<Kana>
        {
            new() { Symbol = "あ", Romaji = "a", Row = "a" },
            new() { Symbol = "い", Romaji = "i", Row = "a" },
            new() { Symbol = "う", Romaji = "u", Row = "a" },
            new() { Symbol = "え", Romaji = "e", Row = "a" },
            new() { Symbol = "お", Romaji = "o", Row = "a" },

            new() { Symbol = "ら", Romaji = "ra", Row = "ra" },
            new() { Symbol = "り", Romaji = "ri", Row = "ra" },
            new() { Symbol = "る", Romaji = "ru", Row = "ra" },
            new() { Symbol = "れ", Romaji = "re", Row = "ra" },
            new() { Symbol = "ろ", Romaji = "ro", Row = "ra" },

        };
    }

    private Kana GetRandomKana(List<Kana> kanaList)
    {
        var random = new Random();
        var index = random.Next(kanaList.Count);
        return kanaList[index];
    }
}
