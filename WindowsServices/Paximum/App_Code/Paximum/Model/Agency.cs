using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Agency")]
public class Agency: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _Statu;
[JsonPropertyName("statu")]
public int? Statu
{
get { return _Statu; }
set { _Statu = value; }
}
private int? _AgencyManager;
[JsonPropertyName("agencymanager")]
public int? AgencyManager
{
get { return _AgencyManager; }
set { _AgencyManager = value; }
}
private string _InvoiceName;
[JsonPropertyName("invoicename")]
public string InvoiceName
{
get { return _InvoiceName; }
set { _InvoiceName = value; }
}
private string _City;
[JsonPropertyName("city")]
public string City
{
get { return _City; }
set { _City = value; }
}
private int? _Country;
[JsonPropertyName("country")]
public int? Country
{
get { return _Country; }
set { _Country = value; }
}
private string _WhatsAppNo;
[JsonPropertyName("whatsappno")]
public string WhatsAppNo
{
get { return _WhatsAppNo; }
set { _WhatsAppNo = value; }
}
private string _Email;
[JsonPropertyName("email")]
public string Email
{
get { return _Email; }
set { _Email = value; }
}
private double? _Taxes;
[JsonPropertyName("taxes")]
public double? Taxes
{
get { return _Taxes; }
set { _Taxes = value; }
}
private int? _ExternalId;
[JsonPropertyName("externalid")]
public int? ExternalId
{
get { return _ExternalId; }
set { _ExternalId = value; }
}
private string _Address;
[JsonPropertyName("address")]
public string Address
{
get { return _Address; }
set { _Address = value; }
}
private string _Provience;
[JsonPropertyName("provience")]
public string Provience
{
get { return _Provience; }
set { _Provience = value; }
}
private string _DocumentNumber;
[JsonPropertyName("documentnumber")]
public string DocumentNumber
{
get { return _DocumentNumber; }
set { _DocumentNumber = value; }
}
private string _ContactPersonName;
[JsonPropertyName("contactpersonname")]
public string ContactPersonName
{
get { return _ContactPersonName; }
set { _ContactPersonName = value; }
}
private string _BillingEmails;
[JsonPropertyName("billingemails")]
public string BillingEmails
{
get { return _BillingEmails; }
set { _BillingEmails = value; }
}
private string _BusinessName;
[JsonPropertyName("businessname")]
public string BusinessName
{
get { return _BusinessName; }
set { _BusinessName = value; }
}
private string _PostalCode;
[JsonPropertyName("postalcode")]
public string PostalCode
{
get { return _PostalCode; }
set { _PostalCode = value; }
}
private string _Region;
[JsonPropertyName("region")]
public string Region
{
get { return _Region; }
set { _Region = value; }
}
private string _PhoneNo;
[JsonPropertyName("phoneno")]
public string PhoneNo
{
get { return _PhoneNo; }
set { _PhoneNo = value; }
}
private string _ContactPersonLastName;
[JsonPropertyName("contactpersonlastname")]
public string ContactPersonLastName
{
get { return _ContactPersonLastName; }
set { _ContactPersonLastName = value; }
}
private string _ManagementGroup;
[JsonPropertyName("managementgroup")]
public string ManagementGroup
{
get { return _ManagementGroup; }
set { _ManagementGroup = value; }
}
private string _Remarks;
[JsonPropertyName("remarks")]
public string Remarks
{
get { return _Remarks; }
set { _Remarks = value; }
}
private string _WinterHours;
[JsonPropertyName("winterhours")]
public string WinterHours
{
get { return _WinterHours; }
set { _WinterHours = value; }
}
private string _SummerHours;
[JsonPropertyName("summerhours")]
public string SummerHours
{
get { return _SummerHours; }
set { _SummerHours = value; }
}
private int? _InvoiceTypeId;
[JsonPropertyName("invoicetypeid")]
public int? InvoiceTypeId
{
get { return _InvoiceTypeId; }
set { _InvoiceTypeId = value; }
}
private bool? _DeferredPaymentAllowed;
[JsonPropertyName("deferredpaymentallowed")]
public bool? DeferredPaymentAllowed
{
get { return _DeferredPaymentAllowed; }
set { _DeferredPaymentAllowed = value; }
}
private int? _DeferredPaymentDays;
[JsonPropertyName("deferredpaymentdays")]
public int? DeferredPaymentDays
{
get { return _DeferredPaymentDays; }
set { _DeferredPaymentDays = value; }
}
private decimal? _DeferredPaymentLimit;
[JsonPropertyName("deferredpaymentlimit")]
public decimal? DeferredPaymentLimit
{
get { return _DeferredPaymentLimit; }
set { _DeferredPaymentLimit = value; }
}
private int? _DeferredPaymentLimitCurrency;
[JsonPropertyName("deferredpaymentlimitcurrency")]
public int? DeferredPaymentLimitCurrency
{
get { return _DeferredPaymentLimitCurrency; }
set { _DeferredPaymentLimitCurrency = value; }
}
private int? _MinimumFirstPaymentAmount;
[JsonPropertyName("minimumfirstpaymentamount")]
public int? MinimumFirstPaymentAmount
{
get { return _MinimumFirstPaymentAmount; }
set { _MinimumFirstPaymentAmount = value; }
}
private bool? _MinimumFirstPaymentIsByPercentage;
[JsonPropertyName("minimumfirstpaymentisbypercentage")]
public bool? MinimumFirstPaymentIsByPercentage
{
get { return _MinimumFirstPaymentIsByPercentage; }
set { _MinimumFirstPaymentIsByPercentage = value; }
}
private string _GDSIdentifierForGalileo;
[JsonPropertyName("gdsidentifierforgalileo")]
public string GDSIdentifierForGalileo
{
get { return _GDSIdentifierForGalileo; }
set { _GDSIdentifierForGalileo = value; }
}
private bool? _HasCreditOrDepositPaymentAllowed;
[JsonPropertyName("hascreditordepositpaymentallowed")]
public bool? HasCreditOrDepositPaymentAllowed
{
get { return _HasCreditOrDepositPaymentAllowed; }
set { _HasCreditOrDepositPaymentAllowed = value; }
}
}
}
