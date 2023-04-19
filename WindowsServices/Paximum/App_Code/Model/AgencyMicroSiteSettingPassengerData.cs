using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingPassengerData")]
public class AgencyMicroSiteSettingPassengerData: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _RequiredPassengerData;
[JsonPropertyName("requiredpassengerdata")]
public int? RequiredPassengerData
{
get { return _RequiredPassengerData; }
set { _RequiredPassengerData = value; }
}
private bool? _ExcludeMrs;
[JsonPropertyName("excludemrs")]
public bool? ExcludeMrs
{
get { return _ExcludeMrs; }
set { _ExcludeMrs = value; }
}
private bool? _ExcludeMiss;
[JsonPropertyName("excludemiss")]
public bool? ExcludeMiss
{
get { return _ExcludeMiss; }
set { _ExcludeMiss = value; }
}
private bool? _ExcludeNie;
[JsonPropertyName("excludenie")]
public bool? ExcludeNie
{
get { return _ExcludeNie; }
set { _ExcludeNie = value; }
}
private bool? _SearchCustomer;
[JsonPropertyName("searchcustomer")]
public bool? SearchCustomer
{
get { return _SearchCustomer; }
set { _SearchCustomer = value; }
}
}
}
