using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CarRentGetByCurrencyIdResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _PNRId;
[JsonPropertyName("pNRId")]
public int? PNRId
{
get { return _PNRId; }
set { _PNRId = value; }
}
private int? _CaTyId;
[JsonPropertyName("caTyId")]
public int? CaTyId
{
get { return _CaTyId; }
set { _CaTyId = value; }
}
private int? _CaRtId;
[JsonPropertyName("caRtId")]
public int? CaRtId
{
get { return _CaRtId; }
set { _CaRtId = value; }
}
private int? _AirportIdPickUp;
[JsonPropertyName("airportIdPickUp")]
public int? AirportIdPickUp
{
get { return _AirportIdPickUp; }
set { _AirportIdPickUp = value; }
}
private int? _AirportIdReturn;
[JsonPropertyName("airportIdReturn")]
public int? AirportIdReturn
{
get { return _AirportIdReturn; }
set { _AirportIdReturn = value; }
}
private DateTime? _CaRePickUpDate;
[JsonPropertyName("caRePickUpDate")]
public DateTime? CaRePickUpDate
{
get { return _CaRePickUpDate; }
set { _CaRePickUpDate = value; }
}
private DateTime? _CaReReturnDate;
[JsonPropertyName("caReReturnDate")]
public DateTime? CaReReturnDate
{
get { return _CaReReturnDate; }
set { _CaReReturnDate = value; }
}
private string _CaReRate;
[JsonPropertyName("caReRate")]
public string CaReRate
{
get { return _CaReRate; }
set { _CaReRate = value; }
}
private string _CaReTax;
[JsonPropertyName("caReTax")]
public string CaReTax
{
get { return _CaReTax; }
set { _CaReTax = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyId")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private DateTime? _CaReBookDate;
[JsonPropertyName("caReBookDate")]
public DateTime? CaReBookDate
{
get { return _CaReBookDate; }
set { _CaReBookDate = value; }
}
private DateTime? _CaReTimestamp;
[JsonPropertyName("caReTimestamp")]
public DateTime? CaReTimestamp
{
get { return _CaReTimestamp; }
set { _CaReTimestamp = value; }
}
private bool? _CaReActive;
[JsonPropertyName("caReActive")]
public bool? CaReActive
{
get { return _CaReActive; }
set { _CaReActive = value; }
}
}
}
