using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Menu")]
public class Menu: IEntity
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
private string _TitleEng;
[JsonPropertyName("titleeng")]
public string TitleEng
{
get { return _TitleEng; }
set { _TitleEng = value; }
}
private string _TitleArabic;
[JsonPropertyName("titlearabic")]
public string TitleArabic
{
get { return _TitleArabic; }
set { _TitleArabic = value; }
}
private string _Url;
[JsonPropertyName("url")]
public string Url
{
get { return _Url; }
set { _Url = value; }
}
private string _Icon;
[JsonPropertyName("icon")]
public string Icon
{
get { return _Icon; }
set { _Icon = value; }
}
private string _Color;
[JsonPropertyName("color")]
public string Color
{
get { return _Color; }
set { _Color = value; }
}
}
}
