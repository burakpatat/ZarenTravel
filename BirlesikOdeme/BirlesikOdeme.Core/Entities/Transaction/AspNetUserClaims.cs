using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AspNetUserClaims")]
public class AspNetUserClaims: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _UserId;
[Key]
[JsonPropertyName("userid")]
public string UserId
{
get { return _UserId; }
set { _UserId = value; }
}
private string _ClaimType;
[JsonPropertyName("claimtype")]
public string ClaimType
{
get { return _ClaimType; }
set { _ClaimType = value; }
}
private string _ClaimValue;
[JsonPropertyName("claimvalue")]
public string ClaimValue
{
get { return _ClaimValue; }
set { _ClaimValue = value; }
}
}
}
