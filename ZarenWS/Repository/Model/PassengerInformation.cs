using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PassengerInformation")]
public class PassengerInformation: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _PnrpaxId;
[JsonPropertyName("pnrpaxid")]
public string PnrpaxId
{
get { return _PnrpaxId; }
set { _PnrpaxId = value; }
}
private string _Pnr;
[Key]
[JsonPropertyName("pnr")]
public string Pnr
{
get { return _Pnr; }
set { _Pnr = value; }
}
private int? _PaxSequence;
[JsonPropertyName("paxsequence")]
public int? PaxSequence
{
get { return _PaxSequence; }
set { _PaxSequence = value; }
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
private int? _AdultId;
[JsonPropertyName("adultid")]
public int? AdultId
{
get { return _AdultId; }
set { _AdultId = value; }
}
private int? _NationalityCode;
[JsonPropertyName("nationalitycode")]
public int? NationalityCode
{
get { return _NationalityCode; }
set { _NationalityCode = value; }
}
private decimal? _TotalFare;
[JsonPropertyName("totalfare")]
public decimal? TotalFare
{
get { return _TotalFare; }
set { _TotalFare = value; }
}
private decimal? _TotalTaxchg;
[JsonPropertyName("totaltaxchg")]
public decimal? TotalTaxchg
{
get { return _TotalTaxchg; }
set { _TotalTaxchg = value; }
}
private decimal? _TotalPaid;
[JsonPropertyName("totalpaid")]
public decimal? TotalPaid
{
get { return _TotalPaid; }
set { _TotalPaid = value; }
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
