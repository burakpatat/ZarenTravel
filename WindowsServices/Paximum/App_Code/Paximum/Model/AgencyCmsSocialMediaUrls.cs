using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyCmsSocialMediaUrls")]
public class AgencyCmsSocialMediaUrls: IEntity
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
private string _HomeUrl;
[JsonPropertyName("homeurl")]
public string HomeUrl
{
get { return _HomeUrl; }
set { _HomeUrl = value; }
}
private string _FacebookUrl;
[JsonPropertyName("facebookurl")]
public string FacebookUrl
{
get { return _FacebookUrl; }
set { _FacebookUrl = value; }
}
private string _YoutubeUrl;
[JsonPropertyName("youtubeurl")]
public string YoutubeUrl
{
get { return _YoutubeUrl; }
set { _YoutubeUrl = value; }
}
private string _PinterestUrl;
[JsonPropertyName("pinteresturl")]
public string PinterestUrl
{
get { return _PinterestUrl; }
set { _PinterestUrl = value; }
}
private string _TwitterUrl;
[JsonPropertyName("twitterurl")]
public string TwitterUrl
{
get { return _TwitterUrl; }
set { _TwitterUrl = value; }
}
private string _LinkedInUrl;
[JsonPropertyName("linkedinurl")]
public string LinkedInUrl
{
get { return _LinkedInUrl; }
set { _LinkedInUrl = value; }
}
private string _InstagramUrl;
[JsonPropertyName("instagramurl")]
public string InstagramUrl
{
get { return _InstagramUrl; }
set { _InstagramUrl = value; }
}
private string _ViemoUrl;
[JsonPropertyName("viemourl")]
public string ViemoUrl
{
get { return _ViemoUrl; }
set { _ViemoUrl = value; }
}
}
}
