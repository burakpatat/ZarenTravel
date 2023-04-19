using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class HotelCodesGetByHotelIdResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _HotelId;
[JsonPropertyName("hotelId")]
public int? HotelId
{
get { return _HotelId; }
set { _HotelId = value; }
}
private int? _BrokerId;
[JsonPropertyName("brokerId")]
public int? BrokerId
{
get { return _BrokerId; }
set { _BrokerId = value; }
}
private string _HoCoCode;
[JsonPropertyName("hoCoCode")]
public string HoCoCode
{
get { return _HoCoCode; }
set { _HoCoCode = value; }
}
private DateTime? _HoCoTimestamp;
[JsonPropertyName("hoCoTimestamp")]
public DateTime? HoCoTimestamp
{
get { return _HoCoTimestamp; }
set { _HoCoTimestamp = value; }
}
private bool? _HoCoActive;
[JsonPropertyName("hoCoActive")]
public bool? HoCoActive
{
get { return _HoCoActive; }
set { _HoCoActive = value; }
}
}
}
