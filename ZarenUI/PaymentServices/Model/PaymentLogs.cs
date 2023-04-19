using System;
using System.Text.Json.Serialization;
using Core.Entities;
using Dapper.Contrib.Extensions;

namespace Model.Concrete;

[Table("PaymentLogs")]
public class PaymentLogs : IEntity
{
	private int _Id;

	private int? _TransactionId;

	private string _Request;

	private DateTime? _RequestDate;

	private string _Response;

	private DateTime? _ResponseDate;

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

	[JsonPropertyName("request")]
	public string Request
	{
		get
		{
			return _Request;
		}
		set
		{
			_Request = value;
		}
	}

	[JsonPropertyName("requestdate")]
	public DateTime? RequestDate
	{
		get
		{
			return _RequestDate;
		}
		set
		{
			_RequestDate = value;
		}
	}

	[JsonPropertyName("response")]
	public string Response
	{
		get
		{
			return _Response;
		}
		set
		{
			_Response = value;
		}
	}

	[JsonPropertyName("responsedate")]
	public DateTime? ResponseDate
	{
		get
		{
			return _ResponseDate;
		}
		set
		{
			_ResponseDate = value;
		}
	}
}
