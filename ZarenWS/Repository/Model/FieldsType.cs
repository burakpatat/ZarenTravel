using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("FieldsType")]
public class FieldsType: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _FiTyCode;
[JsonPropertyName("fitycode")]
public string FiTyCode
{
get { return _FiTyCode; }
set { _FiTyCode = value; }
}
private string _FiTyName;
[JsonPropertyName("fityname")]
public string FiTyName
{
get { return _FiTyName; }
set { _FiTyName = value; }
}
private DateTime? _FiTyTimestamp;
[JsonPropertyName("fitytimestamp")]
public DateTime? FiTyTimestamp
{
get { return _FiTyTimestamp; }
set { _FiTyTimestamp = value; }
}
private bool? _FiTyActive;
[JsonPropertyName("fityactive")]
public bool? FiTyActive
{
get { return _FiTyActive; }
set { _FiTyActive = value; }
}
}
}
