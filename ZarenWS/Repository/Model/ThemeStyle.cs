using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("ThemeStyle")]
public class ThemeStyle: IEntity
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
private string _Path;
[JsonPropertyName("path")]
public string Path
{
get { return _Path; }
set { _Path = value; }
}
private string _Property;
[JsonPropertyName("property")]
public string Property
{
get { return _Property; }
set { _Property = value; }
}
}
}
