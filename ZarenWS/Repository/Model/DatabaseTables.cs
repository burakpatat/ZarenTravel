using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("DatabaseTables")]
public class DatabaseTables: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _TableName;
[JsonPropertyName("tablename")]
public string TableName
{
get { return _TableName; }
set { _TableName = value; }
}
private string _DisplayName;
[JsonPropertyName("displayname")]
public string DisplayName
{
get { return _DisplayName; }
set { _DisplayName = value; }
}
private bool? _IsRouting;
[JsonPropertyName("isrouting")]
public bool? IsRouting
{
get { return _IsRouting; }
set { _IsRouting = value; }
}
private bool? _HasMultiLanguage;
[JsonPropertyName("hasmultilanguage")]
public bool? HasMultiLanguage
{
get { return _HasMultiLanguage; }
set { _HasMultiLanguage = value; }
}
private string _FrontPageName;
[JsonPropertyName("frontpagename")]
public string FrontPageName
{
get { return _FrontPageName; }
set { _FrontPageName = value; }
}
private bool? _ForUser;
[JsonPropertyName("foruser")]
public bool? ForUser
{
get { return _ForUser; }
set { _ForUser = value; }
}
private int? _CMSGridSize;
[JsonPropertyName("cmsgridsize")]
public int? CMSGridSize
{
get { return _CMSGridSize; }
set { _CMSGridSize = value; }
}
private string _CMSLinkedTables;
[JsonPropertyName("cmslinkedtables")]
public string CMSLinkedTables
{
get { return _CMSLinkedTables; }
set { _CMSLinkedTables = value; }
}
private int? _TableOrder;
[JsonPropertyName("tableorder")]
public int? TableOrder
{
get { return _TableOrder; }
set { _TableOrder = value; }
}
private int? _ParentTable;
[JsonPropertyName("parenttable")]
public int? ParentTable
{
get { return _ParentTable; }
set { _ParentTable = value; }
}
private string _CMSIcon;
[JsonPropertyName("cmsicon")]
public string CMSIcon
{
get { return _CMSIcon; }
set { _CMSIcon = value; }
}
private bool? _CanGenerate;
[JsonPropertyName("cangenerate")]
public bool? CanGenerate
{
get { return _CanGenerate; }
set { _CanGenerate = value; }
}
private DateTime? _CreateDate;
[JsonPropertyName("createdate")]
public DateTime? CreateDate
{
get { return _CreateDate; }
set { _CreateDate = value; }
}
}
}
