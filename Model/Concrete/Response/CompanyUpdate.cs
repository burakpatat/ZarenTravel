using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CompanyUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CompanyCode;
[JsonPropertyName("companyCode")]
public string CompanyCode
{
get { return _CompanyCode; }
set { _CompanyCode = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyId")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _CountryId;
[JsonPropertyName("countryId")]
public int? CountryId
{
get { return _CountryId; }
set { _CountryId = value; }
}
private string _CompanyRepresentative;
[JsonPropertyName("companyRepresentative")]
public string CompanyRepresentative
{
get { return _CompanyRepresentative; }
set { _CompanyRepresentative = value; }
}
private int? _CoGrId;
[JsonPropertyName("coGrId")]
public int? CoGrId
{
get { return _CoGrId; }
set { _CoGrId = value; }
}
private int? _CoDiId;
[JsonPropertyName("coDiId")]
public int? CoDiId
{
get { return _CoDiId; }
set { _CoDiId = value; }
}
private int? _LanguagesId;
[JsonPropertyName("languagesId")]
public int? LanguagesId
{
get { return _LanguagesId; }
set { _LanguagesId = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyId")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private int? _InSeId;
[JsonPropertyName("inSeId")]
public int? InSeId
{
get { return _InSeId; }
set { _InSeId = value; }
}
private DateTime? _CompanyTimestamp;
[JsonPropertyName("companyTimestamp")]
public DateTime? CompanyTimestamp
{
get { return _CompanyTimestamp; }
set { _CompanyTimestamp = value; }
}
private bool? _CompanyActive;
[JsonPropertyName("companyActive")]
public bool? CompanyActive
{
get { return _CompanyActive; }
set { _CompanyActive = value; }
}
}
}
