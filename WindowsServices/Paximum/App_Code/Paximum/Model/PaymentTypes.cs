using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PaymentTypes")]
public class PaymentTypes: IEntity
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
private bool? _ForDeferredB2B;
[JsonPropertyName("fordeferredb2b")]
public bool? ForDeferredB2B
{
get { return _ForDeferredB2B; }
set { _ForDeferredB2B = value; }
}
private bool? _ForDeferredB2C;
[JsonPropertyName("fordeferredb2c")]
public bool? ForDeferredB2C
{
get { return _ForDeferredB2C; }
set { _ForDeferredB2C = value; }
}
private string _SystemId;
[JsonPropertyName("systemid")]
public string SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
}
}
}
