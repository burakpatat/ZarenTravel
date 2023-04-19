using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyContractsConfigurationByHotel")]
public class AgencyContractsConfigurationByHotel: IEntity
{
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
private int? _HotelConfigurationId;
[JsonPropertyName("hotelconfigurationid")]
public int? HotelConfigurationId
{
get { return _HotelConfigurationId; }
set { _HotelConfigurationId = value; }
}
}
}
