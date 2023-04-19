using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("TestCards")]
public class TestCards: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _PaymentConfigurationId;
[JsonPropertyName("paymentconfigurationid")]
public int? PaymentConfigurationId
{
get { return _PaymentConfigurationId; }
set { _PaymentConfigurationId = value; }
}
private string _BankName;
[JsonPropertyName("bankname")]
public string BankName
{
get { return _BankName; }
set { _BankName = value; }
}
private string _CardNo;
[JsonPropertyName("cardno")]
public string CardNo
{
get { return _CardNo; }
set { _CardNo = value; }
}
private string _ValidDate;
[JsonPropertyName("validdate")]
public string ValidDate
{
get { return _ValidDate; }
set { _ValidDate = value; }
}
private string _CVV;
[JsonPropertyName("cvv")]
public string CVV
{
get { return _CVV; }
set { _CVV = value; }
}
private string _ThreeDPassword;
[JsonPropertyName("threedpassword")]
public string ThreeDPassword
{
get { return _ThreeDPassword; }
set { _ThreeDPassword = value; }
}
private string _CardType;
[JsonPropertyName("cardtype")]
public string CardType
{
get { return _CardType; }
set { _CardType = value; }
}
private string _CardScheme;
[JsonPropertyName("cardscheme")]
public string CardScheme
{
get { return _CardScheme; }
set { _CardScheme = value; }
}
private string _ResponseType;
[JsonPropertyName("responsetype")]
public string ResponseType
{
get { return _ResponseType; }
set { _ResponseType = value; }
}
}
}
