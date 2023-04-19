using System.Text.Json.Serialization; 
namespace Builder{ 

    public class State
    {
        [JsonPropertyName("deviceSize")]
        public string DeviceSize;

        [JsonPropertyName("location")]
        public Location Location;
    }

}