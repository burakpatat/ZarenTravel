using System.Text.Json.Serialization;

public class PaymentRequestModel
{
	[JsonPropertyName("insertCard")]
	public bool InsertCard { get; set; }

	[JsonPropertyName("use3D")]
	public bool Use3D { get; set; }

	[JsonPropertyName("merchantId")]
	public long MerchantId { get; set; }

	[JsonPropertyName("customerId")]
	public string CustomerId { get; set; }

	[JsonPropertyName("cardNumber")]
	public string CardNumber { get; set; }

	[JsonPropertyName("expiryDateMonth")]
	public string ExpiryDateMonth { get; set; }

	[JsonPropertyName("expiryDateYear")]
	public string ExpiryDateYear { get; set; }

	[JsonPropertyName("cvv")]
	public string Cvv { get; set; }

	[JsonPropertyName("secureDataId")]
	public int SecureDataId { get; set; }

	[JsonPropertyName("cardAlias")]
	public string CardAlias { get; set; }

	[JsonPropertyName("userCode")]
	public string UserCode { get; set; }

	[JsonPropertyName("txnType")]
	public string TxnType { get; set; }

	[JsonPropertyName("installmentCount")]
	public string InstallmentCount { get; set; }

	[JsonPropertyName("currency")]
	public string Currency { get; set; }

	[JsonPropertyName("okUrl")]
	public string OkUrl { get; set; }

	[JsonPropertyName("failUrl")]
	public string FailUrl { get; set; }

	[JsonPropertyName("orderId")]
	public string OrderId { get; set; }

	[JsonPropertyName("totalAmount")]
	public string TotalAmount { get; set; }

	[JsonPropertyName("pointAmount")]
	public string PointAmount { get; set; }

	[JsonPropertyName("rnd")]
	public string Rnd { get; set; }

	[JsonPropertyName("hash")]
	public string Hash { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonPropertyName("requestIp")]
	public string RequestIp { get; set; }

	[JsonPropertyName("cardHolderName")]
	public string CardHolderName { get; set; }

	[JsonPropertyName("extraData")]
	public string ExtraData { get; set; }

	[JsonPropertyName("campaign")]
	public Campaign Campaign { get; set; }

	[JsonPropertyName("billingInfo")]
	public BillingInfo BillingInfo { get; set; }

	[JsonPropertyName("deliveryInfo")]
	public DeliveryInfo DeliveryInfo { get; set; }

	[JsonPropertyName("memberId")]
	public int memberId { get; set; }

	[JsonPropertyName("maturityPeriod")]
	public string MaturityPeriod { get; set; }

	[JsonPropertyName("paymentFrequency")]
	public string PaymentFrequency { get; set; }
}
