using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Currency")]
public class Currency: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CurrencyCode;
[JsonPropertyName("currencycode")]
public string CurrencyCode
{
get { return _CurrencyCode; }
set { _CurrencyCode = value; }
}
private string _CurrencyCodeIata;
[JsonPropertyName("currencycodeiata")]
public string CurrencyCodeIata
{
get { return _CurrencyCodeIata; }
set { _CurrencyCodeIata = value; }
}
private string _CurrencyName;
[JsonPropertyName("currencyname")]
public string CurrencyName
{
get { return _CurrencyName; }
set { _CurrencyName = value; }
}
private DateTime? _CurrencyTimeStamp;
[JsonPropertyName("currencytimestamp")]
public DateTime? CurrencyTimeStamp
{
get { return _CurrencyTimeStamp; }
set { _CurrencyTimeStamp = value; }
}
private bool? _CurrencyActşve;
[JsonPropertyName("currencyactsve")]
public bool? CurrencyActşve
{
get { return _CurrencyActşve; }
set { _CurrencyActşve = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
private int? _UpdateBy;
[JsonPropertyName("updateby")]
public int? UpdateBy
{
get { return _UpdateBy; }
set { _UpdateBy = value; }
}
private int? _CreateBy;
[JsonPropertyName("createby")]
public int? CreateBy
{
get { return _CreateBy; }
set { _CreateBy = value; }
}
private DateTime? _Updated;
[JsonPropertyName("updated")]
public DateTime? Updated
{
get { return _Updated; }
set { _Updated = value; }
}
private DateTime? _Created;
[JsonPropertyName("created")]
public DateTime? Created
{
get { return _Created; }
set { _Created = value; }
}
}
}
