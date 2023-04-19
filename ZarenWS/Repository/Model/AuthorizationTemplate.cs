using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AuthorizationTemplate")]
public class AuthorizationTemplate: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private int? _Products;
[JsonPropertyName("products")]
public int? Products
{
get { return _Products; }
set { _Products = value; }
}
private int? _Users;
[JsonPropertyName("users")]
public int? Users
{
get { return _Users; }
set { _Users = value; }
}
private int? _DatabaseTables;
[JsonPropertyName("databasetables")]
public int? DatabaseTables
{
get { return _DatabaseTables; }
set { _DatabaseTables = value; }
}
private int? _CanInsert;
[JsonPropertyName("caninsert")]
public int? CanInsert
{
get { return _CanInsert; }
set { _CanInsert = value; }
}
private int? _CanUpdate;
[JsonPropertyName("canupdate")]
public int? CanUpdate
{
get { return _CanUpdate; }
set { _CanUpdate = value; }
}
private int? _CanDetail;
[JsonPropertyName("candetail")]
public int? CanDetail
{
get { return _CanDetail; }
set { _CanDetail = value; }
}
private int? _CanList;
[JsonPropertyName("canlist")]
public int? CanList
{
get { return _CanList; }
set { _CanList = value; }
}
private int? _CanDelete;
[JsonPropertyName("candelete")]
public int? CanDelete
{
get { return _CanDelete; }
set { _CanDelete = value; }
}
private int? _CanRemove;
[JsonPropertyName("canremove")]
public int? CanRemove
{
get { return _CanRemove; }
set { _CanRemove = value; }
}
private int? _OnLeftMenu;
[JsonPropertyName("onleftmenu")]
public int? OnLeftMenu
{
get { return _OnLeftMenu; }
set { _OnLeftMenu = value; }
}
private int? _Departments;
[JsonPropertyName("departments")]
public int? Departments
{
get { return _Departments; }
set { _Departments = value; }
}
}
}
