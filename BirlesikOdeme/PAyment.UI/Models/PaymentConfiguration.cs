using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PaymentConfiguration")]
public class PaymentConfiguration: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _PaymentCompany;
[JsonPropertyName("paymentcompany")]
public string PaymentCompany
{
get { return _PaymentCompany; }
set { _PaymentCompany = value; }
}
private string _Email;
[JsonPropertyName("email")]
public string Email
{
get { return _Email; }
set { _Email = value; }
}
private string _Password;
[JsonPropertyName("password")]
public string Password
{
get { return _Password; }
set { _Password = value; }
}
private string _Language;
[JsonPropertyName("language")]
public string Language
{
get { return _Language; }
set { _Language = value; }
}
private string _TestSecurityUrl;
[JsonPropertyName("testsecurityurl")]
public string TestSecurityUrl
{
get { return _TestSecurityUrl; }
set { _TestSecurityUrl = value; }
}
private string _ProdSecurityUrl;
[JsonPropertyName("prodsecurityurl")]
public string ProdSecurityUrl
{
get { return _ProdSecurityUrl; }
set { _ProdSecurityUrl = value; }
}
private string _HashPassword;
[JsonPropertyName("hashpassword")]
public string HashPassword
{
get { return _HashPassword; }
set { _HashPassword = value; }
}
private string _OkUrl;
[JsonPropertyName("okurl")]
public string OkUrl
{
get { return _OkUrl; }
set { _OkUrl = value; }
}
private string _FailUrl;
[JsonPropertyName("failurl")]
public string FailUrl
{
get { return _FailUrl; }
set { _FailUrl = value; }
}
private string _UserId;
[JsonPropertyName("userid")]
public string UserId
{
get { return _UserId; }
set { _UserId = value; }
}
private string _MemberId;
[JsonPropertyName("memberid")]
public string MemberId
{
get { return _MemberId; }
set { _MemberId = value; }
}
private string _MerchantId;
[JsonPropertyName("merchantid")]
public string MerchantId
{
get { return _MerchantId; }
set { _MerchantId = value; }
}
private string _UserCode;
[JsonPropertyName("usercode")]
public string UserCode
{
get { return _UserCode; }
set { _UserCode = value; }
}
private string _TxnType;
[JsonPropertyName("txntype")]
public string TxnType
{
get { return _TxnType; }
set { _TxnType = value; }
}
private string _TestPaymentUrl;
[JsonPropertyName("testpaymenturl")]
public string TestPaymentUrl
{
get { return _TestPaymentUrl; }
set { _TestPaymentUrl = value; }
}
private string _ProdPaymentUrl;
[JsonPropertyName("prodpaymenturl")]
public string ProdPaymentUrl
{
get { return _ProdPaymentUrl; }
set { _ProdPaymentUrl = value; }
}
}
}
