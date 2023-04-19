using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class RoomTypeGetAllResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _RoTyCode;
[JsonPropertyName("roTyCode")]
public string RoTyCode
{
get { return _RoTyCode; }
set { _RoTyCode = value; }
}
private string _RoTyDescription;
[JsonPropertyName("roTyDescription")]
public string RoTyDescription
{
get { return _RoTyDescription; }
set { _RoTyDescription = value; }
}
private DateTime? _RoTyTimestamp;
[JsonPropertyName("roTyTimestamp")]
public DateTime? RoTyTimestamp
{
get { return _RoTyTimestamp; }
set { _RoTyTimestamp = value; }
}
private bool? _RoTyActive;
[JsonPropertyName("roTyActive")]
public bool? RoTyActive
{
get { return _RoTyActive; }
set { _RoTyActive = value; }
}
}
}
