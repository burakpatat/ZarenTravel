using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("DatabaseColumns")]
public class DatabaseColumns: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private int? _TableID;
[JsonPropertyName("tableid")]
public int? TableID
{
get { return _TableID; }
set { _TableID = value; }
}
private string _ColumnName;
[JsonPropertyName("columnname")]
public string ColumnName
{
get { return _ColumnName; }
set { _ColumnName = value; }
}
private int? _DbType;
[JsonPropertyName("dbtype")]
public int? DbType
{
get { return _DbType; }
set { _DbType = value; }
}
private bool? _IsRoutingField;
[JsonPropertyName("isroutingfield")]
public bool? IsRoutingField
{
get { return _IsRoutingField; }
set { _IsRoutingField = value; }
}
private int? _CMSInputType;
[JsonPropertyName("cmsinputtype")]
public int? CMSInputType
{
get { return _CMSInputType; }
set { _CMSInputType = value; }
}
private string _CMSColumnTitle;
[JsonPropertyName("cmscolumntitle")]
public string CMSColumnTitle
{
get { return _CMSColumnTitle; }
set { _CMSColumnTitle = value; }
}
private int? _TableOrder;
[JsonPropertyName("tableorder")]
public int? TableOrder
{
get { return _TableOrder; }
set { _TableOrder = value; }
}
private string _SelectedValue;
[JsonPropertyName("selectedvalue")]
public string SelectedValue
{
get { return _SelectedValue; }
set { _SelectedValue = value; }
}
private string _SelectedText;
[JsonPropertyName("selectedtext")]
public string SelectedText
{
get { return _SelectedText; }
set { _SelectedText = value; }
}
private bool? _HasShowedOnList;
[JsonPropertyName("hasshowedonlist")]
public bool? HasShowedOnList
{
get { return _HasShowedOnList; }
set { _HasShowedOnList = value; }
}
private bool? _IsFilter;
[JsonPropertyName("isfilter")]
public bool? IsFilter
{
get { return _IsFilter; }
set { _IsFilter = value; }
}
private string _Resize;
[JsonPropertyName("resize")]
public string Resize
{
get { return _Resize; }
set { _Resize = value; }
}
private bool? _IsLanguageField;
[JsonPropertyName("islanguagefield")]
public bool? IsLanguageField
{
get { return _IsLanguageField; }
set { _IsLanguageField = value; }
}
private bool? _IsPrimary;
[JsonPropertyName("isprimary")]
public bool? IsPrimary
{
get { return _IsPrimary; }
set { _IsPrimary = value; }
}
private bool? _IsSecondry;
[JsonPropertyName("issecondry")]
public bool? IsSecondry
{
get { return _IsSecondry; }
set { _IsSecondry = value; }
}
private string _SelectedDataSourceTable;
[JsonPropertyName("selecteddatasourcetable")]
public string SelectedDataSourceTable
{
get { return _SelectedDataSourceTable; }
set { _SelectedDataSourceTable = value; }
}
private string _JsonName;
[JsonPropertyName("jsonname")]
public string JsonName
{
get { return _JsonName; }
set { _JsonName = value; }
}
private string _Tooltip;
[JsonPropertyName("tooltip")]
public string Tooltip
{
get { return _Tooltip; }
set { _Tooltip = value; }
}
private bool? _IsNullable;
[JsonPropertyName("isnullable")]
public bool? IsNullable
{
get { return _IsNullable; }
set { _IsNullable = value; }
}
private int? _MaxLength;
[JsonPropertyName("maxlength")]
public int? MaxLength
{
get { return _MaxLength; }
set { _MaxLength = value; }
}
private bool? _IsRequired;
[JsonPropertyName("isrequired")]
public bool? IsRequired
{
get { return _IsRequired; }
set { _IsRequired = value; }
}
private bool? _HasDefaultValue;
[JsonPropertyName("hasdefaultvalue")]
public bool? HasDefaultValue
{
get { return _HasDefaultValue; }
set { _HasDefaultValue = value; }
}
private bool? _IsPublic;
[JsonPropertyName("ispublic")]
public bool? IsPublic
{
get { return _IsPublic; }
set { _IsPublic = value; }
}
private bool? _ReturnColumnNameFromCMSTitle;
[JsonPropertyName("returncolumnnamefromcmstitle")]
public bool? ReturnColumnNameFromCMSTitle
{
get { return _ReturnColumnNameFromCMSTitle; }
set { _ReturnColumnNameFromCMSTitle = value; }
}
private string _ErrorDescription;
[JsonPropertyName("errordescription")]
public string ErrorDescription
{
get { return _ErrorDescription; }
set { _ErrorDescription = value; }
}
private string _ParameterDescription;
[JsonPropertyName("parameterdescription")]
public string ParameterDescription
{
get { return _ParameterDescription; }
set { _ParameterDescription = value; }
}
}
}
