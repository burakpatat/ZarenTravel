using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Backdrop
    {
        [JsonPropertyName("class")]
        public string Class;
    }

}