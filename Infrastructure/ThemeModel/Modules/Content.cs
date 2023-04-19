using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Content
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("fullHeight")]
        public FullHeight FullHeight;

        [JsonPropertyName("fullWidth")]
        public FullWidth FullWidth;
    }

}