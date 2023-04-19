using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Rooms")]
public class Rooms: IEntity
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
private int? _Adults;
[JsonPropertyName("adults")]
public int? Adults
{
get { return _Adults; }
set { _Adults = value; }
}
private int? _Children;
[JsonPropertyName("children")]
public int? Children
{
get { return _Children; }
set { _Children = value; }
}
private int? _Infants;
[JsonPropertyName("infants")]
public int? Infants
{
get { return _Infants; }
set { _Infants = value; }
}
}
}
