using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class WithoutHeader
    {
        [JsonPropertyName("class")]
        public string Class;
    }

}