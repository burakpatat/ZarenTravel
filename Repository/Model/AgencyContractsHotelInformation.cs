using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyContractsHotelInformation")]
public class AgencyContractsHotelInformation: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _Agencyıd;
[JsonPropertyName("agencyid")]
public int? Agencyıd
{
get { return _Agencyıd; }
set { _Agencyıd = value; }
}
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
private int? _LangId;
[JsonPropertyName("langid")]
public int? LangId
{
get { return _LangId; }
set { _LangId = value; }
}
private int? _HotelCategoryId;
[JsonPropertyName("hotelcategoryid")]
public int? HotelCategoryId
{
get { return _HotelCategoryId; }
set { _HotelCategoryId = value; }
}
private int? _HotelImageId;
[JsonPropertyName("hotelimageid")]
public int? HotelImageId
{
get { return _HotelImageId; }
set { _HotelImageId = value; }
}
private int? _HotelFacilityId;
[JsonPropertyName("hotelfacilityid")]
public int? HotelFacilityId
{
get { return _HotelFacilityId; }
set { _HotelFacilityId = value; }
}
private bool? _IsActive;
[JsonPropertyName("isactive")]
public bool? IsActive
{
get { return _IsActive; }
set { _IsActive = value; }
}
private bool? _OnlyHolidayPackage;
[JsonPropertyName("onlyholidaypackage")]
public bool? OnlyHolidayPackage
{
get { return _OnlyHolidayPackage; }
set { _OnlyHolidayPackage = value; }
}
private int? _CreatedByUser;
[JsonPropertyName("createdbyuser")]
public int? CreatedByUser
{
get { return _CreatedByUser; }
set { _CreatedByUser = value; }
}
private int? _SupplierBy;
[JsonPropertyName("supplierby")]
public int? SupplierBy
{
get { return _SupplierBy; }
set { _SupplierBy = value; }
}
private string _HotelCode;
[JsonPropertyName("hotelcode")]
public string HotelCode
{
get { return _HotelCode; }
set { _HotelCode = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private int? _HotelChainId;
[JsonPropertyName("hotelchainid")]
public int? HotelChainId
{
get { return _HotelChainId; }
set { _HotelChainId = value; }
}
private string _Address;
[JsonPropertyName("address")]
public string Address
{
get { return _Address; }
set { _Address = value; }
}
private string _LocationName;
[JsonPropertyName("locationname")]
public string LocationName
{
get { return _LocationName; }
set { _LocationName = value; }
}
private string _PostalCode;
[JsonPropertyName("postalcode")]
public string PostalCode
{
get { return _PostalCode; }
set { _PostalCode = value; }
}
private int? _CountryId;
[JsonPropertyName("countryid")]
public int? CountryId
{
get { return _CountryId; }
set { _CountryId = value; }
}
private string _Phone;
[JsonPropertyName("phone")]
public string Phone
{
get { return _Phone; }
set { _Phone = value; }
}
private string _Fax;
[JsonPropertyName("fax")]
public string Fax
{
get { return _Fax; }
set { _Fax = value; }
}
private string _Email;
[JsonPropertyName("email")]
public string Email
{
get { return _Email; }
set { _Email = value; }
}
private decimal? _Latitude;
[JsonPropertyName("latitude")]
public decimal? Latitude
{
get { return _Latitude; }
set { _Latitude = value; }
}
private decimal? _Longitude;
[JsonPropertyName("longitude")]
public decimal? Longitude
{
get { return _Longitude; }
set { _Longitude = value; }
}
private string _PossibleDestinations;
[JsonPropertyName("possibledestinations")]
public string PossibleDestinations
{
get { return _PossibleDestinations; }
set { _PossibleDestinations = value; }
}
private string _Description;
[JsonPropertyName("description")]
public string Description
{
get { return _Description; }
set { _Description = value; }
}
private string _Remark;
[JsonPropertyName("remark")]
public string Remark
{
get { return _Remark; }
set { _Remark = value; }
}
}
}
