using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PNRCustomFields")]
public class PNRCustomFields: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _FiTyId;
[JsonPropertyName("fityid")]
public int? FiTyId
{
get { return _FiTyId; }
set { _FiTyId = value; }
}
private int? _PNRId;
[JsonPropertyName("pnrid")]
public int? PNRId
{
get { return _PNRId; }
set { _PNRId = value; }
}
private string _PnCuValue;
[JsonPropertyName("pncuvalue")]
public string PnCuValue
{
get { return _PnCuValue; }
set { _PnCuValue = value; }
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
