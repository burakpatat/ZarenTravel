using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class BoxedLayout
    {
        [JsonPropertyName("class")]
        public string Class;
    }

}