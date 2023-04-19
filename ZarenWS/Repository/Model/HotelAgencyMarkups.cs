using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("HotelAgencyMarkups")]
public class HotelAgencyMarkups: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _HotelId;
[JsonPropertyName("hotelid")]
public int? HotelId
{
get { return _HotelId; }
set { _HotelId = value; }
}
private decimal? _MarkUp;
[JsonPropertyName("markup")]
public decimal? MarkUp
{
get { return _MarkUp; }
set { _MarkUp = value; }
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
