using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Transactions")]
public class Transactions: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _IdGuid;
[JsonPropertyName("idguid")]
public string IdGuid
{
get { return _IdGuid; }
set { _IdGuid = value; }
}
private DateTime? _CreatedDate;
[JsonPropertyName("createddate")]
public DateTime? CreatedDate
{
get { return _CreatedDate; }
set { _CreatedDate = value; }
}
private decimal? _TotalAmount;
[JsonPropertyName("totalamount")]
public decimal? TotalAmount
{
get { return _TotalAmount; }
set { _TotalAmount = value; }
}
private string _UserId;
[JsonPropertyName("userid")]
public string UserId
{
get { return _UserId; }
set { _UserId = value; }
}
private bool? _IsSuccess;
[JsonPropertyName("issuccess")]
public bool? IsSuccess
{
get { return _IsSuccess; }
set { _IsSuccess = value; }
}
private string _NameSurname;
[JsonPropertyName("namesurname")]
public string NameSurname
{
get { return _NameSurname; }
set { _NameSurname = value; }
}
private string _Language;
[JsonPropertyName("language")]
public string Language
{
get { return _Language; }
set { _Language = value; }
}
private bool? _Is3D;
[JsonPropertyName("is3d")]
public bool? Is3D
{
get { return _Is3D; }
set { _Is3D = value; }
}
private int? _Currency;
[JsonPropertyName("currency")]
public int? Currency
{
get { return _Currency; }
set { _Currency = value; }
}
private string _Email;
[JsonPropertyName("email")]
public string Email
{
get { return _Email; }
set { _Email = value; }
}
private string _Phone;
[JsonPropertyName("phone")]
public string Phone
{
get { return _Phone; }
set { _Phone = value; }
}
private string _Address;
[JsonPropertyName("address")]
public string Address
{
get { return _Address; }
set { _Address = value; }
}
private string _BillingAddress;
[JsonPropertyName("billingaddress")]
public string BillingAddress
{
get { return _BillingAddress; }
set { _BillingAddress = value; }
}
private string _City;
[JsonPropertyName("city")]
public string City
{
get { return _City; }
set { _City = value; }
}
private string _Provience;
[JsonPropertyName("provience")]
public string Provience
{
get { return _Provience; }
set { _Provience = value; }
}
private string _CompanyName;
[JsonPropertyName("companyname")]
public string CompanyName
{
get { return _CompanyName; }
set { _CompanyName = value; }
}
private bool? _HasKvkkPermission;
[JsonPropertyName("haskvkkpermission")]
public bool? HasKvkkPermission
{
get { return _HasKvkkPermission; }
set { _HasKvkkPermission = value; }
}
private bool? _HasPrivacy;
[JsonPropertyName("hasprivacy")]
public bool? HasPrivacy
{
get { return _HasPrivacy; }
set { _HasPrivacy = value; }
}
private int? _PaymentConfigurationId;
[JsonPropertyName("paymentconfigurationid")]
public int? PaymentConfigurationId
{
get { return _PaymentConfigurationId; }
set { _PaymentConfigurationId = value; }
}
}
}
