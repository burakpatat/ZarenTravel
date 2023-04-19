using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyGroup")]
public class AgencyGroup: IEntity
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
private DateTime? _Timestamp;
[JsonPropertyName("timestamp")]
public DateTime? Timestamp
{
get { return _Timestamp; }
set { _Timestamp = value; }
}
private bool? _Active;
[JsonPropertyName("active")]
public bool? Active
{
get { return _Active; }
set { _Active = value; }
}
}
}
