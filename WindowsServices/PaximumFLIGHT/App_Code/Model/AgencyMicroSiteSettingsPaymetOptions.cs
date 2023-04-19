using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsPaymetOptions")]
public class AgencyMicroSiteSettingsPaymetOptions: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _OptionsName;
[JsonPropertyName("optionsname")]
public string OptionsName
{
get { return _OptionsName; }
set { _OptionsName = value; }
}
}
}
