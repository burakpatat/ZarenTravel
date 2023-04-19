using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Features")]
public class Features: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CommercialName;
[JsonPropertyName("commercialname")]
public string CommercialName
{
get { return _CommercialName; }
set { _CommercialName = value; }
}
private int? _ServiceGroupId;
[JsonPropertyName("servicegroupid")]
public int? ServiceGroupId
{
get { return _ServiceGroupId; }
set { _ServiceGroupId = value; }
}
private int? _PricingTypeId;
[JsonPropertyName("pricingtypeid")]
public int? PricingTypeId
{
get { return _PricingTypeId; }
set { _PricingTypeId = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private int? _LanguageId;
[JsonPropertyName("languageid")]
public int? LanguageId
{
get { return _LanguageId; }
set { _LanguageId = value; }
}
private string _SystemId;
[JsonPropertyName("systemid")]
public string SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
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
private int? _FlightBrandsId;
[JsonPropertyName("flightbrandsid")]
public int? FlightBrandsId
{
get { return _FlightBrandsId; }
set { _FlightBrandsId = value; }
}
}
}
