using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyContractsHotelsConfigurationDays")]
public class AgencyContractsHotelsConfigurationDays: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private bool? _Monday;
[JsonPropertyName("monday")]
public bool? Monday
{
get { return _Monday; }
set { _Monday = value; }
}
private bool? _Tuesday;
[JsonPropertyName("tuesday")]
public bool? Tuesday
{
get { return _Tuesday; }
set { _Tuesday = value; }
}
private bool? _Wednesday;
[JsonPropertyName("wednesday")]
public bool? Wednesday
{
get { return _Wednesday; }
set { _Wednesday = value; }
}
private bool? _Thursday;
[JsonPropertyName("thursday")]
public bool? Thursday
{
get { return _Thursday; }
set { _Thursday = value; }
}
private bool? _Friday;
[JsonPropertyName("friday")]
public bool? Friday
{
get { return _Friday; }
set { _Friday = value; }
}
private bool? _Saturday;
[JsonPropertyName("saturday")]
public bool? Saturday
{
get { return _Saturday; }
set { _Saturday = value; }
}
private bool? _Sunday;
[JsonPropertyName("sunday")]
public bool? Sunday
{
get { return _Sunday; }
set { _Sunday = value; }
}
}
}
