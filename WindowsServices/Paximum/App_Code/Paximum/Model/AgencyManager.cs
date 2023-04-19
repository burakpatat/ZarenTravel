using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyManager")]
public class AgencyManager: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AgencyUserId;
[JsonPropertyName("agencyuserid")]
public int? AgencyUserId
{
get { return _AgencyUserId; }
set { _AgencyUserId = value; }
}
private int? _Statu;
[JsonPropertyName("statu")]
public int? Statu
{
get { return _Statu; }
set { _Statu = value; }
}
private int? _MicrositeId;
[JsonPropertyName("micrositeid")]
public int? MicrositeId
{
get { return _MicrositeId; }
set { _MicrositeId = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
}
}
