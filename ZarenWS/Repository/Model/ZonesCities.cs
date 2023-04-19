using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("ZonesCities")]
public class ZonesCities: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _CityId;
[JsonPropertyName("cityid")]
public int? CityId
{
get { return _CityId; }
set { _CityId = value; }
}
private int? _ZoneId;
[JsonPropertyName("zoneid")]
public int? ZoneId
{
get { return _ZoneId; }
set { _ZoneId = value; }
}
private string _MainZone;
[JsonPropertyName("mainzone")]
public string MainZone
{
get { return _MainZone; }
set { _MainZone = value; }
}
}
}
