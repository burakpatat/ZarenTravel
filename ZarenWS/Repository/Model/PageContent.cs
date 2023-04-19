using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PageContent")]
public class PageContent: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _Title;
[JsonPropertyName("title")]
public string Title
{
get { return _Title; }
set { _Title = value; }
}
private string _Contents;
[JsonPropertyName("contents")]
public string Contents
{
get { return _Contents; }
set { _Contents = value; }
}
private string _Image;
[JsonPropertyName("image")]
public string Image
{
get { return _Image; }
set { _Image = value; }
}
private int? _LanguageID;
[JsonPropertyName("languageid")]
public int? LanguageID
{
get { return _LanguageID; }
set { _LanguageID = value; }
}
private int? _TableOrder;
[JsonPropertyName("tableorder")]
public int? TableOrder
{
get { return _TableOrder; }
set { _TableOrder = value; }
}
private DateTime? _CreateDate;
[JsonPropertyName("createdate")]
public DateTime? CreateDate
{
get { return _CreateDate; }
set { _CreateDate = value; }
}
private string _PageUrl;
[JsonPropertyName("pageurl")]
public string PageUrl
{
get { return _PageUrl; }
set { _PageUrl = value; }
}
private string _SubTitle;
[JsonPropertyName("subtitle")]
public string SubTitle
{
get { return _SubTitle; }
set { _SubTitle = value; }
}
}
}
