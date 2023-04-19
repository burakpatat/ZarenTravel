using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("HotelBuyRoomAllotment")]
public class HotelBuyRoomAllotment: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _HotelBuyRoomId;
[JsonPropertyName("hotelbuyroomid")]
public int? HotelBuyRoomId
{
get { return _HotelBuyRoomId; }
set { _HotelBuyRoomId = value; }
}
private DateTime? _Day;
[JsonPropertyName("day")]
public DateTime? Day
{
get { return _Day; }
set { _Day = value; }
}
private int? _Allotment;
[JsonPropertyName("allotment")]
public int? Allotment
{
get { return _Allotment; }
set { _Allotment = value; }
}
private int? _Release;
[JsonPropertyName("release")]
public int? Release
{
get { return _Release; }
set { _Release = value; }
}
private int? _StopSales;
[JsonPropertyName("stopsales")]
public int? StopSales
{
get { return _StopSales; }
set { _StopSales = value; }
}
}
}
