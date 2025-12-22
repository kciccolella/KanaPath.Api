using Microsoft.AspNetCore.Mvc;
using KanaPath.Api.Models;

namespace KanaPath.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KanaController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Kana>> Get([FromQuery] string? row = null, [FromQuery] string? group = "main", [FromQuery] int count = 1)
    {
        var allKana = GetKanaList();

        group = string.IsNullOrWhiteSpace(group) ? "main" : group.Trim().ToLowerInvariant();

        var allowedGroups = new HashSet<string> { "main", "dakuten", "combo", "all" };
        if (!allowedGroups.Contains(group))
            return BadRequest(new { message = $"Unknown group '{group}'. Try: main, dakuten, combo, all." });

        var filtered = allKana;

        // Group filter (B behavior: default main)
        if (group != "all")
            filtered = filtered.Where(k => k.Group.Equals(group, StringComparison.OrdinalIgnoreCase)).ToList();

        // Row filter
        if (!string.IsNullOrWhiteSpace(row))
            filtered = filtered.Where(k => k.Row.Equals(row, StringComparison.OrdinalIgnoreCase)).ToList();

        // If row doesn't exist, return a helpful 400
        if (filtered.Count == 0)
            return BadRequest(new { message = "No kana matched the selected filters." });

        // Normalize count
        if (count < 1) count = 1;
        if (count > filtered.Count) count = filtered.Count;

        // Return unique random selection
        var result = filtered
            .OrderBy(_ => Random.Shared.Next())
            .Take(count)
            .ToList();


        return Ok(result);
    }

    private List<Kana> GetKanaList()
    {
        return new List<Kana>
        {
            new() { Symbol = "あ", Romaji = "a", Row = "a", Group = "main" },
            new() { Symbol = "い", Romaji = "i", Row = "a", Group = "main" },
            new() { Symbol = "う", Romaji = "u", Row = "a", Group = "main" },
            new() { Symbol = "え", Romaji = "e", Row = "a", Group = "main" },
            new() { Symbol = "お", Romaji = "o", Row = "a", Group = "main" },

            new() { Symbol = "ら", Romaji = "ra", Row = "ra", Group = "main" },
            new() { Symbol = "り", Romaji = "ri", Row = "ra", Group = "main" },
            new() { Symbol = "る", Romaji = "ru", Row = "ra", Group = "main" },
            new() { Symbol = "れ", Romaji = "re", Row = "ra", Group = "main" },
            new() { Symbol = "ろ", Romaji = "ro", Row = "ra", Group = "main" },

            new Kana { Symbol = "が", Romaji = "ga", Row = "ka", Group = "dakuten" },
            new Kana { Symbol = "ぎ", Romaji = "gi", Row = "ka", Group = "dakuten" },
            new Kana { Symbol = "ぐ", Romaji = "gu", Row = "ka", Group = "dakuten" },
            new Kana { Symbol = "げ", Romaji = "ge", Row = "ka", Group = "dakuten" },
            new Kana { Symbol = "ご", Romaji = "go", Row = "ka", Group = "dakuten" },

        };
    }
}
