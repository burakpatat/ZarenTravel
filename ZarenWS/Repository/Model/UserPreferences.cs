using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("UserPreferences")]
public class UserPreferences: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private int? _ThemeStyle;
[JsonPropertyName("themestyle")]
public int? ThemeStyle
{
get { return _ThemeStyle; }
set { _ThemeStyle = value; }
}
private int? _UserID;
[JsonPropertyName("userid")]
public int? UserID
{
get { return _UserID; }
set { _UserID = value; }
}
private int? _Products;
[JsonPropertyName("products")]
public int? Products
{
get { return _Products; }
set { _Products = value; }
}
private int? _HeaderColor;
[JsonPropertyName("headercolor")]
public int? HeaderColor
{
get { return _HeaderColor; }
set { _HeaderColor = value; }
}
private int? _SideBarColor;
[JsonPropertyName("sidebarcolor")]
public int? SideBarColor
{
get { return _SideBarColor; }
set { _SideBarColor = value; }
}
}
}
