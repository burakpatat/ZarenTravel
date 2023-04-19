using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Items")]
public class Items: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _Type;
[JsonPropertyName("type")]
public int? Type
{
get { return _Type; }
set { _Type = value; }
}
private int? _GeolocationId;
[JsonPropertyName("geolocationid")]
public int? GeolocationId
{
get { return _GeolocationId; }
set { _GeolocationId = value; }
}
private int? _CoutryId;
[JsonPropertyName("coutryid")]
public int? CoutryId
{
get { return _CoutryId; }
set { _CoutryId = value; }
}
private int? _StateId;
[JsonPropertyName("stateid")]
public int? StateId
{
get { return _StateId; }
set { _StateId = value; }
}
private int? _CityId;
[JsonPropertyName("cityid")]
public int? CityId
{
get { return _CityId; }
set { _CityId = value; }
}
private int? _GiataInfoId;
[JsonPropertyName("giatainfoid")]
public int? GiataInfoId
{
get { return _GiataInfoId; }
set { _GiataInfoId = value; }
}
private int? _Provider;
[JsonPropertyName("provider")]
public int? Provider
{
get { return _Provider; }
set { _Provider = value; }
}
private int? _SystemId;
[JsonPropertyName("systemid")]
public int? SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
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
private int? _LanguageId;
[JsonPropertyName("languageid")]
public int? LanguageId
{
get { return _LanguageId; }
set { _LanguageId = value; }
}
}
}
