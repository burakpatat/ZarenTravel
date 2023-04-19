using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class TopMenu
    {
        [JsonPropertyName("class")]
        public string Class;
    }

}