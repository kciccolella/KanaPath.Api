using Microsoft.AspNetCore.Mvc;
using KanaPath.Api.Models;

namespace KanaPath.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KanaController : ControllerBase
{
    [HttpGet]
    public Kana Get()
    {
        var kanaList = GetKanaList();
        return GetRandomKana(kanaList);
    }

    private List<Kana> GetKanaList()
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

    private Kana GetRandomKana(List<Kana> kanaList)
    {
        var random = new Random();
        var index = random.Next(kanaList.Count);
        return kanaList[index];
    }
}
