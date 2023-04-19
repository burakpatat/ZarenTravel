using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("CityModels")]
public class CityModels: IEntity
{
private int _CityId;
[Key]
[JsonPropertyName("cityid")]
public int CityId
{
get { return _CityId; }
set { _CityId = value; }
}
private string _CityName;
[JsonPropertyName("cityname")]
public string CityName
{
get { return _CityName; }
set { _CityName = value; }
}
}
}
