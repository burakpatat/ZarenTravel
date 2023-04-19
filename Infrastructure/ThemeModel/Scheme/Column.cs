using System.Text.Json.Serialization;
using System.Collections.Generic;
namespace Builder
{

    public class Column
    {
        [JsonPropertyName("blocks")]
        public List<Block2> Blocks;
    }

}