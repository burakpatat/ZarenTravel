using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Airport")]
public class Airport: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _AirportCode;
[JsonPropertyName("airportcode")]
public string AirportCode
{
get { return _AirportCode; }
set { _AirportCode = value; }
}
private string _AirportName;
[JsonPropertyName("airportname")]
public string AirportName
{
get { return _AirportName; }
set { _AirportName = value; }
}
private int? _CountryId;
[JsonPropertyName("countryid")]
public int? CountryId
{
get { return _CountryId; }
set { _CountryId = value; }
}
private int? _CityId;
[JsonPropertyName("cityid")]
public int? CityId
{
get { return _CityId; }
set { _CityId = value; }
}
private DateTime? _AirportTimestamp;
[JsonPropertyName("airporttimestamp")]
public DateTime? AirportTimestamp
{
get { return _AirportTimestamp; }
set { _AirportTimestamp = value; }
}
private bool? _AirportActive;
[JsonPropertyName("airportactive")]
public bool? AirportActive
{
get { return _AirportActive; }
set { _AirportActive = value; }
}
}
}
