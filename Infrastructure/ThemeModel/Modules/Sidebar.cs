using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Sidebar
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("scrollBar")]
        public ScrollBar ScrollBar;

        [JsonPropertyName("menu")]
        public Menu Menu;

        [JsonPropertyName("mobile")]
        public Mobile Mobile;

        [JsonPropertyName("minify")]
        public Minify Minify;

        [JsonPropertyName("floatSubmenu")]
        public FloatSubmenu FloatSubmenu;

        [JsonPropertyName("search")]
        public Search Search;

        [JsonPropertyName("transparent")]
        public Transparent Transparent;
    }

}