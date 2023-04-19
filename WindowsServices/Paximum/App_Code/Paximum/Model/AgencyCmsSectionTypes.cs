using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyCmsSectionTypes")]
public class AgencyCmsSectionTypes: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
private DateTime? _UpdateBy;
[JsonPropertyName("updateby")]
public DateTime? UpdateBy
{
get { return _UpdateBy; }
set { _UpdateBy = value; }
}
private DateTime? _CreatedBy;
[JsonPropertyName("createdby")]
public DateTime? CreatedBy
{
get { return _CreatedBy; }
set { _CreatedBy = value; }
}
private DateTime? _Updated;
[JsonPropertyName("updated")]
public DateTime? Updated
{
get { return _Updated; }
set { _Updated = value; }
}
private DateTime? _Created;
[JsonPropertyName("created")]
public DateTime? Created
{
get { return _Created; }
set { _Created = value; }
}
}
}
