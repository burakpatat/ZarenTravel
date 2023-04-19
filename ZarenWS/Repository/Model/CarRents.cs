using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("CarRents")]
public class CarRents: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _PNRId;
[JsonPropertyName("pnrid")]
public int? PNRId
{
get { return _PNRId; }
set { _PNRId = value; }
}
private int? _CaTyId;
[JsonPropertyName("catyid")]
public int? CaTyId
{
get { return _CaTyId; }
set { _CaTyId = value; }
}
private int? _CaRtId;
[JsonPropertyName("cartid")]
public int? CaRtId
{
get { return _CaRtId; }
set { _CaRtId = value; }
}
private int? _AirportIdPickUp;
[JsonPropertyName("airportidpickup")]
public int? AirportIdPickUp
{
get { return _AirportIdPickUp; }
set { _AirportIdPickUp = value; }
}
private int? _AirportIdReturn;
[JsonPropertyName("airportidreturn")]
public int? AirportIdReturn
{
get { return _AirportIdReturn; }
set { _AirportIdReturn = value; }
}
private DateTime? _CaRePickUpDate;
[JsonPropertyName("carepickupdate")]
public DateTime? CaRePickUpDate
{
get { return _CaRePickUpDate; }
set { _CaRePickUpDate = value; }
}
private DateTime? _CaReReturnDate;
[JsonPropertyName("carereturndate")]
public DateTime? CaReReturnDate
{
get { return _CaReReturnDate; }
set { _CaReReturnDate = value; }
}
private decimal? _CaReRate;
[JsonPropertyName("carerate")]
public decimal? CaReRate
{
get { return _CaReRate; }
set { _CaReRate = value; }
}
private decimal? _CaReTax;
[JsonPropertyName("caretax")]
public decimal? CaReTax
{
get { return _CaReTax; }
set { _CaReTax = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyid")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private DateTime? _CaReBookDate;
[JsonPropertyName("carebookdate")]
public DateTime? CaReBookDate
{
get { return _CaReBookDate; }
set { _CaReBookDate = value; }
}
private DateTime? _CaReTimestamp;
[JsonPropertyName("caretimestamp")]
public DateTime? CaReTimestamp
{
get { return _CaReTimestamp; }
set { _CaReTimestamp = value; }
}
private bool? _CaReActive;
[JsonPropertyName("careactive")]
public bool? CaReActive
{
get { return _CaReActive; }
set { _CaReActive = value; }
}
}
}
