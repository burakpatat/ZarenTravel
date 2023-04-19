using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("LimitTypes")]
public class LimitTypes: IEntity
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
private bool? _PerPassengerCommision;
[JsonPropertyName("perpassengercommision")]
public bool? PerPassengerCommision
{
get { return _PerPassengerCommision; }
set { _PerPassengerCommision = value; }
}
}
}
