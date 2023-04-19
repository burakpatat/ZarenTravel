using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class SegmentInformationGetRecordDateStampBetweenResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _PNRSegId;
[JsonPropertyName("pNRSegId")]
public string PNRSegId
{
get { return _PNRSegId; }
set { _PNRSegId = value; }
}
private string _PNR;
[JsonPropertyName("pNR")]
public string PNR
{
get { return _PNR; }
set { _PNR = value; }
}
private string _FlightNumber;
[JsonPropertyName("flightNumber")]
public string FlightNumber
{
get { return _FlightNumber; }
set { _FlightNumber = value; }
}
private string _Origin;
[JsonPropertyName("origin")]
public string Origin
{
get { return _Origin; }
set { _Origin = value; }
}
private string _Destination;
[JsonPropertyName("destination")]
public string Destination
{
get { return _Destination; }
set { _Destination = value; }
}
private string _Segmentcode;
[JsonPropertyName("segmentcode")]
public string Segmentcode
{
get { return _Segmentcode; }
set { _Segmentcode = value; }
}
private DateTime? _EsttimeDepartureLocal;
[JsonPropertyName("esttimeDepartureLocal")]
public DateTime? EsttimeDepartureLocal
{
get { return _EsttimeDepartureLocal; }
set { _EsttimeDepartureLocal = value; }
}
private DateTime? _EsttimeArrivalLocal;
[JsonPropertyName("esttimeArrivalLocal")]
public DateTime? EsttimeArrivalLocal
{
get { return _EsttimeArrivalLocal; }
set { _EsttimeArrivalLocal = value; }
}
private int? _Daynumber;
[JsonPropertyName("daynumber")]
public int? Daynumber
{
get { return _Daynumber; }
set { _Daynumber = value; }
}
private string _SegmentStatus;
[JsonPropertyName("segmentStatus")]
public string SegmentStatus
{
get { return _SegmentStatus; }
set { _SegmentStatus = value; }
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
