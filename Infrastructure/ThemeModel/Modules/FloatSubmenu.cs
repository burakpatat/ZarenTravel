using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class FloatSubmenu
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("dom")]
        public string Dom;

        [JsonPropertyName("timeout")]
        public string Timeout;

        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("container")]
        public Container Container;

        [JsonPropertyName("arrow")]
        public Arrow Arrow;

        [JsonPropertyName("line")]
        public Line Line;

        [JsonPropertyName("overflow")]
        public Overflow Overflow;
    }

}