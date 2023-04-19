using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("HeaderColor")]
public class HeaderColor: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _Color;
[JsonPropertyName("color")]
public string Color
{
get { return _Color; }
set { _Color = value; }
}
private string _Path;
[JsonPropertyName("path")]
public string Path
{
get { return _Path; }
set { _Path = value; }
}
}
}
