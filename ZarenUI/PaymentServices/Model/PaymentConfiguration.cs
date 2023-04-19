using System.Text.Json.Serialization;
using Core.Entities;
using Dapper.Contrib.Extensions;

namespace Model.Concrete;

[Table("PaymentConfiguration")]
public class PaymentConfiguration : IEntity
{
	private int _Id;

	private string _PaymentCompany;

	private string _Email;

	private string _Password;

	private string _Language;

	private string _TestSecurityUrl;

	private string _ProdSecurityUrl;

	private string _HashPassword;

	private string _OkUrl;

	private string _FailUrl;

	private string _UserId;

	private string _MemberId;

	private string _MerchantId;

	private string _UserCode;

	private string _TxnType;

	private string _TestPaymentUrl;

	private string _ProdPaymentUrl;

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

	[JsonPropertyName("paymentcompany")]
	public string PaymentCompany
	{
		get
		{
			return _PaymentCompany;
		}
		set
		{
			_PaymentCompany = value;
		}
	}

	[JsonPropertyName("email")]
	public string Email
	{
		get
		{
			return _Email;
		}
		set
		{
			_Email = value;
		}
	}

	[JsonPropertyName("password")]
	public string Password
	{
		get
		{
			return _Password;
		}
		set
		{
			_Password = value;
		}
	}

	[JsonPropertyName("language")]
	public string Language
	{
		get
		{
			return _Language;
		}
		set
		{
			_Language = value;
		}
	}

	[JsonPropertyName("testsecurityurl")]
	public string TestSecurityUrl
	{
		get
		{
			return _TestSecurityUrl;
		}
		set
		{
			_TestSecurityUrl = value;
		}
	}

	[JsonPropertyName("prodsecurityurl")]
	public string ProdSecurityUrl
	{
		get
		{
			return _ProdSecurityUrl;
		}
		set
		{
			_ProdSecurityUrl = value;
		}
	}

	[JsonPropertyName("hashpassword")]
	public string HashPassword
	{
		get
		{
			return _HashPassword;
		}
		set
		{
			_HashPassword = value;
		}
	}

	[JsonPropertyName("okurl")]
	public string OkUrl
	{
		get
		{
			return _OkUrl;
		}
		set
		{
			_OkUrl = value;
		}
	}

	[JsonPropertyName("failurl")]
	public string FailUrl
	{
		get
		{
			return _FailUrl;
		}
		set
		{
			_FailUrl = value;
		}
	}

	[JsonPropertyName("userid")]
	public string UserId
	{
		get
		{
			return _UserId;
		}
		set
		{
			_UserId = value;
		}
	}

	[JsonPropertyName("memberid")]
	public string MemberId
	{
		get
		{
			return _MemberId;
		}
		set
		{
			_MemberId = value;
		}
	}

	[JsonPropertyName("merchantid")]
	public string MerchantId
	{
		get
		{
			return _MerchantId;
		}
		set
		{
			_MerchantId = value;
		}
	}

	[JsonPropertyName("usercode")]
	public string UserCode
	{
		get
		{
			return _UserCode;
		}
		set
		{
			_UserCode = value;
		}
	}

	[JsonPropertyName("txntype")]
	public string TxnType
	{
		get
		{
			return _TxnType;
		}
		set
		{
			_TxnType = value;
		}
	}

	[JsonPropertyName("testpaymenturl")]
	public string TestPaymentUrl
	{
		get
		{
			return _TestPaymentUrl;
		}
		set
		{
			_TestPaymentUrl = value;
		}
	}

	[JsonPropertyName("prodpaymenturl")]
	public string ProdPaymentUrl
	{
		get
		{
			return _ProdPaymentUrl;
		}
		set
		{
			_ProdPaymentUrl = value;
		}
	}
}
