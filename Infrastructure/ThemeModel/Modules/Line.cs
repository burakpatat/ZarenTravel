using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Line
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;
    }

}