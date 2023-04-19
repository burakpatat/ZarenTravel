using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AccommodationExtrasInsertResponse: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AccommodationId;
[JsonPropertyName("accommodationId")]
public int? AccommodationId
{
get { return _AccommodationId; }
set { _AccommodationId = value; }
}
private int? _ExTyId;
[JsonPropertyName("exTyId")]
public int? ExTyId
{
get { return _ExTyId; }
set { _ExTyId = value; }
}
private string _AcExDescription;
[JsonPropertyName("acExDescription")]
public string AcExDescription
{
get { return _AcExDescription; }
set { _AcExDescription = value; }
}
private int? _AcExFare;
[JsonPropertyName("acExFare")]
public int? AcExFare
{
get { return _AcExFare; }
set { _AcExFare = value; }
}
private DateTime? _AcExTimestamp;
[JsonPropertyName("acExTimestamp")]
public DateTime? AcExTimestamp
{
get { return _AcExTimestamp; }
set { _AcExTimestamp = value; }
}
private bool? _AcExActive;
[JsonPropertyName("acExActive")]
public bool? AcExActive
{
get { return _AcExActive; }
set { _AcExActive = value; }
}
}
}
