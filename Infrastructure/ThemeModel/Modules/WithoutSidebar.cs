using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class WithoutSidebar
    {
        [JsonPropertyName("class")]
        public string Class;
    }

}