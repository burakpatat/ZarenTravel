using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("OgSeo")]
public class OgSeo: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private int? _PageType;
[JsonPropertyName("pagetype")]
public int? PageType
{
get { return _PageType; }
set { _PageType = value; }
}
private int? _PageID;
[JsonPropertyName("pageid")]
public int? PageID
{
get { return _PageID; }
set { _PageID = value; }
}
private string _ogImage;
[JsonPropertyName("ogimage")]
public string ogImage
{
get { return _ogImage; }
set { _ogImage = value; }
}
private string _ogDescription;
[JsonPropertyName("ogdescription")]
public string ogDescription
{
get { return _ogDescription; }
set { _ogDescription = value; }
}
private string _ogTitle;
[JsonPropertyName("ogtitle")]
public string ogTitle
{
get { return _ogTitle; }
set { _ogTitle = value; }
}
private string _seoTitle;
[JsonPropertyName("seotitle")]
public string seoTitle
{
get { return _seoTitle; }
set { _seoTitle = value; }
}
private string _seoKeyword;
[JsonPropertyName("seokeyword")]
public string seoKeyword
{
get { return _seoKeyword; }
set { _seoKeyword = value; }
}
private string _seoDescription;
[JsonPropertyName("seodescription")]
public string seoDescription
{
get { return _seoDescription; }
set { _seoDescription = value; }
}
}
}
