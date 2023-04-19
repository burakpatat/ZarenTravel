using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("CustomerInformation")]
public class CustomerInformation: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int _CustomerId;
[Key]
[JsonPropertyName("customerid")]
public int CustomerId
{
get { return _CustomerId; }
set { _CustomerId = value; }
}
private string _EmailId;
[JsonPropertyName("emailid")]
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
[JsonPropertyName("firstname")]
public string FirstName
{
get { return _FirstName; }
set { _FirstName = value; }
}
private string _LastName;
[JsonPropertyName("lastname")]
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
[JsonPropertyName("alternativeemailid")]
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
[JsonPropertyName("countrycode")]
public string CountryCode
{
get { return _CountryCode; }
set { _CountryCode = value; }
}
private string _LanguageCode;
[JsonPropertyName("languagecode")]
public string LanguageCode
{
get { return _LanguageCode; }
set { _LanguageCode = value; }
}
private string _OfficeTelephone;
[JsonPropertyName("officetelephone")]
public string OfficeTelephone
{
get { return _OfficeTelephone; }
set { _OfficeTelephone = value; }
}
private DateTime? _DateOfBirth;
[JsonPropertyName("dateofbirth")]
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
[JsonPropertyName("nationalitycode")]
public int? NationalityCode
{
get { return _NationalityCode; }
set { _NationalityCode = value; }
}
private string _AgentCode;
[JsonPropertyName("agentcode")]
public string AgentCode
{
get { return _AgentCode; }
set { _AgentCode = value; }
}
private int? _CustomerId_N;
[JsonPropertyName("customerid_n")]
public int? CustomerId_N
{
get { return _CustomerId_N; }
set { _CustomerId_N = value; }
}
private decimal? _Totalpaxcount;
[JsonPropertyName("totalpaxcount")]
public decimal? Totalpaxcount
{
get { return _Totalpaxcount; }
set { _Totalpaxcount = value; }
}
private decimal? _TotalInfantcount;
[JsonPropertyName("totalinfantcount")]
public decimal? TotalInfantcount
{
get { return _TotalInfantcount; }
set { _TotalInfantcount = value; }
}
private decimal? _TotalFare;
[JsonPropertyName("totalfare")]
public decimal? TotalFare
{
get { return _TotalFare; }
set { _TotalFare = value; }
}
private decimal? _TotalTaxChg;
[JsonPropertyName("totaltaxchg")]
public decimal? TotalTaxChg
{
get { return _TotalTaxChg; }
set { _TotalTaxChg = value; }
}
private int? _BookingStatus;
[JsonPropertyName("bookingstatus")]
public int? BookingStatus
{
get { return _BookingStatus; }
set { _BookingStatus = value; }
}
private DateTime? _ModificationDate;
[JsonPropertyName("modificationdate")]
public DateTime? ModificationDate
{
get { return _ModificationDate; }
set { _ModificationDate = value; }
}
private int? _FILE_ID;
[JsonPropertyName("file_id")]
public int? FILE_ID
{
get { return _FILE_ID; }
set { _FILE_ID = value; }
}
private string _FILE_NAME;
[JsonPropertyName("file_name")]
public string FILE_NAME
{
get { return _FILE_NAME; }
set { _FILE_NAME = value; }
}
private DateTime? _RecordDateStamp;
[JsonPropertyName("recorddatestamp")]
public DateTime? RecordDateStamp
{
get { return _RecordDateStamp; }
set { _RecordDateStamp = value; }
}
}
}
