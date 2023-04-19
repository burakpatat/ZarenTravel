using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CompanyGroupGetByCoGrTimestampResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CoGrName;
[JsonPropertyName("coGrName")]
public string CoGrName
{
get { return _CoGrName; }
set { _CoGrName = value; }
}
private string _CoGrTravelManager;
[JsonPropertyName("coGrTravelManager")]
public string CoGrTravelManager
{
get { return _CoGrTravelManager; }
set { _CoGrTravelManager = value; }
}
private int? _CoGrTimestamp;
[JsonPropertyName("coGrTimestamp")]
public int? CoGrTimestamp
{
get { return _CoGrTimestamp; }
set { _CoGrTimestamp = value; }
}
private bool? _CoGrActive;
[JsonPropertyName("coGrActive")]
public bool? CoGrActive
{
get { return _CoGrActive; }
set { _CoGrActive = value; }
}
}
}
