using System.Text.Json.Serialization;
using Core.Entities;

public class Connections : IEntity
{

    [JsonPropertyName("UserId")]
    public string UserId;

    [JsonPropertyName("Password")]
    public string Password;

    [JsonPropertyName("Server")]
    public string Server;

    [JsonPropertyName("DataSource")]
    public string DataSource;

    [JsonPropertyName("InitialCatalog")]
    public string InitialCatalog;

    [JsonPropertyName("Database")]
    public string Database;

    [JsonPropertyName("ConnectionString")]
    public string ConnectionString;

    [JsonPropertyName("IsActive")]
    public bool IsActive;

    [JsonPropertyName("JsonSource")]
    public string JsonSource;

    [JsonPropertyName("ServerlessApp")]
    public bool ServerlessApp;
}
