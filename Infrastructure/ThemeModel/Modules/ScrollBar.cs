using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class ScrollBar
    {
        [JsonPropertyName("localStorage")]
        public string LocalStorage;

        [JsonPropertyName("dom")]
        public string Dom;

        [JsonPropertyName("attr")]
        public string Attr;

        [JsonPropertyName("skipMobileAttr")]
        public string SkipMobileAttr;

        [JsonPropertyName("heightAttr")]
        public string HeightAttr;

        [JsonPropertyName("wheelPropagationAttr")]
        public string WheelPropagationAttr;
    }

}