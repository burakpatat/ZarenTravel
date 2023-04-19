using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Country")]
public class Country: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _ShortName;
[JsonPropertyName("shortname")]
public string ShortName
{
get { return _ShortName; }
set { _ShortName = value; }
}
private string _Temperature;
[JsonPropertyName("temperature")]
public string Temperature
{
get { return _Temperature; }
set { _Temperature = value; }
}
private string _Area;
[JsonPropertyName("area")]
public string Area
{
get { return _Area; }
set { _Area = value; }
}
private string _Religion;
[JsonPropertyName("religion")]
public string Religion
{
get { return _Religion; }
set { _Religion = value; }
}
private string _Location;
[JsonPropertyName("location")]
public string Location
{
get { return _Location; }
set { _Location = value; }
}
private int? _Population;
[JsonPropertyName("population")]
public int? Population
{
get { return _Population; }
set { _Population = value; }
}
private string _Density;
[JsonPropertyName("density")]
public string Density
{
get { return _Density; }
set { _Density = value; }
}
private string _Symbol;
[JsonPropertyName("symbol")]
public string Symbol
{
get { return _Symbol; }
set { _Symbol = value; }
}
private string _Abbreviation;
[JsonPropertyName("abbreviation")]
public string Abbreviation
{
get { return _Abbreviation; }
set { _Abbreviation = value; }
}
private string _FlagBase64;
[JsonPropertyName("flagbase64")]
public string FlagBase64
{
get { return _FlagBase64; }
set { _FlagBase64 = value; }
}
private string _Expectancy;
[JsonPropertyName("expectancy")]
public string Expectancy
{
get { return _Expectancy; }
set { _Expectancy = value; }
}
private string _Dish;
[JsonPropertyName("dish")]
public string Dish
{
get { return _Dish; }
set { _Dish = value; }
}
private string _LanguagesJSON;
[JsonPropertyName("languagesjson")]
public string LanguagesJSON
{
get { return _LanguagesJSON; }
set { _LanguagesJSON = value; }
}
private string _Landlocked;
[JsonPropertyName("landlocked")]
public string Landlocked
{
get { return _Landlocked; }
set { _Landlocked = value; }
}
private string _Iso;
[JsonPropertyName("iso")]
public string Iso
{
get { return _Iso; }
set { _Iso = value; }
}
private string _Independence;
[JsonPropertyName("independence")]
public string Independence
{
get { return _Independence; }
set { _Independence = value; }
}
private string _Government;
[JsonPropertyName("government")]
public string Government
{
get { return _Government; }
set { _Government = value; }
}
private string _North;
[JsonPropertyName("north")]
public string North
{
get { return _North; }
set { _North = value; }
}
private string _South;
[JsonPropertyName("south")]
public string South
{
get { return _South; }
set { _South = value; }
}
private string _West;
[JsonPropertyName("west")]
public string West
{
get { return _West; }
set { _West = value; }
}
private string _East;
[JsonPropertyName("east")]
public string East
{
get { return _East; }
set { _East = value; }
}
private string _Elevation;
[JsonPropertyName("elevation")]
public string Elevation
{
get { return _Elevation; }
set { _Elevation = value; }
}
private string _DomainTld;
[JsonPropertyName("domaintld")]
public string DomainTld
{
get { return _DomainTld; }
set { _DomainTld = value; }
}
private string _CurrencyName;
[JsonPropertyName("currencyname")]
public string CurrencyName
{
get { return _CurrencyName; }
set { _CurrencyName = value; }
}
private string _CurrencyCode;
[JsonPropertyName("currencycode")]
public string CurrencyCode
{
get { return _CurrencyCode; }
set { _CurrencyCode = value; }
}
private string _CostLine;
[JsonPropertyName("costline")]
public string CostLine
{
get { return _CostLine; }
set { _CostLine = value; }
}
private string _Continent;
[JsonPropertyName("continent")]
public string Continent
{
get { return _Continent; }
set { _Continent = value; }
}
private string _City;
[JsonPropertyName("city")]
public string City
{
get { return _City; }
set { _City = value; }
}
private string _CallingCode;
[JsonPropertyName("callingcode")]
public string CallingCode
{
get { return _CallingCode; }
set { _CallingCode = value; }
}
private string _Barcode;
[JsonPropertyName("barcode")]
public string Barcode
{
get { return _Barcode; }
set { _Barcode = value; }
}
private string _Height;
[JsonPropertyName("height")]
public string Height
{
get { return _Height; }
set { _Height = value; }
}
private int? _DefaultLanguageId;
[JsonPropertyName("defaultlanguageid")]
public int? DefaultLanguageId
{
get { return _DefaultLanguageId; }
set { _DefaultLanguageId = value; }
}
private bool? _HasFraudRisk;
[JsonPropertyName("hasfraudrisk")]
public bool? HasFraudRisk
{
get { return _HasFraudRisk; }
set { _HasFraudRisk = value; }
}
private bool? _HasManuelRegistration;
[JsonPropertyName("hasmanuelregistration")]
public bool? HasManuelRegistration
{
get { return _HasManuelRegistration; }
set { _HasManuelRegistration = value; }
}
private string _Logo;
[JsonPropertyName("logo")]
public string Logo
{
get { return _Logo; }
set { _Logo = value; }
}
}
}
