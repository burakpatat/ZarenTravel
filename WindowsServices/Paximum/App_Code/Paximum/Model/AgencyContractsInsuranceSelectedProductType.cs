using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyContractsInsuranceSelectedProductType")]
public class AgencyContractsInsuranceSelectedProductType: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _InsuranceId;
[JsonPropertyName("insuranceid")]
public int? InsuranceId
{
get { return _InsuranceId; }
set { _InsuranceId = value; }
}
private int? _ProductTypeId;
[JsonPropertyName("producttypeid")]
public int? ProductTypeId
{
get { return _ProductTypeId; }
set { _ProductTypeId = value; }
}
}
}
