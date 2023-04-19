using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsTermsConditions")]
public class AgencyMicroSiteSettingsTermsConditions: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private bool? _PackageTerms;
[JsonPropertyName("packageterms")]
public bool? PackageTerms
{
get { return _PackageTerms; }
set { _PackageTerms = value; }
}
private bool? _VisaTerms;
[JsonPropertyName("visaterms")]
public bool? VisaTerms
{
get { return _VisaTerms; }
set { _VisaTerms = value; }
}
private bool? _GDPRCheckBoxes;
[JsonPropertyName("gdprcheckboxes")]
public bool? GDPRCheckBoxes
{
get { return _GDPRCheckBoxes; }
set { _GDPRCheckBoxes = value; }
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
