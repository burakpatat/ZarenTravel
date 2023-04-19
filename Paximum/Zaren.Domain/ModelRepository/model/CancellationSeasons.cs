using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("CancellationSeasons")]
public class CancellationSeasons: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _HotelId;
[JsonPropertyName("hotelid")]
public int? HotelId
{
get { return _HotelId; }
set { _HotelId = value; }
}
private DateTime? _StartDate;
[JsonPropertyName("startdate")]
public DateTime? StartDate
{
get { return _StartDate; }
set { _StartDate = value; }
}
private DateTime? _EndDate;
[JsonPropertyName("enddate")]
public DateTime? EndDate
{
get { return _EndDate; }
set { _EndDate = value; }
}
}
}
