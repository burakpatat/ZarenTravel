using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AspNetUserTokens")]
public class AspNetUserTokens: IEntity
{
private string _UserId;
[Key]
[JsonPropertyName("userid")]
public string UserId
{
get { return _UserId; }
set { _UserId = value; }
}
private string _LoginProvider;
[Key]
[JsonPropertyName("loginprovider")]
public string LoginProvider
{
get { return _LoginProvider; }
set { _LoginProvider = value; }
}
private string _Name;
[Key]
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _Value;
[JsonPropertyName("value")]
public string Value
{
get { return _Value; }
set { _Value = value; }
}
}
}
