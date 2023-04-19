using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class PCCGetByIDResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _PCCCode;
[JsonPropertyName("pCCCode")]
public string PCCCode
{
get { return _PCCCode; }
set { _PCCCode = value; }
}
private int? _PCCIata;
[JsonPropertyName("pCCIata")]
public int? PCCIata
{
get { return _PCCIata; }
set { _PCCIata = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyId")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _GDSId;
[JsonPropertyName("gDSId")]
public int? GDSId
{
get { return _GDSId; }
set { _GDSId = value; }
}
private DateTime? _PCCTimestamp;
[JsonPropertyName("pCCTimestamp")]
public DateTime? PCCTimestamp
{
get { return _PCCTimestamp; }
set { _PCCTimestamp = value; }
}
private bool? _PCCActive;
[JsonPropertyName("pCCActive")]
public bool? PCCActive
{
get { return _PCCActive; }
set { _PCCActive = value; }
}
}
}
