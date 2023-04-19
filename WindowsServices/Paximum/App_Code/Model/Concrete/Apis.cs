using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Apis")]
public class Apis: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _ApiName;
[JsonPropertyName("apiname")]
public string ApiName
{
get { return _ApiName; }
set { _ApiName = value; }
}
private string _UserKey;
[JsonPropertyName("userkey")]
public string UserKey
{
get { return _UserKey; }
set { _UserKey = value; }
}
private string _Password;
[JsonPropertyName("password")]
public string Password
{
get { return _Password; }
set { _Password = value; }
}
}
}
