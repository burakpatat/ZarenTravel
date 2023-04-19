using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Hotels")]
public class Hotels: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _HotelChainId;
[JsonPropertyName("hotelchainid")]
public int? HotelChainId
{
get { return _HotelChainId; }
set { _HotelChainId = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private int? _HotelTypeId;
[JsonPropertyName("hoteltypeid")]
public int? HotelTypeId
{
get { return _HotelTypeId; }
set { _HotelTypeId = value; }
}
private int? _CountryId;
[JsonPropertyName("countryid")]
public int? CountryId
{
get { return _CountryId; }
set { _CountryId = value; }
}
private int? _RegionId;
[JsonPropertyName("regionid")]
public int? RegionId
{
get { return _RegionId; }
set { _RegionId = value; }
}
private int? _ZoneId;
[JsonPropertyName("zoneid")]
public int? ZoneId
{
get { return _ZoneId; }
set { _ZoneId = value; }
}
private int? _CityId;
[JsonPropertyName("cityid")]
public int? CityId
{
get { return _CityId; }
set { _CityId = value; }
}
private string _Address;
[JsonPropertyName("address")]
public string Address
{
get { return _Address; }
set { _Address = value; }
}
private string _ZipCode;
[JsonPropertyName("zipcode")]
public string ZipCode
{
get { return _ZipCode; }
set { _ZipCode = value; }
}
private decimal? _Latitude;
[JsonPropertyName("latitude")]
public decimal? Latitude
{
get { return _Latitude; }
set { _Latitude = value; }
}
private decimal? _Longitude;
[JsonPropertyName("longitude")]
public decimal? Longitude
{
get { return _Longitude; }
set { _Longitude = value; }
}
private int? _CommercialContactId;
[JsonPropertyName("commercialcontactid")]
public int? CommercialContactId
{
get { return _CommercialContactId; }
set { _CommercialContactId = value; }
}
private int? _ReservationContactId;
[JsonPropertyName("reservationcontactid")]
public int? ReservationContactId
{
get { return _ReservationContactId; }
set { _ReservationContactId = value; }
}
private int? _FinanceContactId;
[JsonPropertyName("financecontactid")]
public int? FinanceContactId
{
get { return _FinanceContactId; }
set { _FinanceContactId = value; }
}
private int? _Release;
[JsonPropertyName("release")]
public int? Release
{
get { return _Release; }
set { _Release = value; }
}
private int? _NumberRooms;
[JsonPropertyName("numberrooms")]
public int? NumberRooms
{
get { return _NumberRooms; }
set { _NumberRooms = value; }
}
}
}
