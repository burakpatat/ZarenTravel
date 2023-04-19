using System.Text.Json.Serialization; 
namespace Builder{ 

    public class Location
    {
        [JsonPropertyName("path")]
        public string Path;

        [JsonPropertyName("query")]
        public Query Query;
    }

}