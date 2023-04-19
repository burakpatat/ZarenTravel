using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Cities")]
public class Cities: IEntity
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
private decimal? _Latitude;
[JsonPropertyName("latitude")]
public decimal? Latitude
{
get { return _Latitude; }
set { _Latitude = value; }
}
private decimal? _Longitude;
[JsonPropertyName("longitude")]
public decimal? Longitude
{
get { return _Longitude; }
set { _Longitude = value; }
}
}
}
