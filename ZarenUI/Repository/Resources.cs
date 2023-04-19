using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Resources")]
public class Resources: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _LanguageCode;
[JsonPropertyName("languagecode")]
public string LanguageCode
{
get { return _LanguageCode; }
set { _LanguageCode = value; }
}
private string _ResourceKey;
[JsonPropertyName("resourcekey")]
public string ResourceKey
{
get { return _ResourceKey; }
set { _ResourceKey = value; }
}
private string _ResourceValue;
[JsonPropertyName("resourcevalue")]
public string ResourceValue
{
get { return _ResourceValue; }
set { _ResourceValue = value; }
}
}
}
