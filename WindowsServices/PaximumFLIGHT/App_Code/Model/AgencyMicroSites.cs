using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSites")]
public class AgencyMicroSites: IEntity
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
private string _Domain;
[JsonPropertyName("domain")]
public string Domain
{
get { return _Domain; }
set { _Domain = value; }
}
private string _SubDomain;
[JsonPropertyName("subdomain")]
public string SubDomain
{
get { return _SubDomain; }
set { _SubDomain = value; }
}
private DateTime? _CreatedDate;
[JsonPropertyName("createddate")]
public DateTime? CreatedDate
{
get { return _CreatedDate; }
set { _CreatedDate = value; }
}
private DateTime? _UpdatedDate;
[JsonPropertyName("updateddate")]
public DateTime? UpdatedDate
{
get { return _UpdatedDate; }
set { _UpdatedDate = value; }
}
private int? _CreatedBy;
[JsonPropertyName("createdby")]
public int? CreatedBy
{
get { return _CreatedBy; }
set { _CreatedBy = value; }
}
private int? _UpdatedBy;
[JsonPropertyName("updatedby")]
public int? UpdatedBy
{
get { return _UpdatedBy; }
set { _UpdatedBy = value; }
}
private string _RedirectUrl;
[JsonPropertyName("redirecturl")]
public string RedirectUrl
{
get { return _RedirectUrl; }
set { _RedirectUrl = value; }
}
private string _CollectivePassword;
[JsonPropertyName("collectivepassword")]
public string CollectivePassword
{
get { return _CollectivePassword; }
set { _CollectivePassword = value; }
}
}
}
