using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteProperties")]
public class AgencyMicroSiteProperties: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AgencyMicroSiteId;
[JsonPropertyName("agencymicrositeid")]
public int? AgencyMicroSiteId
{
get { return _AgencyMicroSiteId; }
set { _AgencyMicroSiteId = value; }
}
private string _DefaultLogo;
[JsonPropertyName("defaultlogo")]
public string DefaultLogo
{
get { return _DefaultLogo; }
set { _DefaultLogo = value; }
}
private bool? _HasLogoOnHeader;
[JsonPropertyName("haslogoonheader")]
public bool? HasLogoOnHeader
{
get { return _HasLogoOnHeader; }
set { _HasLogoOnHeader = value; }
}
private string _WhiteLogo;
[JsonPropertyName("whitelogo")]
public string WhiteLogo
{
get { return _WhiteLogo; }
set { _WhiteLogo = value; }
}
private string _MobileLogo;
[JsonPropertyName("mobilelogo")]
public string MobileLogo
{
get { return _MobileLogo; }
set { _MobileLogo = value; }
}
private string _Favicon;
[JsonPropertyName("favicon")]
public string Favicon
{
get { return _Favicon; }
set { _Favicon = value; }
}
private string _MetaTitle;
[JsonPropertyName("metatitle")]
public string MetaTitle
{
get { return _MetaTitle; }
set { _MetaTitle = value; }
}
private string _MetaDescription;
[JsonPropertyName("metadescription")]
public string MetaDescription
{
get { return _MetaDescription; }
set { _MetaDescription = value; }
}
private string _OgImage;
[JsonPropertyName("ogimage")]
public string OgImage
{
get { return _OgImage; }
set { _OgImage = value; }
}
private string _OgDescription;
[JsonPropertyName("ogdescription")]
public string OgDescription
{
get { return _OgDescription; }
set { _OgDescription = value; }
}
private string _OgTitle;
[JsonPropertyName("ogtitle")]
public string OgTitle
{
get { return _OgTitle; }
set { _OgTitle = value; }
}
}
}
