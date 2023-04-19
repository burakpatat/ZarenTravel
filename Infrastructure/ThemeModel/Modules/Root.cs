using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Root
    {
        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("isMobile")]
        public string IsMobile;

        [JsonPropertyName("bootstrap")]
        public Bootstrap Bootstrap;

        [JsonPropertyName("header")]
        public Header Header;

        [JsonPropertyName("sidebar")]
        public Sidebar Sidebar;

        [JsonPropertyName("scrollBar")]
        public ScrollBar ScrollBar;

        [JsonPropertyName("content")]
        public Content Content;

        [JsonPropertyName("layout")]
        public Layout Layout;

        [JsonPropertyName("scrollToTopBtn")]
        public ScrollToTopBtn ScrollToTopBtn;

        [JsonPropertyName("scrollTo")]
        public ScrollTo ScrollTo;

        [JsonPropertyName("themePanel")]
        public ThemePanel ThemePanel;

        [JsonPropertyName("dismissClass")]
        public DismissClass DismissClass;

        [JsonPropertyName("toggleClass")]
        public ToggleClass ToggleClass;

        [JsonPropertyName("font")]
        public Font Font;

        [JsonPropertyName("color")]
        public Color Color;

        [JsonPropertyName("card")]
        public Card Card;

        [JsonPropertyName("init")]
        public Init Init;
    }

}