using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyContractsInsuranceBasicData")]
public class AgencyContractsInsuranceBasicData: IEntity
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
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
private DateTime? _CreateDate;
[JsonPropertyName("createdate")]
public DateTime? CreateDate
{
get { return _CreateDate; }
set { _CreateDate = value; }
}
private DateTime? _UpdateTime;
[JsonPropertyName("updatetime")]
public DateTime? UpdateTime
{
get { return _UpdateTime; }
set { _UpdateTime = value; }
}
private int? _CreateBy;
[JsonPropertyName("createby")]
public int? CreateBy
{
get { return _CreateBy; }
set { _CreateBy = value; }
}
private int? _UpdateBy;
[JsonPropertyName("updateby")]
public int? UpdateBy
{
get { return _UpdateBy; }
set { _UpdateBy = value; }
}
private bool? _IsActive;
[JsonPropertyName("isactive")]
public bool? IsActive
{
get { return _IsActive; }
set { _IsActive = value; }
}
private string _PolicyName;
[JsonPropertyName("policyname")]
public string PolicyName
{
get { return _PolicyName; }
set { _PolicyName = value; }
}
private string _PolicyNumber;
[JsonPropertyName("policynumber")]
public string PolicyNumber
{
get { return _PolicyNumber; }
set { _PolicyNumber = value; }
}
private int? _InsuranceTypeId;
[JsonPropertyName("insurancetypeid")]
public int? InsuranceTypeId
{
get { return _InsuranceTypeId; }
set { _InsuranceTypeId = value; }
}
private bool? _SelectByDefault;
[JsonPropertyName("selectbydefault")]
public bool? SelectByDefault
{
get { return _SelectByDefault; }
set { _SelectByDefault = value; }
}
private int? _SupplierId;
[JsonPropertyName("supplierid")]
public int? SupplierId
{
get { return _SupplierId; }
set { _SupplierId = value; }
}
private int? _ServiceProviderId;
[JsonPropertyName("serviceproviderid")]
public int? ServiceProviderId
{
get { return _ServiceProviderId; }
set { _ServiceProviderId = value; }
}
private int? _SelectedInsuranceLanguageId;
[JsonPropertyName("selectedinsurancelanguageid")]
public int? SelectedInsuranceLanguageId
{
get { return _SelectedInsuranceLanguageId; }
set { _SelectedInsuranceLanguageId = value; }
}
private int? _InsuranceSelectedProductTypeId;
[JsonPropertyName("insuranceselectedproducttypeid")]
public int? InsuranceSelectedProductTypeId
{
get { return _InsuranceSelectedProductTypeId; }
set { _InsuranceSelectedProductTypeId = value; }
}
private string _ImageUrl;
[JsonPropertyName("imageurl")]
public string ImageUrl
{
get { return _ImageUrl; }
set { _ImageUrl = value; }
}
private string _ImagePath;
[JsonPropertyName("imagepath")]
public string ImagePath
{
get { return _ImagePath; }
set { _ImagePath = value; }
}
}
}
