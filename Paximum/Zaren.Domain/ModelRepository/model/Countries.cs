using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Countries")]
public class Countries: IEntity
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
private string _LatLongBounds;
[JsonPropertyName("latlongbounds")]
public string LatLongBounds
{
get { return _LatLongBounds; }
set { _LatLongBounds = value; }
}
}
}
