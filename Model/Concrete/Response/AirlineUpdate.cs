using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AirlineUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _AirlineCode;
[JsonPropertyName("airlineCode")]
public string AirlineCode
{
get { return _AirlineCode; }
set { _AirlineCode = value; }
}
private string _AirlineName;
[JsonPropertyName("airlineName")]
public string AirlineName
{
get { return _AirlineName; }
set { _AirlineName = value; }
}
private string _AirlinePlate;
[JsonPropertyName("airlinePlate")]
public string AirlinePlate
{
get { return _AirlinePlate; }
set { _AirlinePlate = value; }
}
private DateTime? _AirlineTimestamp;
[JsonPropertyName("airlineTimestamp")]
public DateTime? AirlineTimestamp
{
get { return _AirlineTimestamp; }
set { _AirlineTimestamp = value; }
}
private bool? _AirlineActive;
[JsonPropertyName("airlineActive")]
public bool? AirlineActive
{
get { return _AirlineActive; }
set { _AirlineActive = value; }
}
}
}
