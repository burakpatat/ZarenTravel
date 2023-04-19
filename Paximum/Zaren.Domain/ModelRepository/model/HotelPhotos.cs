using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("HotelPhotos")]
public class HotelPhotos: IEntity
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
private int? _HotelRoomId;
[JsonPropertyName("hotelroomid")]
public int? HotelRoomId
{
get { return _HotelRoomId; }
set { _HotelRoomId = value; }
}
private string _Path;
[JsonPropertyName("path")]
public string Path
{
get { return _Path; }
set { _Path = value; }
}
private int? _Order;
[JsonPropertyName("order")]
public int? Order
{
get { return _Order; }
set { _Order = value; }
}
}
}
