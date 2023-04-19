using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class ReservationInformationGetByTotalpaxcountResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _PNR;
[JsonPropertyName("pNR")]
public string PNR
{
get { return _PNR; }
set { _PNR = value; }
}
private DateTime? _BookingTimeStamp;
[JsonPropertyName("bookingTimeStamp")]
public DateTime? BookingTimeStamp
{
get { return _BookingTimeStamp; }
set { _BookingTimeStamp = value; }
}
private string _FirstName;
[JsonPropertyName("firstName")]
public string FirstName
{
get { return _FirstName; }
set { _FirstName = value; }
}
private string _LastName;
[JsonPropertyName("lastName")]
public string LastName
{
get { return _LastName; }
set { _LastName = value; }
}
private string _PassportNumber;
[JsonPropertyName("passportNumber")]
public string PassportNumber
{
get { return _PassportNumber; }
set { _PassportNumber = value; }
}
private string _StreetAddress1;
[JsonPropertyName("streetAddress1")]
public string StreetAddress1
{
get { return _StreetAddress1; }
set { _StreetAddress1 = value; }
}
private string _StreetAddress2;
[JsonPropertyName("streetAddress2")]
public string StreetAddress2
{
get { return _StreetAddress2; }
set { _StreetAddress2 = value; }
}
private string _City;
[JsonPropertyName("city")]
public string City
{
get { return _City; }
set { _City = value; }
}
private string _State;
[JsonPropertyName("state")]
public string State
{
get { return _State; }
set { _State = value; }
}
private string _CountryCode;
[JsonPropertyName("countryCode")]
public string CountryCode
{
get { return _CountryCode; }
set { _CountryCode = value; }
}
private string _PhoneNo;
[JsonPropertyName("phoneNo")]
public string PhoneNo
{
get { return _PhoneNo; }
set { _PhoneNo = value; }
}
private string _MobileNo;
[JsonPropertyName("mobileNo")]
public string MobileNo
{
get { return _MobileNo; }
set { _MobileNo = value; }
}
private string _Fax;
[JsonPropertyName("fax")]
public string Fax
{
get { return _Fax; }
set { _Fax = value; }
}
private string _Email;
[JsonPropertyName("email")]
public string Email
{
get { return _Email; }
set { _Email = value; }
}
private int? _NationalityCode;
[JsonPropertyName("nationalityCode")]
public int? NationalityCode
{
get { return _NationalityCode; }
set { _NationalityCode = value; }
}
private int? _SalesChannelCode;
[JsonPropertyName("salesChannelCode")]
public int? SalesChannelCode
{
get { return _SalesChannelCode; }
set { _SalesChannelCode = value; }
}
private string _AgentCode;
[JsonPropertyName("agentCode")]
public string AgentCode
{
get { return _AgentCode; }
set { _AgentCode = value; }
}
private int? _CustomerId;
[JsonPropertyName("customerId")]
public int? CustomerId
{
get { return _CustomerId; }
set { _CustomerId = value; }
}
private int? _Totalpaxcount;
[JsonPropertyName("totalpaxcount")]
public int? Totalpaxcount
{
get { return _Totalpaxcount; }
set { _Totalpaxcount = value; }
}
private int? _TotalInfantcount;
[JsonPropertyName("totalInfantcount")]
public int? TotalInfantcount
{
get { return _TotalInfantcount; }
set { _TotalInfantcount = value; }
}
private string _TotalTaxChg;
[JsonPropertyName("totalTaxChg")]
public string TotalTaxChg
{
get { return _TotalTaxChg; }
set { _TotalTaxChg = value; }
}
private string _TotalFare;
[JsonPropertyName("totalFare")]
public string TotalFare
{
get { return _TotalFare; }
set { _TotalFare = value; }
}
private string _BookingStatus;
[JsonPropertyName("bookingStatus")]
public string BookingStatus
{
get { return _BookingStatus; }
set { _BookingStatus = value; }
}
private DateTime? _ModificationDate;
[JsonPropertyName("modificationDate")]
public DateTime? ModificationDate
{
get { return _ModificationDate; }
set { _ModificationDate = value; }
}
private int? _FILE_ID;
[JsonPropertyName("fILE_ID")]
public int? FILE_ID
{
get { return _FILE_ID; }
set { _FILE_ID = value; }
}
private string _FILE_NAME;
[JsonPropertyName("fILE_NAME")]
public string FILE_NAME
{
get { return _FILE_NAME; }
set { _FILE_NAME = value; }
}
private DateTime? _RecordDateStamp;
[JsonPropertyName("recordDateStamp")]
public DateTime? RecordDateStamp
{
get { return _RecordDateStamp; }
set { _RecordDateStamp = value; }
}
}
}
