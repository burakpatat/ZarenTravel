using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Broker")]
public class Broker: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _BrokerCode;
[JsonPropertyName("brokercode")]
public string BrokerCode
{
get { return _BrokerCode; }
set { _BrokerCode = value; }
}
private string _BrokerName;
[JsonPropertyName("brokername")]
public string BrokerName
{
get { return _BrokerName; }
set { _BrokerName = value; }
}
private DateTime? _BrokerTimestamp;
[JsonPropertyName("brokertimestamp")]
public DateTime? BrokerTimestamp
{
get { return _BrokerTimestamp; }
set { _BrokerTimestamp = value; }
}
private bool? _BrokerActive;
[JsonPropertyName("brokeractive")]
public bool? BrokerActive
{
get { return _BrokerActive; }
set { _BrokerActive = value; }
}
}
}
