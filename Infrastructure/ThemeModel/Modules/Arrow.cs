using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Arrow
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;
    }

}