using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Airs")]
public class Airs: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AirlineId;
[JsonPropertyName("airlineid")]
public int? AirlineId
{
get { return _AirlineId; }
set { _AirlineId = value; }
}
private string _AirRecordAirline;
[JsonPropertyName("airrecordairline")]
public string AirRecordAirline
{
get { return _AirRecordAirline; }
set { _AirRecordAirline = value; }
}
private string _AirTicket;
[JsonPropertyName("airticket")]
public string AirTicket
{
get { return _AirTicket; }
set { _AirTicket = value; }
}
private DateTime? _AirBookedDate;
[JsonPropertyName("airbookeddate")]
public DateTime? AirBookedDate
{
get { return _AirBookedDate; }
set { _AirBookedDate = value; }
}
private DateTime? _AirIssueddate;
[JsonPropertyName("airissueddate")]
public DateTime? AirIssueddate
{
get { return _AirIssueddate; }
set { _AirIssueddate = value; }
}
private bool? _AirReIssued;
[JsonPropertyName("airreissued")]
public bool? AirReIssued
{
get { return _AirReIssued; }
set { _AirReIssued = value; }
}
private string _AirOriginalTicket;
[JsonPropertyName("airoriginalticket")]
public string AirOriginalTicket
{
get { return _AirOriginalTicket; }
set { _AirOriginalTicket = value; }
}
private int? _PNRId;
[JsonPropertyName("pnrid")]
public int? PNRId
{
get { return _PNRId; }
set { _PNRId = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyid")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private decimal? _AirFare;
[JsonPropertyName("airfare")]
public decimal? AirFare
{
get { return _AirFare; }
set { _AirFare = value; }
}
private decimal? _AirTax;
[JsonPropertyName("airtax")]
public decimal? AirTax
{
get { return _AirTax; }
set { _AirTax = value; }
}
private decimal? _AirLowestFare;
[JsonPropertyName("airlowestfare")]
public decimal? AirLowestFare
{
get { return _AirLowestFare; }
set { _AirLowestFare = value; }
}
private decimal? _AirHighestFare;
[JsonPropertyName("airhighestfare")]
public decimal? AirHighestFare
{
get { return _AirHighestFare; }
set { _AirHighestFare = value; }
}
private string _AirFareBases;
[JsonPropertyName("airfarebases")]
public string AirFareBases
{
get { return _AirFareBases; }
set { _AirFareBases = value; }
}
private int? _BrokerId;
[JsonPropertyName("brokerid")]
public int? BrokerId
{
get { return _BrokerId; }
set { _BrokerId = value; }
}
private bool? _AirIncludeBags;
[JsonPropertyName("airincludebags")]
public bool? AirIncludeBags
{
get { return _AirIncludeBags; }
set { _AirIncludeBags = value; }
}
private DateTime? _AirTimestamp;
[JsonPropertyName("airtimestamp")]
public DateTime? AirTimestamp
{
get { return _AirTimestamp; }
set { _AirTimestamp = value; }
}
private bool? _AirActive;
[JsonPropertyName("airactive")]
public bool? AirActive
{
get { return _AirActive; }
set { _AirActive = value; }
}
}
}
