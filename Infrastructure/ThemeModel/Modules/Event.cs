using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Event
    {
        [JsonPropertyName("hidden")]
        public string Hidden;
    }

}