using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Companies")]
public class Companies: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CompanyCode;
[JsonPropertyName("companycode")]
public string CompanyCode
{
get { return _CompanyCode; }
set { _CompanyCode = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _CountryId;
[JsonPropertyName("countryid")]
public int? CountryId
{
get { return _CountryId; }
set { _CountryId = value; }
}
private string _CompanyRepresentative;
[JsonPropertyName("companyrepresentative")]
public string CompanyRepresentative
{
get { return _CompanyRepresentative; }
set { _CompanyRepresentative = value; }
}
private int? _CoGrId;
[JsonPropertyName("cogrid")]
public int? CoGrId
{
get { return _CoGrId; }
set { _CoGrId = value; }
}
private int? _CoDiId;
[JsonPropertyName("codiid")]
public int? CoDiId
{
get { return _CoDiId; }
set { _CoDiId = value; }
}
private int? _LanguagesId;
[JsonPropertyName("languagesid")]
public int? LanguagesId
{
get { return _LanguagesId; }
set { _LanguagesId = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyid")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private int? _InSeId;
[JsonPropertyName("inseid")]
public int? InSeId
{
get { return _InSeId; }
set { _InSeId = value; }
}
private DateTime? _CompanyTimestamp;
[JsonPropertyName("companytimestamp")]
public DateTime? CompanyTimestamp
{
get { return _CompanyTimestamp; }
set { _CompanyTimestamp = value; }
}
private bool? _CompanyActive;
[JsonPropertyName("companyactive")]
public bool? CompanyActive
{
get { return _CompanyActive; }
set { _CompanyActive = value; }
}
}
}
