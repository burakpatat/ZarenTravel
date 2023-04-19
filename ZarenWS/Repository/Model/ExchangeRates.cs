using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("ExchangeRates")]
public class ExchangeRates: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _CurrencyIdFrom;
[JsonPropertyName("currencyidfrom")]
public int? CurrencyIdFrom
{
get { return _CurrencyIdFrom; }
set { _CurrencyIdFrom = value; }
}
private int? _CurrencyIdTo;
[JsonPropertyName("currencyidto")]
public int? CurrencyIdTo
{
get { return _CurrencyIdTo; }
set { _CurrencyIdTo = value; }
}
private decimal? _ExRaValue;
[JsonPropertyName("exravalue")]
public decimal? ExRaValue
{
get { return _ExRaValue; }
set { _ExRaValue = value; }
}
private DateTime? _ExRaDate;
[JsonPropertyName("exradate")]
public DateTime? ExRaDate
{
get { return _ExRaDate; }
set { _ExRaDate = value; }
}
private int? _ExRaTimestamp;
[JsonPropertyName("exratimestamp")]
public int? ExRaTimestamp
{
get { return _ExRaTimestamp; }
set { _ExRaTimestamp = value; }
}
private bool? _ExRaActive;
[JsonPropertyName("exraactive")]
public bool? ExRaActive
{
get { return _ExRaActive; }
set { _ExRaActive = value; }
}
}
}
