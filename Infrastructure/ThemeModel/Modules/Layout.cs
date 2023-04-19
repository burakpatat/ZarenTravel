using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Layout
    {
        [JsonPropertyName("sidebarLight")]
        public SidebarLight SidebarLight;

        [JsonPropertyName("sidebarEnd")]
        public SidebarEnd SidebarEnd;

        [JsonPropertyName("sidebarWide")]
        public SidebarWide SidebarWide;

        [JsonPropertyName("sidebarMinified")]
        public SidebarMinified SidebarMinified;

        [JsonPropertyName("sidebarTwo")]
        public SidebarTwo SidebarTwo;

        [JsonPropertyName("withoutHeader")]
        public WithoutHeader WithoutHeader;

        [JsonPropertyName("withoutSidebar")]
        public WithoutSidebar WithoutSidebar;

        [JsonPropertyName("topMenu")]
        public TopMenu TopMenu;

        [JsonPropertyName("boxedLayout")]
        public BoxedLayout BoxedLayout;
    }

}