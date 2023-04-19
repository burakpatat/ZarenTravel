using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsSearchSettings")]
public class AgencyMicroSiteSettingsSearchSettings: IEntity
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
private bool? _SearchBoxDropdownMenuFormatAutoComplete;
[JsonPropertyName("searchboxdropdownmenuformatautocomplete")]
public bool? SearchBoxDropdownMenuFormatAutoComplete
{
get { return _SearchBoxDropdownMenuFormatAutoComplete; }
set { _SearchBoxDropdownMenuFormatAutoComplete = value; }
}
private bool? _ShowThemesHomePageSlidingFormat;
[JsonPropertyName("showthemeshomepageslidingformat")]
public bool? ShowThemesHomePageSlidingFormat
{
get { return _ShowThemesHomePageSlidingFormat; }
set { _ShowThemesHomePageSlidingFormat = value; }
}
private bool? _AskForDepartureLocationHolidayPackage;
[JsonPropertyName("askfordeparturelocationholidaypackage")]
public bool? AskForDepartureLocationHolidayPackage
{
get { return _AskForDepartureLocationHolidayPackage; }
set { _AskForDepartureLocationHolidayPackage = value; }
}
private bool? _InAccommodationSearchEngineAllowSearchHotelName;
[JsonPropertyName("inaccommodationsearchengineallowsearchhotelname")]
public bool? InAccommodationSearchEngineAllowSearchHotelName
{
get { return _InAccommodationSearchEngineAllowSearchHotelName; }
set { _InAccommodationSearchEngineAllowSearchHotelName = value; }
}
private bool? _InAccommodationSearchEngineAllowSearchInterestPoint;
[JsonPropertyName("inaccommodationsearchengineallowsearchinterestpoint")]
public bool? InAccommodationSearchEngineAllowSearchInterestPoint
{
get { return _InAccommodationSearchEngineAllowSearchInterestPoint; }
set { _InAccommodationSearchEngineAllowSearchInterestPoint = value; }
}
private int? _AgencyMicroSiteSettingsAccommodationSortType;
[JsonPropertyName("agencymicrositesettingsaccommodationsorttype")]
public int? AgencyMicroSiteSettingsAccommodationSortType
{
get { return _AgencyMicroSiteSettingsAccommodationSortType; }
set { _AgencyMicroSiteSettingsAccommodationSortType = value; }
}
private int? _AgencyMicroSiteSettingsTicketSortType;
[JsonPropertyName("agencymicrositesettingsticketsorttype")]
public int? AgencyMicroSiteSettingsTicketSortType
{
get { return _AgencyMicroSiteSettingsTicketSortType; }
set { _AgencyMicroSiteSettingsTicketSortType = value; }
}
private int? _SelectTransportSortType;
[JsonPropertyName("selecttransportsorttype")]
public int? SelectTransportSortType
{
get { return _SelectTransportSortType; }
set { _SelectTransportSortType = value; }
}
private int? _SelectHolidayPackageSortType;
[JsonPropertyName("selectholidaypackagesorttype")]
public int? SelectHolidayPackageSortType
{
get { return _SelectHolidayPackageSortType; }
set { _SelectHolidayPackageSortType = value; }
}
private int? _AccommodationSearchResults;
[JsonPropertyName("accommodationsearchresults")]
public int? AccommodationSearchResults
{
get { return _AccommodationSearchResults; }
set { _AccommodationSearchResults = value; }
}
private int? _TicketSearchResultsUseThisViewResult;
[JsonPropertyName("ticketsearchresultsusethisviewresult")]
public int? TicketSearchResultsUseThisViewResult
{
get { return _TicketSearchResultsUseThisViewResult; }
set { _TicketSearchResultsUseThisViewResult = value; }
}
private bool? _SameListOriginsListDestinations;
[JsonPropertyName("samelistoriginslistdestinations")]
public bool? SameListOriginsListDestinations
{
get { return _SameListOriginsListDestinations; }
set { _SameListOriginsListDestinations = value; }
}
private int? _AgencyMicroSiteSettingEnableMultiDay;
[JsonPropertyName("agencymicrositesettingenablemultiday")]
public int? AgencyMicroSiteSettingEnableMultiDay
{
get { return _AgencyMicroSiteSettingEnableMultiDay; }
set { _AgencyMicroSiteSettingEnableMultiDay = value; }
}
private bool? _EnableRequestActivities;
[JsonPropertyName("enablerequestactivities")]
public bool? EnableRequestActivities
{
get { return _EnableRequestActivities; }
set { _EnableRequestActivities = value; }
}
private bool? _B2BUsersSeeProvidersQuotingService;
[JsonPropertyName("b2busersseeprovidersquotingservice")]
public bool? B2BUsersSeeProvidersQuotingService
{
get { return _B2BUsersSeeProvidersQuotingService; }
set { _B2BUsersSeeProvidersQuotingService = value; }
}
private bool? _DonotShowTourProviderB2BUsers;
[JsonPropertyName("donotshowtourproviderb2busers")]
public bool? DonotShowTourProviderB2BUsers
{
get { return _DonotShowTourProviderB2BUsers; }
set { _DonotShowTourProviderB2BUsers = value; }
}
private bool? _DonotShowTourProviderB2CUsers;
[JsonPropertyName("donotshowtourproviderb2cusers")]
public bool? DonotShowTourProviderB2CUsers
{
get { return _DonotShowTourProviderB2CUsers; }
set { _DonotShowTourProviderB2CUsers = value; }
}
private bool? _ShowLocationSearchbox;
[JsonPropertyName("showlocationsearchbox")]
public bool? ShowLocationSearchbox
{
get { return _ShowLocationSearchbox; }
set { _ShowLocationSearchbox = value; }
}
}
}
