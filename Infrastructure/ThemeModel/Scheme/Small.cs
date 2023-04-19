using System.Text.Json.Serialization; 
namespace Builder{ 

    public class Small
    {
        [JsonPropertyName("fontSize")]
        public string FontSize;
    }

}