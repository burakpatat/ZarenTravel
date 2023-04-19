using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AgencyGroupGetAllResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _AgGrName;
[JsonPropertyName("agGrName")]
public string AgGrName
{
get { return _AgGrName; }
set { _AgGrName = value; }
}
private DateTime? _AgGrTimestamp;
[JsonPropertyName("agGrTimestamp")]
public DateTime? AgGrTimestamp
{
get { return _AgGrTimestamp; }
set { _AgGrTimestamp = value; }
}
private bool? _AgGrActive;
[JsonPropertyName("agGrActive")]
public bool? AgGrActive
{
get { return _AgGrActive; }
set { _AgGrActive = value; }
}
}
}
