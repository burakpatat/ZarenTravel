using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyManager")]
public class AgencyManager: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _UserId;
[JsonPropertyName("userid")]
public int? UserId
{
get { return _UserId; }
set { _UserId = value; }
}
private int? _Statu;
[JsonPropertyName("statu")]
public int? Statu
{
get { return _Statu; }
set { _Statu = value; }
}
private int? _MicrositeId;
[JsonPropertyName("micrositeid")]
public int? MicrositeId
{
get { return _MicrositeId; }
set { _MicrositeId = value; }
}
}
}
