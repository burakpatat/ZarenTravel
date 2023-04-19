using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("DatabaseValueTypes")]
public class DatabaseValueTypes: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _FrontEndName;
[JsonPropertyName("frontendname")]
public string FrontEndName
{
get { return _FrontEndName; }
set { _FrontEndName = value; }
}
private string _SqlName;
[JsonPropertyName("sqlname")]
public string SqlName
{
get { return _SqlName; }
set { _SqlName = value; }
}
}
}
