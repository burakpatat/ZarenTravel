using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class GDSGetAllResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _GDSName;
[JsonPropertyName("gDSName")]
public string GDSName
{
get { return _GDSName; }
set { _GDSName = value; }
}
private DateTime? _GDSTimestamp;
[JsonPropertyName("gDSTimestamp")]
public DateTime? GDSTimestamp
{
get { return _GDSTimestamp; }
set { _GDSTimestamp = value; }
}
private bool? _GDSActive;
[JsonPropertyName("gDSActive")]
public bool? GDSActive
{
get { return _GDSActive; }
set { _GDSActive = value; }
}
}
}
