using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class BrokerGetByBrokerTimestampResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _BrokerCode;
[JsonPropertyName("brokerCode")]
public string BrokerCode
{
get { return _BrokerCode; }
set { _BrokerCode = value; }
}
private string _BrokerName;
[JsonPropertyName("brokerName")]
public string BrokerName
{
get { return _BrokerName; }
set { _BrokerName = value; }
}
private DateTime? _BrokerTimestamp;
[JsonPropertyName("brokerTimestamp")]
public DateTime? BrokerTimestamp
{
get { return _BrokerTimestamp; }
set { _BrokerTimestamp = value; }
}
private bool? _BrokerActive;
[JsonPropertyName("brokerActive")]
public bool? BrokerActive
{
get { return _BrokerActive; }
set { _BrokerActive = value; }
}
}
}
