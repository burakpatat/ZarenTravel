using System.Text.Json.Serialization;

public class DeliveryInfo
{
	[JsonPropertyName("taxNo")]
	public string TaxNo { get; set; }

	[JsonPropertyName("taxOffice")]
	public string TaxOffice { get; set; }

	[JsonPropertyName("firmName")]
	public string FirmName { get; set; }

	[JsonPropertyName("identityNumber")]
	public string IdentityNumber { get; set; }

	[JsonPropertyName("fullName")]
	public string FullName { get; set; }

	[JsonPropertyName("email")]
	public string Email { get; set; }

	[JsonPropertyName("phone")]
	public string Phone { get; set; }

	[JsonPropertyName("address")]
	public string Address { get; set; }

	[JsonPropertyName("city")]
	public string City { get; set; }

	[JsonPropertyName("town")]
	public string Town { get; set; }

	[JsonPropertyName("zipCode")]
	public string ZipCode { get; set; }
}
