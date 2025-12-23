using Microsoft.AspNetCore.Mvc;
using KanaPath.Api.Models;

namespace KanaPath.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KanaController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Kana>> Get([FromQuery] string? row = null, [FromQuery] string? group = null, [FromQuery] int count = 1)
    {
        var allKana = GetKanaList();

        group = string.IsNullOrWhiteSpace(group) ? null : group.Trim().ToLowerInvariant();

        if (group == null && string.IsNullOrWhiteSpace(row))
        {
            return BadRequest(new
            {
                message = "You must specify at least one filter (row or group)."
            });
        }

        var allowedGroups = new HashSet<string> { "main", "dakuten", "combo", "all" };

        if (group != null && !allowedGroups.Contains(group))
        {
            return BadRequest(new
            {
                message = $"Unknown group '{group}'. Try: main, dakuten, combo, all."
            });
        }


        var filtered = allKana;

        // Group filter (B behavior: default main)
        if (group != null && group != "all")
        {
            filtered = filtered
                .Where(k => k.Group.Equals(group, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

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
        var kanaData = new Dictionary<string, List<Kana>>
    {
        { "a", new List<Kana>
            {
                new Kana { Symbol = "あ", Romaji = "a", Row = "a", Group = "main" },
                new Kana { Symbol = "い", Romaji = "i", Row = "a", Group = "main" },
                new Kana { Symbol = "う", Romaji = "u", Row = "a", Group = "main" },
                new Kana { Symbol = "え", Romaji = "e", Row = "a", Group = "main" },
                new Kana { Symbol = "お", Romaji = "o", Row = "a", Group = "main" }
            }
        },
        { "ra", new List<Kana>
            {
                new Kana { Symbol = "ら", Romaji = "ra", Row = "ra", Group = "main" },
                new Kana { Symbol = "り", Romaji = "ri", Row = "ra", Group = "main" },
                new Kana { Symbol = "る", Romaji = "ru", Row = "ra", Group = "main" },
                new Kana { Symbol = "れ", Romaji = "re", Row = "ra", Group = "main" },
                new Kana { Symbol = "ろ", Romaji = "ro", Row = "ra", Group = "main" }
            }
        },
        { "ka", new List<Kana>
            {
                new Kana { Symbol = "が", Romaji = "ga", Row = "ka", Group = "dakuten" },
                new Kana { Symbol = "ぎ", Romaji = "gi", Row = "ka", Group = "dakuten" },
                new Kana { Symbol = "ぐ", Romaji = "gu", Row = "ka", Group = "dakuten" },
                new Kana { Symbol = "げ", Romaji = "ge", Row = "ka", Group = "dakuten" },
                new Kana { Symbol = "ご", Romaji = "go", Row = "ka", Group = "dakuten" }
            }
        },
        { "ta", new List<Kana>
            {
                new Kana { Symbol = "た", Romaji = "ta", Row = "ta", Group = "main" },
                new Kana { Symbol = "ち", Romaji = "chi", Row = "ta", Group = "main" },
                new Kana { Symbol = "つ", Romaji = "tsu", Row = "ta", Group = "main" },
                new Kana { Symbol = "て", Romaji = "te", Row = "ta", Group = "main" },
                new Kana { Symbol = "と", Romaji = "to", Row = "ta", Group = "main" }
            }
        }
    };

        return kanaData.Values.SelectMany(k => k).ToList();
    }

}
