using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("BookingDeals")]
public class BookingDeals: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _BookingId;
[JsonPropertyName("bookingid")]
public int? BookingId
{
get { return _BookingId; }
set { _BookingId = value; }
}
private int? _DealId;
[JsonPropertyName("dealid")]
public int? DealId
{
get { return _DealId; }
set { _DealId = value; }
}
}
}
