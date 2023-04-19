using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsSortType")]
public class AgencyMicroSiteSettingsSortType: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _SortByName;
[JsonPropertyName("sortbyname")]
public string SortByName
{
get { return _SortByName; }
set { _SortByName = value; }
}
}
}
