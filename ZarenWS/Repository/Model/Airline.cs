using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Airline")]
public class Airline: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _AirlineCode;
[JsonPropertyName("airlinecode")]
public string AirlineCode
{
get { return _AirlineCode; }
set { _AirlineCode = value; }
}
private string _AirlineName;
[JsonPropertyName("airlinename")]
public string AirlineName
{
get { return _AirlineName; }
set { _AirlineName = value; }
}
private string _AirlinePlate;
[JsonPropertyName("airlineplate")]
public string AirlinePlate
{
get { return _AirlinePlate; }
set { _AirlinePlate = value; }
}
private DateTime? _AirlineTimestamp;
[JsonPropertyName("airlinetimestamp")]
public DateTime? AirlineTimestamp
{
get { return _AirlineTimestamp; }
set { _AirlineTimestamp = value; }
}
private bool? _AirlineActive;
[JsonPropertyName("airlineactive")]
public bool? AirlineActive
{
get { return _AirlineActive; }
set { _AirlineActive = value; }
}
}
}
