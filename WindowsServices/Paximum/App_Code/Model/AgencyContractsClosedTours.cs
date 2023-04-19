using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyContractsClosedTours")]
public class AgencyContractsClosedTours: IEntity
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
private bool? _IsSelect;
[JsonPropertyName("isselect")]
public bool? IsSelect
{
get { return _IsSelect; }
set { _IsSelect = value; }
}
private bool? _IsActive;
[JsonPropertyName("isactive")]
public bool? IsActive
{
get { return _IsActive; }
set { _IsActive = value; }
}
private bool? _MarketPlace;
[JsonPropertyName("marketplace")]
public bool? MarketPlace
{
get { return _MarketPlace; }
set { _MarketPlace = value; }
}
private bool? _Pro;
[JsonPropertyName("pro")]
public bool? Pro
{
get { return _Pro; }
set { _Pro = value; }
}
private bool? _Extension;
[JsonPropertyName("extension")]
public bool? Extension
{
get { return _Extension; }
set { _Extension = value; }
}
private string _Code;
[JsonPropertyName("code")]
public string Code
{
get { return _Code; }
set { _Code = value; }
}
private string _Creator;
[JsonPropertyName("creator")]
public string Creator
{
get { return _Creator; }
set { _Creator = value; }
}
private DateTime? _DateCreation;
[JsonPropertyName("datecreation")]
public DateTime? DateCreation
{
get { return _DateCreation; }
set { _DateCreation = value; }
}
private DateTime? _LastUpdate;
[JsonPropertyName("lastupdate")]
public DateTime? LastUpdate
{
get { return _LastUpdate; }
set { _LastUpdate = value; }
}
private DateTime? _UpdateBy;
[JsonPropertyName("updateby")]
public DateTime? UpdateBy
{
get { return _UpdateBy; }
set { _UpdateBy = value; }
}
private string _Supplier;
[JsonPropertyName("supplier")]
public string Supplier
{
get { return _Supplier; }
set { _Supplier = value; }
}
private string _TourSupplierName;
[JsonPropertyName("toursuppliername")]
public string TourSupplierName
{
get { return _TourSupplierName; }
set { _TourSupplierName = value; }
}
private string _Destinations;
[JsonPropertyName("destinations")]
public string Destinations
{
get { return _Destinations; }
set { _Destinations = value; }
}
private int? _Nights;
[JsonPropertyName("nights")]
public int? Nights
{
get { return _Nights; }
set { _Nights = value; }
}
private string _ContractaFrom;
[JsonPropertyName("contractafrom")]
public string ContractaFrom
{
get { return _ContractaFrom; }
set { _ContractaFrom = value; }
}
private string _ContractTo;
[JsonPropertyName("contractto")]
public string ContractTo
{
get { return _ContractTo; }
set { _ContractTo = value; }
}
}
}
