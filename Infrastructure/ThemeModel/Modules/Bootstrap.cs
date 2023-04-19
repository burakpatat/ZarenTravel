using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Bootstrap
    {
        [JsonPropertyName("tooltip")]
        public Tooltip Tooltip;

        [JsonPropertyName("popover")]
        public Popover Popover;

        [JsonPropertyName("modal")]
        public Modal Modal;

        [JsonPropertyName("nav")]
        public Nav Nav;
    }

}