using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Agencies")]
public class Agencies: IEntity
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
private string _PaymentPolitics;
[JsonPropertyName("paymentpolitics")]
public string PaymentPolitics
{
get { return _PaymentPolitics; }
set { _PaymentPolitics = value; }
}
private decimal? _MarkUp;
[JsonPropertyName("markup")]
public decimal? MarkUp
{
get { return _MarkUp; }
set { _MarkUp = value; }
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
