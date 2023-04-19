using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteDesign")]
public class AgencyMicroSiteDesign: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AgencyMicroSiteId;
[JsonPropertyName("agencymicrositeid")]
public int? AgencyMicroSiteId
{
get { return _AgencyMicroSiteId; }
set { _AgencyMicroSiteId = value; }
}
private int? _ProductType;
[JsonPropertyName("producttype")]
public int? ProductType
{
get { return _ProductType; }
set { _ProductType = value; }
}
private int? _TableOrder;
[JsonPropertyName("tableorder")]
public int? TableOrder
{
get { return _TableOrder; }
set { _TableOrder = value; }
}
private int? _Statu;
[JsonPropertyName("statu")]
public int? Statu
{
get { return _Statu; }
set { _Statu = value; }
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
}
}
