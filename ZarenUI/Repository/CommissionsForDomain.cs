using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("CommissionsForDomain")]
public class CommissionsForDomain: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Domain;
[JsonPropertyName("domain")]
public string Domain
{
get { return _Domain; }
set { _Domain = value; }
}
private string _AgentName;
[JsonPropertyName("agentname")]
public string AgentName
{
get { return _AgentName; }
set { _AgentName = value; }
}
private decimal? _HotelCommission;
[JsonPropertyName("hotelcommission")]
public decimal? HotelCommission
{
get { return _HotelCommission; }
set { _HotelCommission = value; }
}
private decimal? _FlightCommission;
[JsonPropertyName("flightcommission")]
public decimal? FlightCommission
{
get { return _FlightCommission; }
set { _FlightCommission = value; }
}
}
}
