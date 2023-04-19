using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsEmailVoucher")]
public class AgencyMicroSiteSettingsEmailVoucher: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private bool? _SendBookingEmailFromAgency;
[JsonPropertyName("sendbookingemailfromagency")]
public bool? SendBookingEmailFromAgency
{
get { return _SendBookingEmailFromAgency; }
set { _SendBookingEmailFromAgency = value; }
}
private bool? _FromEmailAgency;
[JsonPropertyName("fromemailagency")]
public bool? FromEmailAgency
{
get { return _FromEmailAgency; }
set { _FromEmailAgency = value; }
}
private bool? _AvoidSendBookingMailToOperator;
[JsonPropertyName("avoidsendbookingmailtooperator")]
public bool? AvoidSendBookingMailToOperator
{
get { return _AvoidSendBookingMailToOperator; }
set { _AvoidSendBookingMailToOperator = value; }
}
private bool? _HideCoverPageAndDayByDayPdf;
[JsonPropertyName("hidecoverpageanddaybydaypdf")]
public bool? HideCoverPageAndDayByDayPdf
{
get { return _HideCoverPageAndDayByDayPdf; }
set { _HideCoverPageAndDayByDayPdf = value; }
}
private bool? _PrintPDFVoucherOneService;
[JsonPropertyName("printpdfvoucheroneservice")]
public bool? PrintPDFVoucherOneService
{
get { return _PrintPDFVoucherOneService; }
set { _PrintPDFVoucherOneService = value; }
}
private bool? _ExcludePricesBookingsOnlinePDFVoucher;
[JsonPropertyName("excludepricesbookingsonlinepdfvoucher")]
public bool? ExcludePricesBookingsOnlinePDFVoucher
{
get { return _ExcludePricesBookingsOnlinePDFVoucher; }
set { _ExcludePricesBookingsOnlinePDFVoucher = value; }
}
private bool? _SendMoAppEmailReminder;
[JsonPropertyName("sendmoappemailreminder")]
public bool? SendMoAppEmailReminder
{
get { return _SendMoAppEmailReminder; }
set { _SendMoAppEmailReminder = value; }
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
}
}
