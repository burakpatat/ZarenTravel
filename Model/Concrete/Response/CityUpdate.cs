using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CityUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CityCode;
[JsonPropertyName("cityCode")]
public string CityCode
{
get { return _CityCode; }
set { _CityCode = value; }
}
private string _CityName;
[JsonPropertyName("cityName")]
public string CityName
{
get { return _CityName; }
set { _CityName = value; }
}
private int? _CountryId;
[JsonPropertyName("countryId")]
public int? CountryId
{
get { return _CountryId; }
set { _CountryId = value; }
}
private DateTime? _CityTimestamp;
[JsonPropertyName("cityTimestamp")]
public DateTime? CityTimestamp
{
get { return _CityTimestamp; }
set { _CityTimestamp = value; }
}
private bool? _CityActive;
[JsonPropertyName("cityActive")]
public bool? CityActive
{
get { return _CityActive; }
set { _CityActive = value; }
}
}
}
