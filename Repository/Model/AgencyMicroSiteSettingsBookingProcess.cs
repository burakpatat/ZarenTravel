using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsBookingProcess")]
public class AgencyMicroSiteSettingsBookingProcess: IEntity
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
private int? _PaymentOption;
[JsonPropertyName("paymentoption")]
public int? PaymentOption
{
get { return _PaymentOption; }
set { _PaymentOption = value; }
}
private int? _AllowB2CUserInvoice;
[JsonPropertyName("allowb2cuserinvoice")]
public int? AllowB2CUserInvoice
{
get { return _AllowB2CUserInvoice; }
set { _AllowB2CUserInvoice = value; }
}
private bool? _RequireAgencyBookingProcess;
[JsonPropertyName("requireagencybookingprocess")]
public bool? RequireAgencyBookingProcess
{
get { return _RequireAgencyBookingProcess; }
set { _RequireAgencyBookingProcess = value; }
}
private bool? _EnableCrossSellTicket;
[JsonPropertyName("enablecrosssellticket")]
public bool? EnableCrossSellTicket
{
get { return _EnableCrossSellTicket; }
set { _EnableCrossSellTicket = value; }
}
private bool? _EnableCrossSellRentalCars;
[JsonPropertyName("enablecrosssellrentalcars")]
public bool? EnableCrossSellRentalCars
{
get { return _EnableCrossSellRentalCars; }
set { _EnableCrossSellRentalCars = value; }
}
private bool? _EnableCrossSellCrossSelling;
[JsonPropertyName("enablecrosssellcrossselling")]
public bool? EnableCrossSellCrossSelling
{
get { return _EnableCrossSellCrossSelling; }
set { _EnableCrossSellCrossSelling = value; }
}
private bool? _EnableCrossSellTransports;
[JsonPropertyName("enablecrossselltransports")]
public bool? EnableCrossSellTransports
{
get { return _EnableCrossSellTransports; }
set { _EnableCrossSellTransports = value; }
}
private bool? _EnableCrossSellTransfers;
[JsonPropertyName("enablecrossselltransfers")]
public bool? EnableCrossSellTransfers
{
get { return _EnableCrossSellTransfers; }
set { _EnableCrossSellTransfers = value; }
}
private bool? _NotifyChangesRequotingSavedIdea;
[JsonPropertyName("notifychangesrequotingsavedidea")]
public bool? NotifyChangesRequotingSavedIdea
{
get { return _NotifyChangesRequotingSavedIdea; }
set { _NotifyChangesRequotingSavedIdea = value; }
}
private decimal? _MaxTolerancePrice;
[JsonPropertyName("maxtoleranceprice")]
public decimal? MaxTolerancePrice
{
get { return _MaxTolerancePrice; }
set { _MaxTolerancePrice = value; }
}
private int? _MaxToleranceAmountId;
[JsonPropertyName("maxtoleranceamountid")]
public int? MaxToleranceAmountId
{
get { return _MaxToleranceAmountId; }
set { _MaxToleranceAmountId = value; }
}
private int? _MaxToleranceCurrencyId;
[JsonPropertyName("maxtolerancecurrencyid")]
public int? MaxToleranceCurrencyId
{
get { return _MaxToleranceCurrencyId; }
set { _MaxToleranceCurrencyId = value; }
}
private bool? _B2BUsersManuelServicesEnable;
[JsonPropertyName("b2busersmanuelservicesenable")]
public bool? B2BUsersManuelServicesEnable
{
get { return _B2BUsersManuelServicesEnable; }
set { _B2BUsersManuelServicesEnable = value; }
}
private bool? _ShowFareBreakdownOnTransports;
[JsonPropertyName("showfarebreakdownontransports")]
public bool? ShowFareBreakdownOnTransports
{
get { return _ShowFareBreakdownOnTransports; }
set { _ShowFareBreakdownOnTransports = value; }
}
private bool? _SetFlightTaxesAsNonCommissionAble;
[JsonPropertyName("setflighttaxesasnoncommissionable")]
public bool? SetFlightTaxesAsNonCommissionAble
{
get { return _SetFlightTaxesAsNonCommissionAble; }
set { _SetFlightTaxesAsNonCommissionAble = value; }
}
private int? _DefaultReplicatorbookingmodeForB2B;
[JsonPropertyName("defaultreplicatorbookingmodeforb2b")]
public int? DefaultReplicatorbookingmodeForB2B
{
get { return _DefaultReplicatorbookingmodeForB2B; }
set { _DefaultReplicatorbookingmodeForB2B = value; }
}
private int? _DefaultReplicatorbookingmodeForB2C;
[JsonPropertyName("defaultreplicatorbookingmodeforb2c")]
public int? DefaultReplicatorbookingmodeForB2C
{
get { return _DefaultReplicatorbookingmodeForB2C; }
set { _DefaultReplicatorbookingmodeForB2C = value; }
}
private int? _SelectAppearDigitalBrochuresForB2BUsers;
[JsonPropertyName("selectappeardigitalbrochuresforb2busers")]
public int? SelectAppearDigitalBrochuresForB2BUsers
{
get { return _SelectAppearDigitalBrochuresForB2BUsers; }
set { _SelectAppearDigitalBrochuresForB2BUsers = value; }
}
private int? _SelectAppearDigitalBrochuresForB2CUsers;
[JsonPropertyName("selectappeardigitalbrochuresforb2cusers")]
public int? SelectAppearDigitalBrochuresForB2CUsers
{
get { return _SelectAppearDigitalBrochuresForB2CUsers; }
set { _SelectAppearDigitalBrochuresForB2CUsers = value; }
}
private bool? _ForOnRequestContracts;
[JsonPropertyName("foronrequestcontracts")]
public bool? ForOnRequestContracts
{
get { return _ForOnRequestContracts; }
set { _ForOnRequestContracts = value; }
}
}
}
