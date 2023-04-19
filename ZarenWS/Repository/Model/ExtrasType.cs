using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("ExtrasType")]
public class ExtrasType: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _ExTyCode;
[JsonPropertyName("extycode")]
public string ExTyCode
{
get { return _ExTyCode; }
set { _ExTyCode = value; }
}
private string _ExTyName;
[JsonPropertyName("extyname")]
public string ExTyName
{
get { return _ExTyName; }
set { _ExTyName = value; }
}
private DateTime? _ExTyTimestamp;
[JsonPropertyName("extytimestamp")]
public DateTime? ExTyTimestamp
{
get { return _ExTyTimestamp; }
set { _ExTyTimestamp = value; }
}
private bool? _ExTyActive;
[JsonPropertyName("extyactive")]
public bool? ExTyActive
{
get { return _ExTyActive; }
set { _ExTyActive = value; }
}
}
}
