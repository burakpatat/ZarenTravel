using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsOther")]
public class AgencyMicroSiteSettingsOther: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private bool? _AskForIdAndBirthdate;
[JsonPropertyName("askforidandbirthdate")]
public bool? AskForIdAndBirthdate
{
get { return _AskForIdAndBirthdate; }
set { _AskForIdAndBirthdate = value; }
}
private bool? _IdeaBrochureIndexing;
[JsonPropertyName("ideabrochureindexing")]
public bool? IdeaBrochureIndexing
{
get { return _IdeaBrochureIndexing; }
set { _IdeaBrochureIndexing = value; }
}
private bool? _ShowTotalPriceInBrochure;
[JsonPropertyName("showtotalpriceinbrochure")]
public bool? ShowTotalPriceInBrochure
{
get { return _ShowTotalPriceInBrochure; }
set { _ShowTotalPriceInBrochure = value; }
}
private bool? _ShowImagePaymentMethodInFooter;
[JsonPropertyName("showimagepaymentmethodinfooter")]
public bool? ShowImagePaymentMethodInFooter
{
get { return _ShowImagePaymentMethodInFooter; }
set { _ShowImagePaymentMethodInFooter = value; }
}
private bool? _PendingPaymentAutoCancellation;
[JsonPropertyName("pendingpaymentautocancellation")]
public bool? PendingPaymentAutoCancellation
{
get { return _PendingPaymentAutoCancellation; }
set { _PendingPaymentAutoCancellation = value; }
}
private bool? _ShowWhatsAppGetButton;
[JsonPropertyName("showwhatsappgetbutton")]
public bool? ShowWhatsAppGetButton
{
get { return _ShowWhatsAppGetButton; }
set { _ShowWhatsAppGetButton = value; }
}
private string _WhatsAppNumber;
[JsonPropertyName("whatsappnumber")]
public string WhatsAppNumber
{
get { return _WhatsAppNumber; }
set { _WhatsAppNumber = value; }
}
private bool? _ShowAgencyIdInDropdownInsteadOfAgencyName;
[JsonPropertyName("showagencyidindropdowninsteadofagencyname")]
public bool? ShowAgencyIdInDropdownInsteadOfAgencyName
{
get { return _ShowAgencyIdInDropdownInsteadOfAgencyName; }
set { _ShowAgencyIdInDropdownInsteadOfAgencyName = value; }
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
