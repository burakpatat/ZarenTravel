using System.Text.Json.Serialization; 
namespace Builder{ 

    public class Author
    {
        [JsonPropertyName("@type")]
        public string Type;

        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("model")]
        public string Model;
    }

}