using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class ScrollToTopBtn
    {
        [JsonPropertyName("showClass")]
        public string ShowClass;

        [JsonPropertyName("heightShow")]
        public int HeightShow;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("scrollSpeed")]
        public int ScrollSpeed;
    }

}