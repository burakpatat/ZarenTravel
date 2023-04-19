using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class ExchangeRatesGetByExRaDateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _CurrencyIdFrom;
[JsonPropertyName("currencyIdFrom")]
public int? CurrencyIdFrom
{
get { return _CurrencyIdFrom; }
set { _CurrencyIdFrom = value; }
}
private int? _CurrencyIdTo;
[JsonPropertyName("currencyIdTo")]
public int? CurrencyIdTo
{
get { return _CurrencyIdTo; }
set { _CurrencyIdTo = value; }
}
private string _ExRaValue;
[JsonPropertyName("exRaValue")]
public string ExRaValue
{
get { return _ExRaValue; }
set { _ExRaValue = value; }
}
private DateTime? _ExRaDate;
[JsonPropertyName("exRaDate")]
public DateTime? ExRaDate
{
get { return _ExRaDate; }
set { _ExRaDate = value; }
}
private int? _ExRaTimestamp;
[JsonPropertyName("exRaTimestamp")]
public int? ExRaTimestamp
{
get { return _ExRaTimestamp; }
set { _ExRaTimestamp = value; }
}
private bool? _ExRaActive;
[JsonPropertyName("exRaActive")]
public bool? ExRaActive
{
get { return _ExRaActive; }
set { _ExRaActive = value; }
}
}
}
