using System.Text.Json.Serialization; 
namespace ThemeGenerator{ 

    public class Card
    {
        [JsonPropertyName("expand")]
        public Expand Expand;
    }

}