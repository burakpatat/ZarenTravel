using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("BookingRooms")]
public class BookingRooms: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _BookingId;
[JsonPropertyName("bookingid")]
public int? BookingId
{
get { return _BookingId; }
set { _BookingId = value; }
}
private int? _HotelRoomId;
[JsonPropertyName("hotelroomid")]
public int? HotelRoomId
{
get { return _HotelRoomId; }
set { _HotelRoomId = value; }
}
private int? _BoardTypeId;
[JsonPropertyName("boardtypeid")]
public int? BoardTypeId
{
get { return _BoardTypeId; }
set { _BoardTypeId = value; }
}
private decimal? _Cost;
[JsonPropertyName("cost")]
public decimal? Cost
{
get { return _Cost; }
set { _Cost = value; }
}
private int? _Price;
[JsonPropertyName("price")]
public int? Price
{
get { return _Price; }
set { _Price = value; }
}
}
}
