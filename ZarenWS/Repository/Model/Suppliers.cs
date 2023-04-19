using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Suppliers")]
public class Suppliers: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _SupplierId;
[JsonPropertyName("supplierid")]
public int? SupplierId
{
get { return _SupplierId; }
set { _SupplierId = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _BriefDescription;
[Key]
[JsonPropertyName("briefdescription")]
public string BriefDescription
{
get { return _BriefDescription; }
set { _BriefDescription = value; }
}
private string _Website;
[JsonPropertyName("website")]
public string Website
{
get { return _Website; }
set { _Website = value; }
}
private int? _SourceMarketCountryId;
[JsonPropertyName("sourcemarketcountryid")]
public int? SourceMarketCountryId
{
get { return _SourceMarketCountryId; }
set { _SourceMarketCountryId = value; }
}
private string _Logo;
[JsonPropertyName("logo")]
public string Logo
{
get { return _Logo; }
set { _Logo = value; }
}
private bool? _AcceptSupplier;
[JsonPropertyName("acceptsupplier")]
public bool? AcceptSupplier
{
get { return _AcceptSupplier; }
set { _AcceptSupplier = value; }
}
private bool? _AcceptReseller;
[JsonPropertyName("acceptreseller")]
public bool? AcceptReseller
{
get { return _AcceptReseller; }
set { _AcceptReseller = value; }
}
private bool? _AcceptProducts;
[JsonPropertyName("acceptproducts")]
public bool? AcceptProducts
{
get { return _AcceptProducts; }
set { _AcceptProducts = value; }
}
private int? _SupplierTypeId;
[JsonPropertyName("suppliertypeid")]
public int? SupplierTypeId
{
get { return _SupplierTypeId; }
set { _SupplierTypeId = value; }
}
private bool? _IsSupplier;
[JsonPropertyName("issupplier")]
public bool? IsSupplier
{
get { return _IsSupplier; }
set { _IsSupplier = value; }
}
private bool? _IsReseller;
[JsonPropertyName("isreseller")]
public bool? IsReseller
{
get { return _IsReseller; }
set { _IsReseller = value; }
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
