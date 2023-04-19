using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class PNRGetByAgencyIdResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyId")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _PCCId;
[JsonPropertyName("pCCId")]
public int? PCCId
{
get { return _PCCId; }
set { _PCCId = value; }
}
private int? _CompanyId;
[JsonPropertyName("companyId")]
public int? CompanyId
{
get { return _CompanyId; }
set { _CompanyId = value; }
}
private int? _PassengerId;
[JsonPropertyName("passengerId")]
public int? PassengerId
{
get { return _PassengerId; }
set { _PassengerId = value; }
}
private string _PNRRecord;
[JsonPropertyName("pNRRecord")]
public string PNRRecord
{
get { return _PNRRecord; }
set { _PNRRecord = value; }
}
private DateTime? _PNRTimestamp;
[JsonPropertyName("pNRTimestamp")]
public DateTime? PNRTimestamp
{
get { return _PNRTimestamp; }
set { _PNRTimestamp = value; }
}
private bool? _PNRActive;
[JsonPropertyName("pNRActive")]
public bool? PNRActive
{
get { return _PNRActive; }
set { _PNRActive = value; }
}
}
}
