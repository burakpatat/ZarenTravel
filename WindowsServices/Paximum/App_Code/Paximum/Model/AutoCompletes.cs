using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AutoCompletes")]
public class AutoCompletes: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
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
private int? _Type;
[JsonPropertyName("type")]
public int? Type
{
get { return _Type; }
set { _Type = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private string _SystemId;
[JsonPropertyName("systemid")]
public string SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
}
private string _SystemType;
[JsonPropertyName("systemtype")]
public string SystemType
{
get { return _SystemType; }
set { _SystemType = value; }
}
private int? _LanguageId;
[JsonPropertyName("languageid")]
public int? LanguageId
{
get { return _LanguageId; }
set { _LanguageId = value; }
}
}
}
