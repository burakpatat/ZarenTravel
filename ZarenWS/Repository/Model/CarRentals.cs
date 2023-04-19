using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("CarRentals")]
public class CarRentals: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CaRtCode;
[JsonPropertyName("cartcode")]
public string CaRtCode
{
get { return _CaRtCode; }
set { _CaRtCode = value; }
}
private string _CaRtName;
[JsonPropertyName("cartname")]
public string CaRtName
{
get { return _CaRtName; }
set { _CaRtName = value; }
}
private DateTime? _CaRtTimestamp;
[JsonPropertyName("carttimestamp")]
public DateTime? CaRtTimestamp
{
get { return _CaRtTimestamp; }
set { _CaRtTimestamp = value; }
}
private bool? _CaRtActive;
[JsonPropertyName("cartactive")]
public bool? CaRtActive
{
get { return _CaRtActive; }
set { _CaRtActive = value; }
}
}
}
