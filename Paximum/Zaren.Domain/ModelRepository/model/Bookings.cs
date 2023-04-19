using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Bookings")]
public class Bookings: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _HotelId;
[JsonPropertyName("hotelid")]
public int? HotelId
{
get { return _HotelId; }
set { _HotelId = value; }
}
private int? _ProviderId;
[JsonPropertyName("providerid")]
public int? ProviderId
{
get { return _ProviderId; }
set { _ProviderId = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private string _Reference;
[JsonPropertyName("reference")]
public string Reference
{
get { return _Reference; }
set { _Reference = value; }
}
private DateTime? _FromDate;
[JsonPropertyName("fromdate")]
public DateTime? FromDate
{
get { return _FromDate; }
set { _FromDate = value; }
}
private DateTime? _ToDate;
[JsonPropertyName("todate")]
public DateTime? ToDate
{
get { return _ToDate; }
set { _ToDate = value; }
}
private DateTime? _DateBooked;
[JsonPropertyName("datebooked")]
public DateTime? DateBooked
{
get { return _DateBooked; }
set { _DateBooked = value; }
}
private int? _Nights;
[JsonPropertyName("nights")]
public int? Nights
{
get { return _Nights; }
set { _Nights = value; }
}
private int? _NumRooms;
[JsonPropertyName("numrooms")]
public int? NumRooms
{
get { return _NumRooms; }
set { _NumRooms = value; }
}
private decimal? _TotalCost;
[JsonPropertyName("totalcost")]
public decimal? TotalCost
{
get { return _TotalCost; }
set { _TotalCost = value; }
}
private decimal? _TotalPrice;
[JsonPropertyName("totalprice")]
public decimal? TotalPrice
{
get { return _TotalPrice; }
set { _TotalPrice = value; }
}
private int? _Status;
[JsonPropertyName("status")]
public int? Status
{
get { return _Status; }
set { _Status = value; }
}
private int? _PaidStatus;
[JsonPropertyName("paidstatus")]
public int? PaidStatus
{
get { return _PaidStatus; }
set { _PaidStatus = value; }
}
private string _ClientTitle;
[JsonPropertyName("clienttitle")]
public string ClientTitle
{
get { return _ClientTitle; }
set { _ClientTitle = value; }
}
private string _ClientName;
[JsonPropertyName("clientname")]
public string ClientName
{
get { return _ClientName; }
set { _ClientName = value; }
}
private string _ClientSurname;
[JsonPropertyName("clientsurname")]
public string ClientSurname
{
get { return _ClientSurname; }
set { _ClientSurname = value; }
}
private string _ClientEmail;
[JsonPropertyName("clientemail")]
public string ClientEmail
{
get { return _ClientEmail; }
set { _ClientEmail = value; }
}
private string _ClientNotes;
[JsonPropertyName("clientnotes")]
public string ClientNotes
{
get { return _ClientNotes; }
set { _ClientNotes = value; }
}
private string _ClientAddress;
[JsonPropertyName("clientaddress")]
public string ClientAddress
{
get { return _ClientAddress; }
set { _ClientAddress = value; }
}
private string _ClientContact;
[JsonPropertyName("clientcontact")]
public string ClientContact
{
get { return _ClientContact; }
set { _ClientContact = value; }
}
private int? _Adults;
[JsonPropertyName("adults")]
public int? Adults
{
get { return _Adults; }
set { _Adults = value; }
}
private int? _Children;
[JsonPropertyName("children")]
public int? Children
{
get { return _Children; }
set { _Children = value; }
}
private int? _Infants;
[JsonPropertyName("infants")]
public int? Infants
{
get { return _Infants; }
set { _Infants = value; }
}
private string _ChildrenAges;
[JsonPropertyName("childrenages")]
public string ChildrenAges
{
get { return _ChildrenAges; }
set { _ChildrenAges = value; }
}
}
}
