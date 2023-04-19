using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

public class PayzeeAuthRequest
{
    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("lang")]
    public string Lang { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
}
