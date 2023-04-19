using System;
using System.Text.Json.Serialization; 
using Dapper.Contrib.Extensions;
using Core.Entities;

namespace Model.Concrete;

[Table("Transactions")]
public class Transactions : IEntity
{
	private int _Id;

	private string _IdGuid;

	private DateTime? _CreatedDate;

	private decimal? _TotalAmount;

	private string _UserId;

	private bool? _IsSuccess;

	private string _NameSurname;

	private string _Language;

	private bool? _Is3D;

	private int? _Currency;

	private string _Email;

	private string _Phone;

	private string _Address;

	private string _BillingAddress;

	private string _City;

	private string _Provience;

	private string _CompanyName;

	private bool? _HasKvkkPermission;

	private bool? _HasPrivacy;

	private int? _PaymentConfigurationId;

	public string PaymentUrl;

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

	[JsonPropertyName("idguid")]
	public string IdGuid
	{
		get
		{
			return _IdGuid;
		}
		set
		{
			_IdGuid = value;
		}
	}

	[JsonPropertyName("createddate")]
	public DateTime? CreatedDate
	{
		get
		{
			return _CreatedDate;
		}
		set
		{
			_CreatedDate = value;
		}
	}

	[JsonPropertyName("totalamount")]
	public decimal? TotalAmount
	{
		get
		{
			return _TotalAmount;
		}
		set
		{
			_TotalAmount = value;
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

	[JsonPropertyName("issuccess")]
	public bool? IsSuccess
	{
		get
		{
			return _IsSuccess;
		}
		set
		{
			_IsSuccess = value;
		}
	}

	[JsonPropertyName("namesurname")]
	public string NameSurname
	{
		get
		{
			return _NameSurname;
		}
		set
		{
			_NameSurname = value;
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

	[JsonPropertyName("is3d")]
	public bool? Is3D
	{
		get
		{
			return _Is3D;
		}
		set
		{
			_Is3D = value;
		}
	}

	[JsonPropertyName("currency")]
	public int? Currency
	{
		get
		{
			return _Currency;
		}
		set
		{
			_Currency = value;
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

	[JsonPropertyName("phone")]
	public string Phone
	{
		get
		{
			return _Phone;
		}
		set
		{
			_Phone = value;
		}
	}

	[JsonPropertyName("address")]
	public string Address
	{
		get
		{
			return _Address;
		}
		set
		{
			_Address = value;
		}
	}

	[JsonPropertyName("billingaddress")]
	public string BillingAddress
	{
		get
		{
			return _BillingAddress;
		}
		set
		{
			_BillingAddress = value;
		}
	}

	[JsonPropertyName("city")]
	public string City
	{
		get
		{
			return _City;
		}
		set
		{
			_City = value;
		}
	}

	[JsonPropertyName("provience")]
	public string Provience
	{
		get
		{
			return _Provience;
		}
		set
		{
			_Provience = value;
		}
	}

	[JsonPropertyName("companyname")]
	public string CompanyName
	{
		get
		{
			return _CompanyName;
		}
		set
		{
			_CompanyName = value;
		}
	}

	[JsonPropertyName("haskvkkpermission")]
	public bool? HasKvkkPermission
	{
		get
		{
			return _HasKvkkPermission;
		}
		set
		{
			_HasKvkkPermission = value;
		}
	}

	[JsonPropertyName("hasprivacy")]
	public bool? HasPrivacy
	{
		get
		{
			return _HasPrivacy;
		}
		set
		{
			_HasPrivacy = value;
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
}
