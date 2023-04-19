using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Extensions")]
public class Extensions: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private int? _FileType;
[JsonPropertyName("filetype")]
public int? FileType
{
get { return _FileType; }
set { _FileType = value; }
}
private string _ExtensionName;
[JsonPropertyName("extensionname")]
public string ExtensionName
{
get { return _ExtensionName; }
set { _ExtensionName = value; }
}
private string _KeyName;
[JsonPropertyName("keyname")]
public string KeyName
{
get { return _KeyName; }
set { _KeyName = value; }
}
private string _FilePath;
[JsonPropertyName("filepath")]
public string FilePath
{
get { return _FilePath; }
set { _FilePath = value; }
}
private bool? _IsRealName;
[JsonPropertyName("isrealname")]
public bool? IsRealName
{
get { return _IsRealName; }
set { _IsRealName = value; }
}
}
}
