using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AspNetUserLogins")]
public class AspNetUserLogins: IEntity
{
private string _LoginProvider;
[Key]
[JsonPropertyName("loginprovider")]
public string LoginProvider
{
get { return _LoginProvider; }
set { _LoginProvider = value; }
}
private string _ProviderKey;
[Key]
[JsonPropertyName("providerkey")]
public string ProviderKey
{
get { return _ProviderKey; }
set { _ProviderKey = value; }
}
private string _ProviderDisplayName;
[JsonPropertyName("providerdisplayname")]
public string ProviderDisplayName
{
get { return _ProviderDisplayName; }
set { _ProviderDisplayName = value; }
}
private string _UserId;
[Key]
[JsonPropertyName("userid")]
public string UserId
{
get { return _UserId; }
set { _UserId = value; }
}
}
}
