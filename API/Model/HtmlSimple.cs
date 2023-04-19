using System.Collections.Generic;
using System.Text.Json.Serialization;

// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
public class Attribute
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class Child
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("tagName")]
    public string TagName { get; set; }

    [JsonPropertyName("attributes")]
    public List<object> Attributes { get; set; }

    [JsonPropertyName("children")]
    public List<Child> Children { get; set; }

    [JsonPropertyName("position")]
    public Position Position { get; set; }

    [JsonPropertyName("content")]
    public string Content { get; set; }
}

public class End
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("line")]
    public int Line { get; set; }

    [JsonPropertyName("column")]
    public int Column { get; set; }
}

public class Position
{
    [JsonPropertyName("start")]
    public Start Start { get; set; }

    [JsonPropertyName("end")]
    public End End { get; set; }
}

public class HtmlSimple
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("tagName")]
    public string TagName { get; set; }

    [JsonPropertyName("attributes")]
    public List<Attribute> Attributes { get; set; }

    [JsonPropertyName("children")]
    public List<Child> Children { get; set; }

    [JsonPropertyName("position")]
    public Position Position { get; set; }
}

public class Start
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("line")]
    public int Line { get; set; }

    [JsonPropertyName("column")]
    public int Column { get; set; }
}

