using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteDomains")]
public class AgencyMicroSiteDomains: IEntity
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
private string _DomainUrl;
[JsonPropertyName("domainurl")]
public string DomainUrl
{
get { return _DomainUrl; }
set { _DomainUrl = value; }
}
private int? _DefaultLanguageId;
[JsonPropertyName("defaultlanguageid")]
public int? DefaultLanguageId
{
get { return _DefaultLanguageId; }
set { _DefaultLanguageId = value; }
}
private string _DomainHostIP;
[JsonPropertyName("domainhostip")]
public string DomainHostIP
{
get { return _DomainHostIP; }
set { _DomainHostIP = value; }
}
private string _GtagId;
[JsonPropertyName("gtagid")]
public string GtagId
{
get { return _GtagId; }
set { _GtagId = value; }
}
private string _FacebookPixelId;
[JsonPropertyName("facebookpixelid")]
public string FacebookPixelId
{
get { return _FacebookPixelId; }
set { _FacebookPixelId = value; }
}
private string _FacebookDomainVerification;
[JsonPropertyName("facebookdomainverification")]
public string FacebookDomainVerification
{
get { return _FacebookDomainVerification; }
set { _FacebookDomainVerification = value; }
}
private string _GoogleTagManagerId;
[JsonPropertyName("googletagmanagerid")]
public string GoogleTagManagerId
{
get { return _GoogleTagManagerId; }
set { _GoogleTagManagerId = value; }
}
private string _BingAds;
[JsonPropertyName("bingads")]
public string BingAds
{
get { return _BingAds; }
set { _BingAds = value; }
}
private string _AdwordsId;
[JsonPropertyName("adwordsid")]
public string AdwordsId
{
get { return _AdwordsId; }
set { _AdwordsId = value; }
}
private string _AdwordsLabel;
[JsonPropertyName("adwordslabel")]
public string AdwordsLabel
{
get { return _AdwordsLabel; }
set { _AdwordsLabel = value; }
}
private string _KayakPartnerCode;
[JsonPropertyName("kayakpartnercode")]
public string KayakPartnerCode
{
get { return _KayakPartnerCode; }
set { _KayakPartnerCode = value; }
}
private string _TradeTrackerClientId;
[JsonPropertyName("tradetrackerclientid")]
public string TradeTrackerClientId
{
get { return _TradeTrackerClientId; }
set { _TradeTrackerClientId = value; }
}
private string _VePixelId;
[JsonPropertyName("vepixelid")]
public string VePixelId
{
get { return _VePixelId; }
set { _VePixelId = value; }
}
private string _TradeTrackerProductOnlyAccommodation;
[JsonPropertyName("tradetrackerproductonlyaccommodation")]
public string TradeTrackerProductOnlyAccommodation
{
get { return _TradeTrackerProductOnlyAccommodation; }
set { _TradeTrackerProductOnlyAccommodation = value; }
}
private string _TradeTrackerPidOthers;
[JsonPropertyName("tradetrackerpidothers")]
public string TradeTrackerPidOthers
{
get { return _TradeTrackerPidOthers; }
set { _TradeTrackerPidOthers = value; }
}
private string _GoogleSiteVerification;
[JsonPropertyName("googlesiteverification")]
public string GoogleSiteVerification
{
get { return _GoogleSiteVerification; }
set { _GoogleSiteVerification = value; }
}
private string _SiteMapJson;
[JsonPropertyName("sitemapjson")]
public string SiteMapJson
{
get { return _SiteMapJson; }
set { _SiteMapJson = value; }
}
}
}
