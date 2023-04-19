using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PossibleQuery")]
public class PossibleQuery: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Query;
[JsonPropertyName("query")]
public string Query
{
get { return _Query; }
set { _Query = value; }
}
}
}
