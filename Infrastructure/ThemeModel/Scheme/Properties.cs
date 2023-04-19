using System.Text.Json.Serialization; 
namespace Builder{ 

    public class Properties
    {
        [JsonPropertyName("src")]
        public string Src;

        [JsonPropertyName("role")]
        public string Role;

        [JsonPropertyName("width")]
        public string Width;

        [JsonPropertyName("height")]
        public string Height;
    }

}