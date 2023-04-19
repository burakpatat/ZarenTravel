using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AirExtrasGetByExTyIdResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AirId;
[JsonPropertyName("airId")]
public int? AirId
{
get { return _AirId; }
set { _AirId = value; }
}
private int? _ExTyId;
[JsonPropertyName("exTyId")]
public int? ExTyId
{
get { return _ExTyId; }
set { _ExTyId = value; }
}
private string _AiExDescription;
[JsonPropertyName("aiExDescription")]
public string AiExDescription
{
get { return _AiExDescription; }
set { _AiExDescription = value; }
}
private string _AiExFare;
[JsonPropertyName("aiExFare")]
public string AiExFare
{
get { return _AiExFare; }
set { _AiExFare = value; }
}
private DateTime? _AiExTimestamp;
[JsonPropertyName("aiExTimestamp")]
public DateTime? AiExTimestamp
{
get { return _AiExTimestamp; }
set { _AiExTimestamp = value; }
}
private bool? _AiExActive;
[JsonPropertyName("aiExActive")]
public bool? AiExActive
{
get { return _AiExActive; }
set { _AiExActive = value; }
}
}
}
