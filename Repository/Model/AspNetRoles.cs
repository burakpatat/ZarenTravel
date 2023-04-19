using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AspNetRoles")]
public class AspNetRoles: IEntity
{
private string _Id;
[Key]
[JsonPropertyName("id")]
public string Id
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
private string _NormalizedName;
[JsonPropertyName("normalizedname")]
public string NormalizedName
{
get { return _NormalizedName; }
set { _NormalizedName = value; }
}
private string _ConcurrencyStamp;
[JsonPropertyName("concurrencystamp")]
public string ConcurrencyStamp
{
get { return _ConcurrencyStamp; }
set { _ConcurrencyStamp = value; }
}
}
}
