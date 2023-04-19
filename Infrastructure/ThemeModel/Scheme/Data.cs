using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace Builder{ 

    public class Data
    {
        [JsonPropertyName("author")]
        public Author Author;

        [JsonPropertyName("image")]
        public string Image;

        [JsonPropertyName("inputs")]
        public List<object> Inputs;

        [JsonPropertyName("intro")]
        public string Intro;

        [JsonPropertyName("slug")]
        public string Slug;

        [JsonPropertyName("title")]
        public string Title;

        [JsonPropertyName("blocks")]
        public List<Block2> Blocks;

        [JsonPropertyName("state")]
        public State State;
    }

}