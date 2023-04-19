using System.Text.Json.Serialization;
using Core.Entities;
using Dapper.Contrib.Extensions;

namespace Model.Concrete;

[Table("TransactionDetails")]
public class TransactionDetails : IEntity
{
	private int _Id;

	private int? _TransactionId;

	private string _UserAgent;

	private string _IP;

	private string _CardNumber;

	private string _CardHolderNameSurname;

	[Key]
	[JsonPropertyName("id")]
	public int Id
	{
		get
		{
			return _Id;
		}
		set
		{
			_Id = value;
		}
	}

	[JsonPropertyName("transactionid")]
	public int? TransactionId
	{
		get
		{
			return _TransactionId;
		}
		set
		{
			_TransactionId = value;
		}
	}

	[JsonPropertyName("useragent")]
	public string UserAgent
	{
		get
		{
			return _UserAgent;
		}
		set
		{
			_UserAgent = value;
		}
	}

	[JsonPropertyName("ip")]
	public string IP
	{
		get
		{
			return _IP;
		}
		set
		{
			_IP = value;
		}
	}

	[JsonPropertyName("cardnumber")]
	public string CardNumber
	{
		get
		{
			return _CardNumber;
		}
		set
		{
			_CardNumber = value;
		}
	}

	[JsonPropertyName("cardholdernamesurname")]
	public string CardHolderNameSurname
	{
		get
		{
			return _CardHolderNameSurname;
		}
		set
		{
			_CardHolderNameSurname = value;
		}
	}
}
