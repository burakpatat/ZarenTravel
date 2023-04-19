using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AirSegments")]
public class AirSegments: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AirId;
[JsonPropertyName("airid")]
public int? AirId
{
get { return _AirId; }
set { _AirId = value; }
}
private int? _AirlineId;
[JsonPropertyName("airlineid")]
public int? AirlineId
{
get { return _AirlineId; }
set { _AirlineId = value; }
}
private DateTime? _AiSeDeparture;
[JsonPropertyName("aisedeparture")]
public DateTime? AiSeDeparture
{
get { return _AiSeDeparture; }
set { _AiSeDeparture = value; }
}
private DateTime? _AiSeArrival;
[JsonPropertyName("aisearrival")]
public DateTime? AiSeArrival
{
get { return _AiSeArrival; }
set { _AiSeArrival = value; }
}
private int? _AirportIdOrigin;
[JsonPropertyName("airportidorigin")]
public int? AirportIdOrigin
{
get { return _AirportIdOrigin; }
set { _AirportIdOrigin = value; }
}
private int? _AirportIdDestination;
[JsonPropertyName("airportiddestination")]
public int? AirportIdDestination
{
get { return _AirportIdDestination; }
set { _AirportIdDestination = value; }
}
private string _AiSeFlightNumber;
[JsonPropertyName("aiseflightnumber")]
public string AiSeFlightNumber
{
get { return _AiSeFlightNumber; }
set { _AiSeFlightNumber = value; }
}
private bool? _AiSeClass;
[JsonPropertyName("aiseclass")]
public bool? AiSeClass
{
get { return _AiSeClass; }
set { _AiSeClass = value; }
}
private int? _TerminalIdOrigin;
[JsonPropertyName("terminalidorigin")]
public int? TerminalIdOrigin
{
get { return _TerminalIdOrigin; }
set { _TerminalIdOrigin = value; }
}
private int? _TerminalIdDestination;
[JsonPropertyName("terminaliddestination")]
public int? TerminalIdDestination
{
get { return _TerminalIdDestination; }
set { _TerminalIdDestination = value; }
}
private DateTime? _AiSeTimestamp;
[JsonPropertyName("aisetimestamp")]
public DateTime? AiSeTimestamp
{
get { return _AiSeTimestamp; }
set { _AiSeTimestamp = value; }
}
private bool? _AiSeActive;
[JsonPropertyName("aiseactive")]
public bool? AiSeActive
{
get { return _AiSeActive; }
set { _AiSeActive = value; }
}
}
}
