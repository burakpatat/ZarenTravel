using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Terminal")]
public class Terminal: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _TerminalName;
[JsonPropertyName("terminalname")]
public string TerminalName
{
get { return _TerminalName; }
set { _TerminalName = value; }
}
private string _TerminalCode;
[JsonPropertyName("terminalcode")]
public string TerminalCode
{
get { return _TerminalCode; }
set { _TerminalCode = value; }
}
private int? _AirportId;
[JsonPropertyName("airportid")]
public int? AirportId
{
get { return _AirportId; }
set { _AirportId = value; }
}
private DateTime? _TerminalTimestamp;
[JsonPropertyName("terminaltimestamp")]
public DateTime? TerminalTimestamp
{
get { return _TerminalTimestamp; }
set { _TerminalTimestamp = value; }
}
private bool? _TerminalActive;
[JsonPropertyName("terminalactive")]
public bool? TerminalActive
{
get { return _TerminalActive; }
set { _TerminalActive = value; }
}
}
}
