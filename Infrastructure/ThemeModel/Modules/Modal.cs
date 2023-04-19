using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Modal
    {
        [JsonPropertyName("attr")]
        public string Attr;

        [JsonPropertyName("dismissAttr")]
        public string DismissAttr;

        [JsonPropertyName("event")]
        public Event Event;
    }

}