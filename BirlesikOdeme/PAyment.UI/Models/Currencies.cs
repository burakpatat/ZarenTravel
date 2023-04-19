using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Currencies")]
public class Currencies: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Country;
[JsonPropertyName("country")]
public string Country
{
get { return _Country; }
set { _Country = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _CurrencyCode;
[JsonPropertyName("currencycode")]
public string CurrencyCode
{
get { return _CurrencyCode; }
set { _CurrencyCode = value; }
}
private string _Number;
[JsonPropertyName("number")]
public string Number
{
get { return _Number; }
set { _Number = value; }
}
private bool? _IsActive;
[JsonPropertyName("isactive")]
public bool? IsActive
{
get { return _IsActive; }
set { _IsActive = value; }
}
private int? _TableOrder;
[JsonPropertyName("tableorder")]
public int? TableOrder
{
get { return _TableOrder; }
set { _TableOrder = value; }
}
}
}
