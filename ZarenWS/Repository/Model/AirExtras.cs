using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AirExtras")]
public class AirExtras: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AirId;
[JsonPropertyName("airid")]
public int? AirId
{
get { return _AirId; }
set { _AirId = value; }
}
private int? _ExTyId;
[JsonPropertyName("extyid")]
public int? ExTyId
{
get { return _ExTyId; }
set { _ExTyId = value; }
}
private string _AiExDescription;
[JsonPropertyName("aiexdescription")]
public string AiExDescription
{
get { return _AiExDescription; }
set { _AiExDescription = value; }
}
private decimal? _AiExFare;
[JsonPropertyName("aiexfare")]
public decimal? AiExFare
{
get { return _AiExFare; }
set { _AiExFare = value; }
}
private DateTime? _AiExTimestamp;
[JsonPropertyName("aiextimestamp")]
public DateTime? AiExTimestamp
{
get { return _AiExTimestamp; }
set { _AiExTimestamp = value; }
}
private bool? _AiExActive;
[JsonPropertyName("aiexactive")]
public bool? AiExActive
{
get { return _AiExActive; }
set { _AiExActive = value; }
}
}
}
