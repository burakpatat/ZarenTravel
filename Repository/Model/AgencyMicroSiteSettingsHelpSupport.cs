using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsHelpSupport")]
public class AgencyMicroSiteSettingsHelpSupport: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private bool? _HideFeedback;
[JsonPropertyName("hidefeedback")]
public bool? HideFeedback
{
get { return _HideFeedback; }
set { _HideFeedback = value; }
}
private bool? _OpenHelpVideosModalNewTab;
[JsonPropertyName("openhelpvideosmodalnewtab")]
public bool? OpenHelpVideosModalNewTab
{
get { return _OpenHelpVideosModalNewTab; }
set { _OpenHelpVideosModalNewTab = value; }
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
