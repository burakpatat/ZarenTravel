using System.Text.Json.Serialization; 
namespace Builder{ 

    public class Component
    {
        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("options")]
        public Options Options;
    }

}