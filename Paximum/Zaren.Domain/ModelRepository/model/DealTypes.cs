using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("DealTypes")]
public class DealTypes: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _Name;
[JsonPropertyName("name")]
public int? Name
{
get { return _Name; }
set { _Name = value; }
}
}
}
