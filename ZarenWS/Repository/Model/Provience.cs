using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Provience")]
public class Provience: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private int? _CityID;
[JsonPropertyName("cityid")]
public int? CityID
{
get { return _CityID; }
set { _CityID = value; }
}
private int? _Statu;
[JsonPropertyName("statu")]
public int? Statu
{
get { return _Statu; }
set { _Statu = value; }
}
private int? _TableOrder;
[JsonPropertyName("tableorder")]
public int? TableOrder
{
get { return _TableOrder; }
set { _TableOrder = value; }
}
private string _Information;
[JsonPropertyName("information")]
public string Information
{
get { return _Information; }
set { _Information = value; }
}
private string _ListImage;
[JsonPropertyName("listimage")]
public string ListImage
{
get { return _ListImage; }
set { _ListImage = value; }
}
}
}
