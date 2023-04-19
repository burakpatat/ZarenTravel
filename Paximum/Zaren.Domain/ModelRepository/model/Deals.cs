using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Deals")]
public class Deals: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
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
private int? _DealTypeId;
[JsonPropertyName("dealtypeid")]
public int? DealTypeId
{
get { return _DealTypeId; }
set { _DealTypeId = value; }
}
private int? _Release;
[JsonPropertyName("release")]
public int? Release
{
get { return _Release; }
set { _Release = value; }
}
private decimal? _Discount;
[JsonPropertyName("discount")]
public decimal? Discount
{
get { return _Discount; }
set { _Discount = value; }
}
private int? _FreeNights;
[JsonPropertyName("freenights")]
public int? FreeNights
{
get { return _FreeNights; }
set { _FreeNights = value; }
}
private DateTime? _StartDate;
[JsonPropertyName("startdate")]
public DateTime? StartDate
{
get { return _StartDate; }
set { _StartDate = value; }
}
private DateTime? _EndDate;
[JsonPropertyName("enddate")]
public DateTime? EndDate
{
get { return _EndDate; }
set { _EndDate = value; }
}
}
}
