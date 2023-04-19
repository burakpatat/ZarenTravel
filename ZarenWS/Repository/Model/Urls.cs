using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Urls")]
public class Urls: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _FriendlyUrl;
[JsonPropertyName("friendlyurl")]
public string FriendlyUrl
{
get { return _FriendlyUrl; }
set { _FriendlyUrl = value; }
}
private int? _PageID;
[JsonPropertyName("pageid")]
public int? PageID
{
get { return _PageID; }
set { _PageID = value; }
}
private string _PageName;
[JsonPropertyName("pagename")]
public string PageName
{
get { return _PageName; }
set { _PageName = value; }
}
private int? _PageView;
[JsonPropertyName("pageview")]
public int? PageView
{
get { return _PageView; }
set { _PageView = value; }
}
private int? _LanguageID;
[JsonPropertyName("languageid")]
public int? LanguageID
{
get { return _LanguageID; }
set { _LanguageID = value; }
}
private int? _IsDefault;
[JsonPropertyName("isdefault")]
public int? IsDefault
{
get { return _IsDefault; }
set { _IsDefault = value; }
}
}
}
