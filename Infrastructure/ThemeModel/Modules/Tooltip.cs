using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Tooltip
    {
        [JsonPropertyName("attr")]
        public string Attr;
    }

}