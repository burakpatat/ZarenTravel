using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities.Security
{
    public class SecurityRequestModel
    {
        [JsonPropertyName("password")]
        public string ApiKey { get; set; } = "kU8@iP3@";

        [JsonPropertyName("email")]
        public string Email { get; set; } = "murat.karayilan@dotto.com.tr";

        [JsonPropertyName("lang")]
        public string Lang { get; set; } = "TR";

 
    }
 


}
