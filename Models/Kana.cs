namespace KanaPath.Api.Models
{
    public class Kana
    {
        public string Symbol { get; set; } = "";
        public string Romaji { get; set; } = "";
        public string Row { get; set; } = "";
        public string Group { get; set; } = "main"; // main | dakuten | combo
    }
}
