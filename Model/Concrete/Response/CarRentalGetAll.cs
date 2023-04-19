using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CarRentalGetAllResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CaRtCode;
[JsonPropertyName("caRtCode")]
public string CaRtCode
{
get { return _CaRtCode; }
set { _CaRtCode = value; }
}
private string _CaRtName;
[JsonPropertyName("caRtName")]
public string CaRtName
{
get { return _CaRtName; }
set { _CaRtName = value; }
}
private DateTime? _CaRtTimestamp;
[JsonPropertyName("caRtTimestamp")]
public DateTime? CaRtTimestamp
{
get { return _CaRtTimestamp; }
set { _CaRtTimestamp = value; }
}
private bool? _CaRtActive;
[JsonPropertyName("caRtActive")]
public bool? CaRtActive
{
get { return _CaRtActive; }
set { _CaRtActive = value; }
}
}
}
