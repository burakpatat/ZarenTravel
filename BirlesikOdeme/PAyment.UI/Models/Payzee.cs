

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Payzee
{
    public string password { get; set; }
    public string lang { get; set; }
    public string email { get; set; }
}

 



public class Result
{
    [JsonPropertyName("userId")]
    public long UserId { get; set; }

    [JsonPropertyName("token")]
    public string Token { get; set; }
}

public class PayzeeResponse
{
    [JsonPropertyName("fail")]
    public bool Fail { get; set; }

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("result")]
    public Result Result { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("errorCode")]
    public object ErrorCode { get; set; }

    [JsonPropertyName("errorDescription")]
    public object ErrorDescription { get; set; }
}
