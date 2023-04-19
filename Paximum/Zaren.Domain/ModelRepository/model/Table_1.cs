using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Table_1")]
public class Table_1: IEntity
{
private int? _Id;
[JsonPropertyName("id")]
public int? Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _Agen;
[JsonPropertyName("agen")]
public string Agen
{
get { return _Agen; }
set { _Agen = value; }
}
}
}
