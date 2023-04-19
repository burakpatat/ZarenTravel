using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CustomerInformationGetByAlternativeEmailIdResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int _CustomerId;
[JsonPropertyName("customerId")]
public int CustomerId
{
get { return _CustomerId; }
set { _CustomerId = value; }
}
private string _EmailId;
[JsonPropertyName("emailId")]
public string EmailId
{
get { return _EmailId; }
set { _EmailId = value; }
}
private string _Title;
[JsonPropertyName("title")]
public string Title
{
get { return _Title; }
set { _Title = value; }
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
private string _Gender;
[JsonPropertyName("gender")]
public string Gender
{
get { return _Gender; }
set { _Gender = value; }
}
private string _AlternativeEmailId;
[JsonPropertyName("alternativeEmailId")]
public string AlternativeEmailId
{
get { return _AlternativeEmailId; }
set { _AlternativeEmailId = value; }
}
private string _Telephone;
[JsonPropertyName("telephone")]
public string Telephone
{
get { return _Telephone; }
set { _Telephone = value; }
}
private string _Mobile;
[JsonPropertyName("mobile")]
public string Mobile
{
get { return _Mobile; }
set { _Mobile = value; }
}
private string _CountryCode;
[JsonPropertyName("countryCode")]
public string CountryCode
{
get { return _CountryCode; }
set { _CountryCode = value; }
}
private string _LanguageCode;
[JsonPropertyName("languageCode")]
public string LanguageCode
{
get { return _LanguageCode; }
set { _LanguageCode = value; }
}
private string _OfficeTelephone;
[JsonPropertyName("officeTelephone")]
public string OfficeTelephone
{
get { return _OfficeTelephone; }
set { _OfficeTelephone = value; }
}
private DateTime? _DateOfBirth;
[JsonPropertyName("dateOfBirth")]
public DateTime? DateOfBirth
{
get { return _DateOfBirth; }
set { _DateOfBirth = value; }
}
private string _Fax;
[JsonPropertyName("fax")]
public string Fax
{
get { return _Fax; }
set { _Fax = value; }
}
private int? _NationalityCode;
[JsonPropertyName("nationalityCode")]
public int? NationalityCode
{
get { return _NationalityCode; }
set { _NationalityCode = value; }
}
private string _AgentCode;
[JsonPropertyName("agentCode")]
public string AgentCode
{
get { return _AgentCode; }
set { _AgentCode = value; }
}
private int? _CustomerId_N;
[JsonPropertyName("customerId_N")]
public int? CustomerId_N
{
get { return _CustomerId_N; }
set { _CustomerId_N = value; }
}
private string _Totalpaxcount;
[JsonPropertyName("totalpaxcount")]
public string Totalpaxcount
{
get { return _Totalpaxcount; }
set { _Totalpaxcount = value; }
}
private string _TotalInfantcount;
[JsonPropertyName("totalInfantcount")]
public string TotalInfantcount
{
get { return _TotalInfantcount; }
set { _TotalInfantcount = value; }
}
private string _TotalFare;
[JsonPropertyName("totalFare")]
public string TotalFare
{
get { return _TotalFare; }
set { _TotalFare = value; }
}
private string _TotalTaxChg;
[JsonPropertyName("totalTaxChg")]
public string TotalTaxChg
{
get { return _TotalTaxChg; }
set { _TotalTaxChg = value; }
}
private int? _BookingStatus;
[JsonPropertyName("bookingStatus")]
public int? BookingStatus
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
