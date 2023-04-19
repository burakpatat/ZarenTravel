using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Reservations")]
public class Reservations: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _ReferenceCode;
[JsonPropertyName("referencecode")]
public string ReferenceCode
{
get { return _ReferenceCode; }
set { _ReferenceCode = value; }
}
private int? _CustomerID;
[JsonPropertyName("customerid")]
public int? CustomerID
{
get { return _CustomerID; }
set { _CustomerID = value; }
}
private DateTime? _StartDate;
[JsonPropertyName("startdate")]
public DateTime? StartDate
{
get { return _StartDate; }
set { _StartDate = value; }
}
private DateTime? _FinishDate;
[JsonPropertyName("finishdate")]
public DateTime? FinishDate
{
get { return _FinishDate; }
set { _FinishDate = value; }
}
private int? _PaymentType;
[JsonPropertyName("paymenttype")]
public int? PaymentType
{
get { return _PaymentType; }
set { _PaymentType = value; }
}
private decimal? _TotalPrice;
[JsonPropertyName("totalprice")]
public decimal? TotalPrice
{
get { return _TotalPrice; }
set { _TotalPrice = value; }
}
private int? _ApartID;
[JsonPropertyName("apartid")]
public int? ApartID
{
get { return _ApartID; }
set { _ApartID = value; }
}
private bool? _PaymentCompleted;
[JsonPropertyName("paymentcompleted")]
public bool? PaymentCompleted
{
get { return _PaymentCompleted; }
set { _PaymentCompleted = value; }
}
private string _Notes;
[JsonPropertyName("notes")]
public string Notes
{
get { return _Notes; }
set { _Notes = value; }
}
}
}
