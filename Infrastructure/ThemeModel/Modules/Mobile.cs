using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Mobile
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("dismissAttr")]
        public string DismissAttr;

        [JsonPropertyName("toggledClass")]
        public string ToggledClass;

        [JsonPropertyName("closedClass")]
        public string ClosedClass;

        [JsonPropertyName("backdrop")]
        public Backdrop Backdrop;
    }

}