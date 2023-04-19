using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class PNRCustomFieldsUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _FiTyId;
[JsonPropertyName("fiTyId")]
public int? FiTyId
{
get { return _FiTyId; }
set { _FiTyId = value; }
}
private int? _PNRId;
[JsonPropertyName("pNRId")]
public int? PNRId
{
get { return _PNRId; }
set { _PNRId = value; }
}
private string _PnCuValue;
[JsonPropertyName("pnCuValue")]
public string PnCuValue
{
get { return _PnCuValue; }
set { _PnCuValue = value; }
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
