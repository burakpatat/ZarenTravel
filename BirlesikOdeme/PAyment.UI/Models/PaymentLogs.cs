using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PaymentLogs")]
public class PaymentLogs: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _TransactionId;
[JsonPropertyName("transactionid")]
public int? TransactionId
{
get { return _TransactionId; }
set { _TransactionId = value; }
}
private string _Request;
[JsonPropertyName("request")]
public string Request
{
get { return _Request; }
set { _Request = value; }
}
private DateTime? _RequestDate;
[JsonPropertyName("requestdate")]
public DateTime? RequestDate
{
get { return _RequestDate; }
set { _RequestDate = value; }
}
private string _Response;
[JsonPropertyName("response")]
public string Response
{
get { return _Response; }
set { _Response = value; }
}
private DateTime? _ResponseDate;
[JsonPropertyName("responsedate")]
public DateTime? ResponseDate
{
get { return _ResponseDate; }
set { _ResponseDate = value; }
}
}
}
