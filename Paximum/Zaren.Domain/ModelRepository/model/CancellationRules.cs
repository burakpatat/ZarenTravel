using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("CancellationRules")]
public class CancellationRules: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _CancellationSeasonId;
[JsonPropertyName("cancellationseasonid")]
public int? CancellationSeasonId
{
get { return _CancellationSeasonId; }
set { _CancellationSeasonId = value; }
}
private decimal? _Cost;
[JsonPropertyName("cost")]
public decimal? Cost
{
get { return _Cost; }
set { _Cost = value; }
}
private int? _CostType;
[JsonPropertyName("costtype")]
public int? CostType
{
get { return _CostType; }
set { _CostType = value; }
}
private int? _FromDays;
[JsonPropertyName("fromdays")]
public int? FromDays
{
get { return _FromDays; }
set { _FromDays = value; }
}
private int? _ToDays;
[JsonPropertyName("todays")]
public int? ToDays
{
get { return _ToDays; }
set { _ToDays = value; }
}
}
}
