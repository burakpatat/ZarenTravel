using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class PassengerGetAllResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _PassengerFullName;
[JsonPropertyName("passengerFullName")]
public string PassengerFullName
{
get { return _PassengerFullName; }
set { _PassengerFullName = value; }
}
private string _PassengerPhone;
[JsonPropertyName("passengerPhone")]
public string PassengerPhone
{
get { return _PassengerPhone; }
set { _PassengerPhone = value; }
}
private string _PassengerCelPhone;
[JsonPropertyName("passengerCelPhone")]
public string PassengerCelPhone
{
get { return _PassengerCelPhone; }
set { _PassengerCelPhone = value; }
}
private string _PassengerEmail;
[JsonPropertyName("passengerEmail")]
public string PassengerEmail
{
get { return _PassengerEmail; }
set { _PassengerEmail = value; }
}
private string _PassengerJobPosition;
[JsonPropertyName("passengerJobPosition")]
public string PassengerJobPosition
{
get { return _PassengerJobPosition; }
set { _PassengerJobPosition = value; }
}
private bool? _PassengerVIP;
[JsonPropertyName("passengerVIP")]
public bool? PassengerVIP
{
get { return _PassengerVIP; }
set { _PassengerVIP = value; }
}
private DateTime? _PassemgerTimestamp;
[JsonPropertyName("passemgerTimestamp")]
public DateTime? PassemgerTimestamp
{
get { return _PassemgerTimestamp; }
set { _PassemgerTimestamp = value; }
}
private bool? _PassengerActive;
[JsonPropertyName("passengerActive")]
public bool? PassengerActive
{
get { return _PassengerActive; }
set { _PassengerActive = value; }
}
}
}
