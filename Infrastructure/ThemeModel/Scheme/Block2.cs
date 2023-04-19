using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace Builder
{

    public class Block2
    {
        [JsonPropertyName("@type")]
        public string Type;

        [JsonPropertyName("@version")]
        public int Version;

        [JsonPropertyName("layerName")]
        public string LayerName;

        [JsonPropertyName("id")]
        public string Id;

        [JsonPropertyName("children")]
        public List<Child2> Children;

        [JsonPropertyName("responsiveStyles")]
        public ResponsiveStyles ResponsiveStyles;

        [JsonPropertyName("component")]
        public Component Component;

        [JsonPropertyName("tagName")]
        public string TagName;

        [JsonPropertyName("properties")]
        public Properties Properties;
    }

}