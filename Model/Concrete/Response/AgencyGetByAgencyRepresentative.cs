using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AgencyGetByAgencyRepresentativeResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _AgencyIATA;
[JsonPropertyName("agencyIATA")]
public int? AgencyIATA
{
get { return _AgencyIATA; }
set { _AgencyIATA = value; }
}
private string _AgencyCode;
[JsonPropertyName("agencyCode")]
public string AgencyCode
{
get { return _AgencyCode; }
set { _AgencyCode = value; }
}
private string _AgencyName;
[JsonPropertyName("agencyName")]
public string AgencyName
{
get { return _AgencyName; }
set { _AgencyName = value; }
}
private string _AgencyRepresentative;
[JsonPropertyName("agencyRepresentative")]
public string AgencyRepresentative
{
get { return _AgencyRepresentative; }
set { _AgencyRepresentative = value; }
}
private int? _AgGrId;
[JsonPropertyName("agGrId")]
public int? AgGrId
{
get { return _AgGrId; }
set { _AgGrId = value; }
}
private int? _CountryId;
[JsonPropertyName("countryId")]
public int? CountryId
{
get { return _CountryId; }
set { _CountryId = value; }
}
private int? _LanguagesId;
[JsonPropertyName("languagesId")]
public int? LanguagesId
{
get { return _LanguagesId; }
set { _LanguagesId = value; }
}
private int? _AgencyTimestamp;
[JsonPropertyName("agencyTimestamp")]
public int? AgencyTimestamp
{
get { return _AgencyTimestamp; }
set { _AgencyTimestamp = value; }
}
private bool? _AgencyActive;
[JsonPropertyName("agencyActive")]
public bool? AgencyActive
{
get { return _AgencyActive; }
set { _AgencyActive = value; }
}
}
}
