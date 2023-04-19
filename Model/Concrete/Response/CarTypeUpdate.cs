using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CarTypeUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CaTyCode;
[JsonPropertyName("caTyCode")]
public string CaTyCode
{
get { return _CaTyCode; }
set { _CaTyCode = value; }
}
private string _CaTyDescription;
[JsonPropertyName("caTyDescription")]
public string CaTyDescription
{
get { return _CaTyDescription; }
set { _CaTyDescription = value; }
}
private DateTime? _CaTyTimestamp;
[JsonPropertyName("caTyTimestamp")]
public DateTime? CaTyTimestamp
{
get { return _CaTyTimestamp; }
set { _CaTyTimestamp = value; }
}
private bool? _CaTyActive;
[JsonPropertyName("caTyActive")]
public bool? CaTyActive
{
get { return _CaTyActive; }
set { _CaTyActive = value; }
}
}
}
