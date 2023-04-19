using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paximum.Enums
{

    public class Types
    {
        [JsonProperty("TypeItems")]
        public List<TypeItem> TypeItems { get; set; }
    }

    public class TypeItem
    {
        [JsonProperty("Value")]
        public int Value { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }


}
