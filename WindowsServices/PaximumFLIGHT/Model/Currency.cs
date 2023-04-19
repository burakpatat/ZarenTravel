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
private DateTime? _CurrencyTimestamp;
[JsonPropertyName("currencytimestamp")]
public DateTime? CurrencyTimestamp
{
get { return _CurrencyTimestamp; }
set { _CurrencyTimestamp = value; }
}
private bool? _CurrencyActive;
[JsonPropertyName("currencyactive")]
public bool? CurrencyActive
{
get { return _CurrencyActive; }
set { _CurrencyActive = value; }
}
}
}
