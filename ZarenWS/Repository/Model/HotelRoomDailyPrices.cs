using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("HotelRoomDailyPrices")]
public class HotelRoomDailyPrices: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _BoardTypeId;
[JsonPropertyName("boardtypeid")]
public int? BoardTypeId
{
get { return _BoardTypeId; }
set { _BoardTypeId = value; }
}
private int? _HotelRoomId;
[JsonPropertyName("hotelroomid")]
public int? HotelRoomId
{
get { return _HotelRoomId; }
set { _HotelRoomId = value; }
}
private int? _Cost;
[JsonPropertyName("cost")]
public int? Cost
{
get { return _Cost; }
set { _Cost = value; }
}
private DateTime? _Day;
[JsonPropertyName("day")]
public DateTime? Day
{
get { return _Day; }
set { _Day = value; }
}
private int? _StopSale;
[JsonPropertyName("stopsale")]
public int? StopSale
{
get { return _StopSale; }
set { _StopSale = value; }
}
}
}
