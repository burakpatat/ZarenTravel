using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PaymentReservationStatus")]
public class PaymentReservationStatus: IEntity
{
private int? _Id;
[JsonPropertyName("id")]
public int? Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Description;
[JsonPropertyName("description")]
public string Description
{
get { return _Description; }
set { _Description = value; }
}
private string _About;
[JsonPropertyName("about")]
public string About
{
get { return _About; }
set { _About = value; }
}
}
}
