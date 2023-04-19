using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteSettingsSearchEngine")]
public class AgencyMicroSiteSettingsSearchEngine: IEntity
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
private int? _DefaultAvailabilityTimeoutDuration;
[JsonPropertyName("defaultavailabilitytimeoutduration")]
public int? DefaultAvailabilityTimeoutDuration
{
get { return _DefaultAvailabilityTimeoutDuration; }
set { _DefaultAvailabilityTimeoutDuration = value; }
}
private int? _DefaultReleaseDaysForEarlyBooking;
[JsonPropertyName("defaultreleasedaysforearlybooking")]
public int? DefaultReleaseDaysForEarlyBooking
{
get { return _DefaultReleaseDaysForEarlyBooking; }
set { _DefaultReleaseDaysForEarlyBooking = value; }
}
private int? _DefaultReleaseDaysB2BUsers;
[JsonPropertyName("defaultreleasedaysb2busers")]
public int? DefaultReleaseDaysB2BUsers
{
get { return _DefaultReleaseDaysB2BUsers; }
set { _DefaultReleaseDaysB2BUsers = value; }
}
private int? _DefaultReleaseDaysOtherUsers;
[JsonPropertyName("defaultreleasedaysotherusers")]
public int? DefaultReleaseDaysOtherUsers
{
get { return _DefaultReleaseDaysOtherUsers; }
set { _DefaultReleaseDaysOtherUsers = value; }
}
private int? _MinimumNightAllowed;
[JsonPropertyName("minimumnightallowed")]
public int? MinimumNightAllowed
{
get { return _MinimumNightAllowed; }
set { _MinimumNightAllowed = value; }
}
}
}
