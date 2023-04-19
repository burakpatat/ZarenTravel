using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AspNetUserRoles")]
public class AspNetUserRoles: IEntity
{
private string _UserId;
[Key]
[JsonPropertyName("userid")]
public string UserId
{
get { return _UserId; }
set { _UserId = value; }
}
private string _RoleId;
[Key]
[JsonPropertyName("roleid")]
public string RoleId
{
get { return _RoleId; }
set { _RoleId = value; }
}
}
}
