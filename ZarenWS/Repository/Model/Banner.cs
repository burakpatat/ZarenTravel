using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Banner")]
public class Banner: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private int? _LanguageID;
[JsonPropertyName("languageid")]
public int? LanguageID
{
get { return _LanguageID; }
set { _LanguageID = value; }
}
private string _ImagePath;
[JsonPropertyName("imagepath")]
public string ImagePath
{
get { return _ImagePath; }
set { _ImagePath = value; }
}
private string _MobileImagePath;
[JsonPropertyName("mobileimagepath")]
public string MobileImagePath
{
get { return _MobileImagePath; }
set { _MobileImagePath = value; }
}
private int? _TableOrder;
[JsonPropertyName("tableorder")]
public int? TableOrder
{
get { return _TableOrder; }
set { _TableOrder = value; }
}
private string _Text;
[JsonPropertyName("text")]
public string Text
{
get { return _Text; }
set { _Text = value; }
}
private string _Text2;
[JsonPropertyName("text2")]
public string Text2
{
get { return _Text2; }
set { _Text2 = value; }
}
private string _Text3;
[JsonPropertyName("text3")]
public string Text3
{
get { return _Text3; }
set { _Text3 = value; }
}
}
}
