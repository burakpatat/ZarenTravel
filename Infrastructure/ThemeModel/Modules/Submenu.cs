using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Submenu
    {
        [JsonPropertyName("class")]
        public string Class;
    }

}