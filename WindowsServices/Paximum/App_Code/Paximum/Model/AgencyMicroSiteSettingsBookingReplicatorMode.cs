using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsBookingReplicatorMode")]
public class AgencyMicroSiteSettingsBookingReplicatorMode: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private bool? _CustomizeIt;
[JsonPropertyName("customizeit")]
public bool? CustomizeIt
{
get { return _CustomizeIt; }
set { _CustomizeIt = value; }
}
private bool? _DirectBookingWithoutChanges;
[JsonPropertyName("directbookingwithoutchanges")]
public bool? DirectBookingWithoutChanges
{
get { return _DirectBookingWithoutChanges; }
set { _DirectBookingWithoutChanges = value; }
}
private bool? _IWantIt;
[JsonPropertyName("iwantit")]
public bool? IWantIt
{
get { return _IWantIt; }
set { _IWantIt = value; }
}
}
}
