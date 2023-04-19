using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class ScrollTo
    {
        [JsonPropertyName("attr")]
        public string Attr;

        [JsonPropertyName("target")]
        public string Target;

        [JsonPropertyName("linkTarget")]
        public string LinkTarget;
    }

}