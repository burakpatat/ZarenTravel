using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class ToggleClass
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("targetAttr")]
        public string TargetAttr;
    }

}