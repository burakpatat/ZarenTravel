using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class TerminalGetAllResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _TerminalName;
[JsonPropertyName("terminalName")]
public string TerminalName
{
get { return _TerminalName; }
set { _TerminalName = value; }
}
private string _TerminalCode;
[JsonPropertyName("terminalCode")]
public string TerminalCode
{
get { return _TerminalCode; }
set { _TerminalCode = value; }
}
private int? _AirportId;
[JsonPropertyName("airportId")]
public int? AirportId
{
get { return _AirportId; }
set { _AirportId = value; }
}
private DateTime? _TerminalTimestamp;
[JsonPropertyName("terminalTimestamp")]
public DateTime? TerminalTimestamp
{
get { return _TerminalTimestamp; }
set { _TerminalTimestamp = value; }
}
private bool? _TerminalActive;
[JsonPropertyName("terminalActive")]
public bool? TerminalActive
{
get { return _TerminalActive; }
set { _TerminalActive = value; }
}
}
}
