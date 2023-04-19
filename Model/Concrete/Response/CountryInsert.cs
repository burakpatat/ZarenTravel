using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CountryInsertResponse: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CountryCode;
[JsonPropertyName("countryCode")]
public string CountryCode
{
get { return _CountryCode; }
set { _CountryCode = value; }
}
private string _CountryName;
[JsonPropertyName("countryName")]
public string CountryName
{
get { return _CountryName; }
set { _CountryName = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyId")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private DateTime? _CountryTimestamp;
[JsonPropertyName("countryTimestamp")]
public DateTime? CountryTimestamp
{
get { return _CountryTimestamp; }
set { _CountryTimestamp = value; }
}
private bool? _CountryActive;
[JsonPropertyName("countryActive")]
public bool? CountryActive
{
get { return _CountryActive; }
set { _CountryActive = value; }
}
}
}
