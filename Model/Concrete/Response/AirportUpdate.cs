using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AirportUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _AirportCode;
[JsonPropertyName("airportCode")]
public string AirportCode
{
get { return _AirportCode; }
set { _AirportCode = value; }
}
private string _AirportName;
[JsonPropertyName("airportName")]
public string AirportName
{
get { return _AirportName; }
set { _AirportName = value; }
}
private int? _CountryId;
[JsonPropertyName("countryId")]
public int? CountryId
{
get { return _CountryId; }
set { _CountryId = value; }
}
private int? _CityId;
[JsonPropertyName("cityId")]
public int? CityId
{
get { return _CityId; }
set { _CityId = value; }
}
private DateTime? _AirportTimestamp;
[JsonPropertyName("airportTimestamp")]
public DateTime? AirportTimestamp
{
get { return _AirportTimestamp; }
set { _AirportTimestamp = value; }
}
private bool? _AirportActive;
[JsonPropertyName("airportActive")]
public bool? AirportActive
{
get { return _AirportActive; }
set { _AirportActive = value; }
}
}
}
