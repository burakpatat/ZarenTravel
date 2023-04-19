using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace ThemeGenerator{ 

    public class ThemePanel
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("toggleAttr")]
        public string ToggleAttr;

        [JsonPropertyName("cookieName")]
        public string CookieName;

        [JsonPropertyName("activeClass")]
        public string ActiveClass;

        [JsonPropertyName("themeListCLass")]
        public string ThemeListCLass;

        [JsonPropertyName("themeListItemCLass")]
        public string ThemeListItemCLass;

        [JsonPropertyName("themeCoverClass")]
        public string ThemeCoverClass;

        [JsonPropertyName("themeCoverItemClass")]
        public string ThemeCoverItemClass;

        [JsonPropertyName("theme")]
        public Theme Theme;

        [JsonPropertyName("themeCover")]
        public ThemeCover ThemeCover;
    }

}