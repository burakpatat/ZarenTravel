using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("BuyRooms")]
public class BuyRooms: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _Description;
[JsonPropertyName("description")]
public string Description
{
get { return _Description; }
set { _Description = value; }
}
private int? _MaxAllotment;
[JsonPropertyName("maxallotment")]
public int? MaxAllotment
{
get { return _MaxAllotment; }
set { _MaxAllotment = value; }
}
private int? _MaxAdults;
[JsonPropertyName("maxadults")]
public int? MaxAdults
{
get { return _MaxAdults; }
set { _MaxAdults = value; }
}
private int? _MaxChildren;
[JsonPropertyName("maxchildren")]
public int? MaxChildren
{
get { return _MaxChildren; }
set { _MaxChildren = value; }
}
private int? _MaxInfants;
[JsonPropertyName("maxinfants")]
public int? MaxInfants
{
get { return _MaxInfants; }
set { _MaxInfants = value; }
}
}
}
