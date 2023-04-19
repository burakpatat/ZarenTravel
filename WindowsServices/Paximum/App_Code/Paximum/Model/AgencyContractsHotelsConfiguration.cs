using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyContractsHotelsConfiguration")]
public class AgencyContractsHotelsConfiguration: IEntity
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
private int? _ReleaseDay;
[JsonPropertyName("releaseday")]
public int? ReleaseDay
{
get { return _ReleaseDay; }
set { _ReleaseDay = value; }
}
private byte? _MinimumStay;
[JsonPropertyName("minimumstay")]
public byte? MinimumStay
{
get { return _MinimumStay; }
set { _MinimumStay = value; }
}
private int? _MaximumStay;
[JsonPropertyName("maximumstay")]
public int? MaximumStay
{
get { return _MaximumStay; }
set { _MaximumStay = value; }
}
private int? _MinAgeStay;
[JsonPropertyName("minagestay")]
public int? MinAgeStay
{
get { return _MinAgeStay; }
set { _MinAgeStay = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyid")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private int? _SecurityDepositAmount;
[JsonPropertyName("securitydepositamount")]
public int? SecurityDepositAmount
{
get { return _SecurityDepositAmount; }
set { _SecurityDepositAmount = value; }
}
private int? _SecurityDepositCurrencyId;
[JsonPropertyName("securitydepositcurrencyid")]
public int? SecurityDepositCurrencyId
{
get { return _SecurityDepositCurrencyId; }
set { _SecurityDepositCurrencyId = value; }
}
private DateTime? _CheckInDateFrom;
[JsonPropertyName("checkindatefrom")]
public DateTime? CheckInDateFrom
{
get { return _CheckInDateFrom; }
set { _CheckInDateFrom = value; }
}
private DateTime? _CheckInDateTo;
[JsonPropertyName("checkindateto")]
public DateTime? CheckInDateTo
{
get { return _CheckInDateTo; }
set { _CheckInDateTo = value; }
}
private DateTime? _LateArrivalFrom;
[JsonPropertyName("latearrivalfrom")]
public DateTime? LateArrivalFrom
{
get { return _LateArrivalFrom; }
set { _LateArrivalFrom = value; }
}
private DateTime? _LateArrivalTo;
[JsonPropertyName("latearrivalto")]
public DateTime? LateArrivalTo
{
get { return _LateArrivalTo; }
set { _LateArrivalTo = value; }
}
private int? _LateArrivalAmount;
[JsonPropertyName("latearrivalamount")]
public int? LateArrivalAmount
{
get { return _LateArrivalAmount; }
set { _LateArrivalAmount = value; }
}
private int? _LateArrivalCurrencyId;
[JsonPropertyName("latearrivalcurrencyid")]
public int? LateArrivalCurrencyId
{
get { return _LateArrivalCurrencyId; }
set { _LateArrivalCurrencyId = value; }
}
private int? _CheckInDayId;
[JsonPropertyName("checkindayid")]
public int? CheckInDayId
{
get { return _CheckInDayId; }
set { _CheckInDayId = value; }
}
private DateTime? _CheckOutUntil;
[JsonPropertyName("checkoutuntil")]
public DateTime? CheckOutUntil
{
get { return _CheckOutUntil; }
set { _CheckOutUntil = value; }
}
private DateTime? _EarlyDepartureFrom;
[JsonPropertyName("earlydeparturefrom")]
public DateTime? EarlyDepartureFrom
{
get { return _EarlyDepartureFrom; }
set { _EarlyDepartureFrom = value; }
}
private DateTime? _EarlyDepartureTo;
[JsonPropertyName("earlydepartureto")]
public DateTime? EarlyDepartureTo
{
get { return _EarlyDepartureTo; }
set { _EarlyDepartureTo = value; }
}
private decimal? _EarlyDepartureCostAmount;
[JsonPropertyName("earlydeparturecostamount")]
public decimal? EarlyDepartureCostAmount
{
get { return _EarlyDepartureCostAmount; }
set { _EarlyDepartureCostAmount = value; }
}
private int? _EarlyDepartureCostCurrencyId;
[JsonPropertyName("earlydeparturecostcurrencyid")]
public int? EarlyDepartureCostCurrencyId
{
get { return _EarlyDepartureCostCurrencyId; }
set { _EarlyDepartureCostCurrencyId = value; }
}
private int? _CheckOutDayId;
[JsonPropertyName("checkoutdayid")]
public int? CheckOutDayId
{
get { return _CheckOutDayId; }
set { _CheckOutDayId = value; }
}
}
}
