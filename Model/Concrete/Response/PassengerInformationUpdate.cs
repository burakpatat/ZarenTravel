using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class PassengerInformationUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _PnrpaxId;
[JsonPropertyName("pnrpaxId")]
public string PnrpaxId
{
get { return _PnrpaxId; }
set { _PnrpaxId = value; }
}
private string _Pnr;
[JsonPropertyName("pnr")]
public string Pnr
{
get { return _Pnr; }
set { _Pnr = value; }
}
private int? _PaxSequence;
[JsonPropertyName("paxSequence")]
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
private int? _AdultId;
[JsonPropertyName("adultId")]
public int? AdultId
{
get { return _AdultId; }
set { _AdultId = value; }
}
private int? _NationalityCode;
[JsonPropertyName("nationalityCode")]
public int? NationalityCode
{
get { return _NationalityCode; }
set { _NationalityCode = value; }
}
private string _TotalFare;
[JsonPropertyName("totalFare")]
public string TotalFare
{
get { return _TotalFare; }
set { _TotalFare = value; }
}
private string _TotalTaxchg;
[JsonPropertyName("totalTaxchg")]
public string TotalTaxchg
{
get { return _TotalTaxchg; }
set { _TotalTaxchg = value; }
}
private string _TotalPaid;
[JsonPropertyName("totalPaid")]
public string TotalPaid
{
get { return _TotalPaid; }
set { _TotalPaid = value; }
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
