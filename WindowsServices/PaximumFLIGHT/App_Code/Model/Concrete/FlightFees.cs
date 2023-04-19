using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("FlightFees")]
public class FlightFees: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Keys;
[JsonPropertyName("keys")]
public string Keys
{
get { return _Keys; }
set { _Keys = value; }
}
private int? _OneRoundMultiWaysId;
[JsonPropertyName("oneroundmultiwaysid")]
public int? OneRoundMultiWaysId
{
get { return _OneRoundMultiWaysId; }
set { _OneRoundMultiWaysId = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyid")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private int? _LanguageId;
[JsonPropertyName("languageid")]
public int? LanguageId
{
get { return _LanguageId; }
set { _LanguageId = value; }
}
private string _SystemId;
[JsonPropertyName("systemid")]
public string SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
}
private DateTime? _CreatedDate;
[JsonPropertyName("createddate")]
public DateTime? CreatedDate
{
get { return _CreatedDate; }
set { _CreatedDate = value; }
}
private DateTime? _UpdatedDate;
[JsonPropertyName("updateddate")]
public DateTime? UpdatedDate
{
get { return _UpdatedDate; }
set { _UpdatedDate = value; }
}
private int? _CreatedBy;
[JsonPropertyName("createdby")]
public int? CreatedBy
{
get { return _CreatedBy; }
set { _CreatedBy = value; }
}
private int? _UpdatedBy;
[JsonPropertyName("updatedby")]
public int? UpdatedBy
{
get { return _UpdatedBy; }
set { _UpdatedBy = value; }
}
}
}
