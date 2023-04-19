using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("SegmentsServices")]
public class SegmentsServices: IEntity
{
private int _SegmentsId;
[Key]
[JsonPropertyName("segmentsid")]
public int SegmentsId
{
get { return _SegmentsId; }
set { _SegmentsId = value; }
}
private int _ServicesId;
[Key]
[JsonPropertyName("servicesid")]
public int ServicesId
{
get { return _ServicesId; }
set { _ServicesId = value; }
}
}
}
