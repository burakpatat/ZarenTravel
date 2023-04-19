using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AirGetByAirBookedDateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AirlineId;
[JsonPropertyName("airlineId")]
public int? AirlineId
{
get { return _AirlineId; }
set { _AirlineId = value; }
}
private string _AirRecordAirline;
[JsonPropertyName("airRecordAirline")]
public string AirRecordAirline
{
get { return _AirRecordAirline; }
set { _AirRecordAirline = value; }
}
private string _AirTicket;
[JsonPropertyName("airTicket")]
public string AirTicket
{
get { return _AirTicket; }
set { _AirTicket = value; }
}
private DateTime? _AirBookedDate;
[JsonPropertyName("airBookedDate")]
public DateTime? AirBookedDate
{
get { return _AirBookedDate; }
set { _AirBookedDate = value; }
}
private DateTime? _AirIssueddate;
[JsonPropertyName("airIssueddate")]
public DateTime? AirIssueddate
{
get { return _AirIssueddate; }
set { _AirIssueddate = value; }
}
private bool? _AirReIssued;
[JsonPropertyName("airReIssued")]
public bool? AirReIssued
{
get { return _AirReIssued; }
set { _AirReIssued = value; }
}
private string _AirOriginalTicket;
[JsonPropertyName("airOriginalTicket")]
public string AirOriginalTicket
{
get { return _AirOriginalTicket; }
set { _AirOriginalTicket = value; }
}
private int? _PNRId;
[JsonPropertyName("pNRId")]
public int? PNRId
{
get { return _PNRId; }
set { _PNRId = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyId")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private string _AirFare;
[JsonPropertyName("airFare")]
public string AirFare
{
get { return _AirFare; }
set { _AirFare = value; }
}
private string _AirTax;
[JsonPropertyName("airTax")]
public string AirTax
{
get { return _AirTax; }
set { _AirTax = value; }
}
private string _AirLowestFare;
[JsonPropertyName("airLowestFare")]
public string AirLowestFare
{
get { return _AirLowestFare; }
set { _AirLowestFare = value; }
}
private string _AirHighestFare;
[JsonPropertyName("airHighestFare")]
public string AirHighestFare
{
get { return _AirHighestFare; }
set { _AirHighestFare = value; }
}
private string _AirFareBases;
[JsonPropertyName("airFareBases")]
public string AirFareBases
{
get { return _AirFareBases; }
set { _AirFareBases = value; }
}
private int? _BrokerId;
[JsonPropertyName("brokerId")]
public int? BrokerId
{
get { return _BrokerId; }
set { _BrokerId = value; }
}
private bool? _AirIncludeBags;
[JsonPropertyName("airIncludeBags")]
public bool? AirIncludeBags
{
get { return _AirIncludeBags; }
set { _AirIncludeBags = value; }
}
private DateTime? _AirTimestamp;
[JsonPropertyName("airTimestamp")]
public DateTime? AirTimestamp
{
get { return _AirTimestamp; }
set { _AirTimestamp = value; }
}
private bool? _AirActive;
[JsonPropertyName("airActive")]
public bool? AirActive
{
get { return _AirActive; }
set { _AirActive = value; }
}
}
}
