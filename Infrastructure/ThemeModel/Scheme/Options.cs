using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Builder{ 

    public class Options
    {
        [JsonPropertyName("maxWidth")]
        public int MaxWidth;

        [JsonPropertyName("text")]
        public string Text;

        [JsonPropertyName("image")]
        public string Image;

        [JsonPropertyName("backgroundPosition")]
        public string BackgroundPosition;

        [JsonPropertyName("backgroundSize")]
        public string BackgroundSize;

        [JsonPropertyName("aspectRatio")]
        public double AspectRatio;

        [JsonPropertyName("columns")]
        public List<Column> Columns;

        [JsonPropertyName("space")]
        public int Space;

        [JsonPropertyName("stackColumnsAt")]
        public string StackColumnsAt;

        [JsonPropertyName("reverseColumnsWhenStacked")]
        public bool ReverseColumnsWhenStacked;
    }

}