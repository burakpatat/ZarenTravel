using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Providers")]
public class Providers: IEntity
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
private string _Address;
[JsonPropertyName("address")]
public string Address
{
get { return _Address; }
set { _Address = value; }
}
private string _Website;
[JsonPropertyName("website")]
public string Website
{
get { return _Website; }
set { _Website = value; }
}
private int? _ComercialContactId;
[JsonPropertyName("comercialcontactid")]
public int? ComercialContactId
{
get { return _ComercialContactId; }
set { _ComercialContactId = value; }
}
private int? _ReservationContactId;
[JsonPropertyName("reservationcontactid")]
public int? ReservationContactId
{
get { return _ReservationContactId; }
set { _ReservationContactId = value; }
}
private int? _FinanceContactId;
[JsonPropertyName("financecontactid")]
public int? FinanceContactId
{
get { return _FinanceContactId; }
set { _FinanceContactId = value; }
}
}
}
