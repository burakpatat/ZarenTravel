using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("ReservationDetails")]
public class ReservationDetails: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private int? _RezervationID;
[JsonPropertyName("rezervationid")]
public int? RezervationID
{
get { return _RezervationID; }
set { _RezervationID = value; }
}
private int? _PropertID;
[JsonPropertyName("propertid")]
public int? PropertID
{
get { return _PropertID; }
set { _PropertID = value; }
}
private decimal? _PropertPrice;
[JsonPropertyName("propertprice")]
public decimal? PropertPrice
{
get { return _PropertPrice; }
set { _PropertPrice = value; }
}
private string _ApartPrice;
[JsonPropertyName("apartprice")]
public string ApartPrice
{
get { return _ApartPrice; }
set { _ApartPrice = value; }
}
}
}
