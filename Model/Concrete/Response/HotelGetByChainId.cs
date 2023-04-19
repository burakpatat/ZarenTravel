using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class HotelGetByChainIdResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _HotelName;
[JsonPropertyName("hotelName")]
public string HotelName
{
get { return _HotelName; }
set { _HotelName = value; }
}
private int? _CityId;
[JsonPropertyName("cityId")]
public int? CityId
{
get { return _CityId; }
set { _CityId = value; }
}
private int? _ChainId;
[JsonPropertyName("chainId")]
public int? ChainId
{
get { return _ChainId; }
set { _ChainId = value; }
}
private DateTime? _HotelTimestamp;
[JsonPropertyName("hotelTimestamp")]
public DateTime? HotelTimestamp
{
get { return _HotelTimestamp; }
set { _HotelTimestamp = value; }
}
private bool? _HotelActive;
[JsonPropertyName("hotelActive")]
public bool? HotelActive
{
get { return _HotelActive; }
set { _HotelActive = value; }
}
}
}
