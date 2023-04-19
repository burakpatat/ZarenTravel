using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("OneRoundMultiWays")]
public class OneRoundMultiWays: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _Quantity;
[JsonPropertyName("quantity")]
public int? Quantity
{
get { return _Quantity; }
set { _Quantity = value; }
}
private double? _Price;
[JsonPropertyName("price")]
public double? Price
{
get { return _Price; }
set { _Price = value; }
}
private int? _TotalPrice;
[JsonPropertyName("totalprice")]
public int? TotalPrice
{
get { return _TotalPrice; }
set { _TotalPrice = value; }
}
private double? _Amount;
[JsonPropertyName("amount")]
public double? Amount
{
get { return _Amount; }
set { _Amount = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyid")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private int? _PassengerTypesId;
[JsonPropertyName("passengertypesid")]
public int? PassengerTypesId
{
get { return _PassengerTypesId; }
set { _PassengerTypesId = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private int? _LanguageId;
[JsonPropertyName("languageid")]
public int? LanguageId
{
get { return _LanguageId; }
set { _LanguageId = value; }
}
private string _SystemId;
[JsonPropertyName("systemid")]
public string SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
}
private DateTime? _CreatedDate;
[JsonPropertyName("createddate")]
public DateTime? CreatedDate
{
get { return _CreatedDate; }
set { _CreatedDate = value; }
}
private DateTime? _UpdatedDate;
[JsonPropertyName("updateddate")]
public DateTime? UpdatedDate
{
get { return _UpdatedDate; }
set { _UpdatedDate = value; }
}
private int? _CreatedBy;
[JsonPropertyName("createdby")]
public int? CreatedBy
{
get { return _CreatedBy; }
set { _CreatedBy = value; }
}
}
}
