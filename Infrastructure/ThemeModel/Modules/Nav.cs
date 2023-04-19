using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Nav
    {
        [JsonPropertyName("class")]
        public string Class;

        [JsonPropertyName("tabs")]
        public Tabs Tabs;
    }

}