using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("ApiResults")]
public class ApiResults: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _RequestData;
[JsonPropertyName("requestdata")]
public string RequestData
{
get { return _RequestData; }
set { _RequestData = value; }
}
private string _ResponseData;
[JsonPropertyName("responsedata")]
public string ResponseData
{
get { return _ResponseData; }
set { _ResponseData = value; }
}
private DateTime? _RequestDate;
[JsonPropertyName("requestdate")]
public DateTime? RequestDate
{
get { return _RequestDate; }
set { _RequestDate = value; }
}
private DateTime? _ResponseDate;
[JsonPropertyName("responsedate")]
public DateTime? ResponseDate
{
get { return _ResponseDate; }
set { _ResponseDate = value; }
}
private string _Currency;
[JsonPropertyName("currency")]
public string Currency
{
get { return _Currency; }
set { _Currency = value; }
}
private string _CheckIn;
[JsonPropertyName("checkin")]
public string CheckIn
{
get { return _CheckIn; }
set { _CheckIn = value; }
}
private string _Nationality;
[JsonPropertyName("nationality")]
public string Nationality
{
get { return _Nationality; }
set { _Nationality = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private bool? _IsSuccessfull;
[JsonPropertyName("issuccessfull")]
public bool? IsSuccessfull
{
get { return _IsSuccessfull; }
set { _IsSuccessfull = value; }
}
private int? _LocationId;
[JsonPropertyName("locationid")]
public int? LocationId
{
get { return _LocationId; }
set { _LocationId = value; }
}
private string _Query;
[JsonPropertyName("query")]
public string Query
{
get { return _Query; }
set { _Query = value; }
}
private int? _ProductType;
[JsonPropertyName("producttype")]
public int? ProductType
{
get { return _ProductType; }
set { _ProductType = value; }
}
}
}
