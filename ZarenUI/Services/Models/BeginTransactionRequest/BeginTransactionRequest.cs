using MongoDB.Bson;
using Newtonsoft.Json;

namespace SanTsgHotelBooking.Application.Models.BeginTransactionRequest
{
    public class BeginTransactionRequest
    {
        public List<string> offerIds { get; set; } = null!;
        public string currency { get; set; } = "EUR";
        public string culture { get; set; } = "en-US";
    }
}
namespace GetTransactionStatus
{
	public class Request
	{
		 
		[JsonProperty("transactionId")]
		public string TransactionId { get; set; }
	}
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class Body
	{
		[JsonProperty("processStatus")]
		public int ProcessStatus { get; set; }

		[JsonProperty("status")]
		public int Status { get; set; }

		[JsonProperty("transactionType")]
		public int TransactionType { get; set; }
	}

	public class Header
	{
		[JsonProperty("requestId")]
		public string RequestId { get; set; }

		[JsonProperty("success")]
		public bool Success { get; set; }

		[JsonProperty("responseTime")]
		public DateTime ResponseTime { get; set; }

		[JsonProperty("messages")]
		public List<Message> Messages { get; set; }
	}

	public class Message
	{
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("messageType")]
		public int MessageType { get; set; }

		[JsonProperty("message")]
		public string Messages { get; set; }
	}

	public class Root
	{
	 


		[JsonProperty("body")]
		public Body Body { get; set; }

		[JsonProperty("header")]
		public Header Header { get; set; }
	}


}