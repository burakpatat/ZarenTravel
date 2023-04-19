using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class ExtrasTypeGetByExTyTimestampResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _ExTyCode;
[JsonPropertyName("exTyCode")]
public string ExTyCode
{
get { return _ExTyCode; }
set { _ExTyCode = value; }
}
private string _ExTyName;
[JsonPropertyName("exTyName")]
public string ExTyName
{
get { return _ExTyName; }
set { _ExTyName = value; }
}
private DateTime? _ExTyTimestamp;
[JsonPropertyName("exTyTimestamp")]
public DateTime? ExTyTimestamp
{
get { return _ExTyTimestamp; }
set { _ExTyTimestamp = value; }
}
private bool? _ExTyActive;
[JsonPropertyName("exTyActive")]
public bool? ExTyActive
{
get { return _ExTyActive; }
set { _ExTyActive = value; }
}
}
}
