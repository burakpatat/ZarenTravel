using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PNRs")]
public class PNRs: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _PCCId;
[JsonPropertyName("pccid")]
public int? PCCId
{
get { return _PCCId; }
set { _PCCId = value; }
}
private int? _CompanyId;
[JsonPropertyName("companyid")]
public int? CompanyId
{
get { return _CompanyId; }
set { _CompanyId = value; }
}
private int? _PassengerId;
[JsonPropertyName("passengerid")]
public int? PassengerId
{
get { return _PassengerId; }
set { _PassengerId = value; }
}
private string _PNRRecord;
[JsonPropertyName("pnrrecord")]
public string PNRRecord
{
get { return _PNRRecord; }
set { _PNRRecord = value; }
}
private DateTime? _PNRTimestamp;
[JsonPropertyName("pnrtimestamp")]
public DateTime? PNRTimestamp
{
get { return _PNRTimestamp; }
set { _PNRTimestamp = value; }
}
private bool? _PNRActive;
[JsonPropertyName("pnractive")]
public bool? PNRActive
{
get { return _PNRActive; }
set { _PNRActive = value; }
}
}
}
