using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsInvoice")]
public class AgencyMicroSiteSettingsInvoice: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private string _NumberPrefix;
[JsonPropertyName("numberprefix")]
public string NumberPrefix
{
get { return _NumberPrefix; }
set { _NumberPrefix = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _Address;
[JsonPropertyName("address")]
public string Address
{
get { return _Address; }
set { _Address = value; }
}
private int? _Country;
[JsonPropertyName("country")]
public int? Country
{
get { return _Country; }
set { _Country = value; }
}
private string _Email;
[JsonPropertyName("email")]
public string Email
{
get { return _Email; }
set { _Email = value; }
}
private string _City;
[JsonPropertyName("city")]
public string City
{
get { return _City; }
set { _City = value; }
}
private string _VAT;
[JsonPropertyName("vat")]
public string VAT
{
get { return _VAT; }
set { _VAT = value; }
}
private decimal? _TaxesByPercentage;
[JsonPropertyName("taxesbypercentage")]
public decimal? TaxesByPercentage
{
get { return _TaxesByPercentage; }
set { _TaxesByPercentage = value; }
}
private string _BillingDetails;
[JsonPropertyName("billingdetails")]
public string BillingDetails
{
get { return _BillingDetails; }
set { _BillingDetails = value; }
}
private string _BankDetails;
[JsonPropertyName("bankdetails")]
public string BankDetails
{
get { return _BankDetails; }
set { _BankDetails = value; }
}
private string _TaxesDetails;
[JsonPropertyName("taxesdetails")]
public string TaxesDetails
{
get { return _TaxesDetails; }
set { _TaxesDetails = value; }
}
private string _LegalFooter;
[JsonPropertyName("legalfooter")]
public string LegalFooter
{
get { return _LegalFooter; }
set { _LegalFooter = value; }
}
private bool? _DirectOperatorToAgencyBilling;
[JsonPropertyName("directoperatortoagencybilling")]
public bool? DirectOperatorToAgencyBilling
{
get { return _DirectOperatorToAgencyBilling; }
set { _DirectOperatorToAgencyBilling = value; }
}
private string _MailBody;
[JsonPropertyName("mailbody")]
public string MailBody
{
get { return _MailBody; }
set { _MailBody = value; }
}
}
}
