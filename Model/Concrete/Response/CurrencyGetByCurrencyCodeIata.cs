using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CurrencyGetByCurrencyCodeIataResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CurrencyCode;
[JsonPropertyName("currencyCode")]
public string CurrencyCode
{
get { return _CurrencyCode; }
set { _CurrencyCode = value; }
}
private string _CurrencyCodeIata;
[JsonPropertyName("currencyCodeIata")]
public string CurrencyCodeIata
{
get { return _CurrencyCodeIata; }
set { _CurrencyCodeIata = value; }
}
private string _CurrencyName;
[JsonPropertyName("currencyName")]
public string CurrencyName
{
get { return _CurrencyName; }
set { _CurrencyName = value; }
}
private DateTime? _CurrencyTimestamp;
[JsonPropertyName("currencyTimestamp")]
public DateTime? CurrencyTimestamp
{
get { return _CurrencyTimestamp; }
set { _CurrencyTimestamp = value; }
}
private bool? _CurrencyActive;
[JsonPropertyName("currencyActive")]
public bool? CurrencyActive
{
get { return _CurrencyActive; }
set { _CurrencyActive = value; }
}
}
}
