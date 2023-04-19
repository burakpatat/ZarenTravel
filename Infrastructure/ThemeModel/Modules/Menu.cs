using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Menu
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("initAttr")]
        public string InitAttr;

        [JsonPropertyName("animationTime")]
        public int AnimationTime;

        [JsonPropertyName("itemClass")]
        public string ItemClass;

        [JsonPropertyName("itemLinkClass")]
        public string ItemLinkClass;

        [JsonPropertyName("hasSubClass")]
        public string HasSubClass;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;

        [JsonPropertyName("expandingClass")]
        public string ExpandingClass;

        [JsonPropertyName("expandClass")]
        public string ExpandClass;

        [JsonPropertyName("submenu")]
        public Submenu Submenu;
    }

}