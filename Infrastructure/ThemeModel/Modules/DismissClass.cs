using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class DismissClass
    {
        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("targetAttr")]
        public string TargetAttr;
    }

}