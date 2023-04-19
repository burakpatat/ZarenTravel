using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class FieldsTypeGetFiTyTimestampBetweenResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _FiTyCode;
[JsonPropertyName("fiTyCode")]
public string FiTyCode
{
get { return _FiTyCode; }
set { _FiTyCode = value; }
}
private string _FiTyName;
[JsonPropertyName("fiTyName")]
public string FiTyName
{
get { return _FiTyName; }
set { _FiTyName = value; }
}
private DateTime? _FiTyTimestamp;
[JsonPropertyName("fiTyTimestamp")]
public DateTime? FiTyTimestamp
{
get { return _FiTyTimestamp; }
set { _FiTyTimestamp = value; }
}
private bool? _FiTyActive;
[JsonPropertyName("fiTyActive")]
public bool? FiTyActive
{
get { return _FiTyActive; }
set { _FiTyActive = value; }
}
}
}
