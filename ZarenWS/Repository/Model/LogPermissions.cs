using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("LogPermissions")]
public class LogPermissions: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private int? _UserID;
[JsonPropertyName("userid")]
public int? UserID
{
get { return _UserID; }
set { _UserID = value; }
}
private DateTime? _ChangeDate;
[JsonPropertyName("changedate")]
public DateTime? ChangeDate
{
get { return _ChangeDate; }
set { _ChangeDate = value; }
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
private int? _CanGetOne;
[JsonPropertyName("cangetone")]
public int? CanGetOne
{
get { return _CanGetOne; }
set { _CanGetOne = value; }
}
private int? _CanGetList;
[JsonPropertyName("cangetlist")]
public int? CanGetList
{
get { return _CanGetList; }
set { _CanGetList = value; }
}
private int? _CanDelete;
[JsonPropertyName("candelete")]
public int? CanDelete
{
get { return _CanDelete; }
set { _CanDelete = value; }
}
private int? _CanView;
[JsonPropertyName("canview")]
public int? CanView
{
get { return _CanView; }
set { _CanView = value; }
}
private int? _CanClassInit;
[JsonPropertyName("canclassinit")]
public int? CanClassInit
{
get { return _CanClassInit; }
set { _CanClassInit = value; }
}
private int? _CanClassInsert;
[JsonPropertyName("canclassinsert")]
public int? CanClassInsert
{
get { return _CanClassInsert; }
set { _CanClassInsert = value; }
}
private int? _CanClassList;
[JsonPropertyName("canclasslist")]
public int? CanClassList
{
get { return _CanClassList; }
set { _CanClassList = value; }
}
private int? _CanClassUpdate;
[JsonPropertyName("canclassupdate")]
public int? CanClassUpdate
{
get { return _CanClassUpdate; }
set { _CanClassUpdate = value; }
}
private int? _Products;
[JsonPropertyName("products")]
public int? Products
{
get { return _Products; }
set { _Products = value; }
}
private string _Note;
[JsonPropertyName("note")]
public string Note
{
get { return _Note; }
set { _Note = value; }
}
private int? _ModifyBy;
[JsonPropertyName("modifyby")]
public int? ModifyBy
{
get { return _ModifyBy; }
set { _ModifyBy = value; }
}
private DateTime? _ModifyDate;
[JsonPropertyName("modifydate")]
public DateTime? ModifyDate
{
get { return _ModifyDate; }
set { _ModifyDate = value; }
}
}
}
