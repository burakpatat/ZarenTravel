using System.Text.Json.Serialization; 
namespace Builder{ 

    public class Medium
    {
        [JsonPropertyName("marginTop")]
        public string MarginTop;

        [JsonPropertyName("textAlign")]
        public string TextAlign;

        [JsonPropertyName("marginLeft")]
        public string MarginLeft;

        [JsonPropertyName("marginRight")]
        public string MarginRight;
    }

}