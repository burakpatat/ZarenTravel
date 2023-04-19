using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AccommodationGetByCurrencyIdResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _PNRId;
[JsonPropertyName("pNRId")]
public int? PNRId
{
get { return _PNRId; }
set { _PNRId = value; }
}
private DateTime? _AccommodationCheckIN;
[JsonPropertyName("accommodationCheckIN")]
public DateTime? AccommodationCheckIN
{
get { return _AccommodationCheckIN; }
set { _AccommodationCheckIN = value; }
}
private DateTime? _AccommodationCheckOUT;
[JsonPropertyName("accommodationCheckOUT")]
public DateTime? AccommodationCheckOUT
{
get { return _AccommodationCheckOUT; }
set { _AccommodationCheckOUT = value; }
}
private int? _HotelId;
[JsonPropertyName("hotelId")]
public int? HotelId
{
get { return _HotelId; }
set { _HotelId = value; }
}
private int? _RoTyId;
[JsonPropertyName("roTyId")]
public int? RoTyId
{
get { return _RoTyId; }
set { _RoTyId = value; }
}
private string _AccommodationRate;
[JsonPropertyName("accommodationRate")]
public string AccommodationRate
{
get { return _AccommodationRate; }
set { _AccommodationRate = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyId")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private int? _BrokerId;
[JsonPropertyName("brokerId")]
public int? BrokerId
{
get { return _BrokerId; }
set { _BrokerId = value; }
}
private DateTime? _AccommodationBookedDate;
[JsonPropertyName("accommodationBookedDate")]
public DateTime? AccommodationBookedDate
{
get { return _AccommodationBookedDate; }
set { _AccommodationBookedDate = value; }
}
private DateTime? _AccommodationTimestap;
[JsonPropertyName("accommodationTimestap")]
public DateTime? AccommodationTimestap
{
get { return _AccommodationTimestap; }
set { _AccommodationTimestap = value; }
}
private bool? _AccommodationActive;
[JsonPropertyName("accommodationActive")]
public bool? AccommodationActive
{
get { return _AccommodationActive; }
set { _AccommodationActive = value; }
}
}
}
