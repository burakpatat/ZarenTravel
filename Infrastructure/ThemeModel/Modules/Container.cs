using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Container
    {
        [JsonPropertyName("class")]
        public string Class;
    }

}