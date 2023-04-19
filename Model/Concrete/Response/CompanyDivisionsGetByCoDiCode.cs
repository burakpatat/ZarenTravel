using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CompanyDivisionsGetByCoDiCodeResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CoDiName;
[JsonPropertyName("coDiName")]
public string CoDiName
{
get { return _CoDiName; }
set { _CoDiName = value; }
}
private string _CoDiCode;
[JsonPropertyName("coDiCode")]
public string CoDiCode
{
get { return _CoDiCode; }
set { _CoDiCode = value; }
}
private DateTime? _CoDiTimestamp;
[JsonPropertyName("coDiTimestamp")]
public DateTime? CoDiTimestamp
{
get { return _CoDiTimestamp; }
set { _CoDiTimestamp = value; }
}
private bool? _CoDiActive;
[JsonPropertyName("coDiActive")]
public bool? CoDiActive
{
get { return _CoDiActive; }
set { _CoDiActive = value; }
}
}
}
