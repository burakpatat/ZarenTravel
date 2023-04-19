using System.Text.Json.Serialization; 
namespace Builder{ 

    public class Meta
    {
        [JsonPropertyName("hasLinks")]
        public bool HasLinks;

        [JsonPropertyName("kind")]
        public string Kind;

        [JsonPropertyName("needsHydration")]
        public bool NeedsHydration;
    }

}