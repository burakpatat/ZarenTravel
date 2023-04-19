using System.Text.Json.Serialization;
using Core.Entities;
using Dapper.Contrib.Extensions;

namespace Model.Concrete;

[Table("TestCards")]
public class TestCards : IEntity
{
	private int _Id;

	private int? _PaymentConfigurationId;

	private string _BankName;

	private string _CardNo;

	private string _ValidDate;

	private string _CVV;

	private string _ThreeDPassword;

	private string _CardType;

	private string _CardScheme;

	private string _ResponseType;

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

	[JsonPropertyName("paymentconfigurationid")]
	public int? PaymentConfigurationId
	{
		get
		{
			return _PaymentConfigurationId;
		}
		set
		{
			_PaymentConfigurationId = value;
		}
	}

	[JsonPropertyName("bankname")]
	public string BankName
	{
		get
		{
			return _BankName;
		}
		set
		{
			_BankName = value;
		}
	}

	[JsonPropertyName("cardno")]
	public string CardNo
	{
		get
		{
			return _CardNo;
		}
		set
		{
			_CardNo = value;
		}
	}

	[JsonPropertyName("validdate")]
	public string ValidDate
	{
		get
		{
			return _ValidDate;
		}
		set
		{
			_ValidDate = value;
		}
	}

	[JsonPropertyName("cvv")]
	public string CVV
	{
		get
		{
			return _CVV;
		}
		set
		{
			_CVV = value;
		}
	}

	[JsonPropertyName("threedpassword")]
	public string ThreeDPassword
	{
		get
		{
			return _ThreeDPassword;
		}
		set
		{
			_ThreeDPassword = value;
		}
	}

	[JsonPropertyName("cardtype")]
	public string CardType
	{
		get
		{
			return _CardType;
		}
		set
		{
			_CardType = value;
		}
	}

	[JsonPropertyName("cardscheme")]
	public string CardScheme
	{
		get
		{
			return _CardScheme;
		}
		set
		{
			_CardScheme = value;
		}
	}

	[JsonPropertyName("responsetype")]
	public string ResponseType
	{
		get
		{
			return _ResponseType;
		}
		set
		{
			_ResponseType = value;
		}
	}
}
