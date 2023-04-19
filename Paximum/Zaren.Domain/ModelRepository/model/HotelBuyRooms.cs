using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("HotelBuyRooms")]
public class HotelBuyRooms: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _HotelId;
[JsonPropertyName("hotelid")]
public int? HotelId
{
get { return _HotelId; }
set { _HotelId = value; }
}
private int? _BuyRoomId;
[JsonPropertyName("buyroomid")]
public int? BuyRoomId
{
get { return _BuyRoomId; }
set { _BuyRoomId = value; }
}
}
}
