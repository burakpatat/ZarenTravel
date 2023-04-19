using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Tabs
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;

        [JsonPropertyName("itemClass")]
        public string ItemClass;

        [JsonPropertyName("itemLinkClass")]
        public string ItemLinkClass;
    }

}