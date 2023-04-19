using System.Text.Json.Serialization;

public class Campaign
{
	[JsonPropertyName("text")]
	public string Text { get; set; }

	[JsonPropertyName("value")]
	public string Value { get; set; }
}
