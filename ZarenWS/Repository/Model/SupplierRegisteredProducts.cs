using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("SupplierRegisteredProducts")]
public class SupplierRegisteredProducts: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _ContractInfo;
[JsonPropertyName("contractinfo")]
public string ContractInfo
{
get { return _ContractInfo; }
set { _ContractInfo = value; }
}
private int _SupplierId;
[Key]
[JsonPropertyName("supplierid")]
public int SupplierId
{
get { return _SupplierId; }
set { _SupplierId = value; }
}
private int? _ProductTypeId;
[JsonPropertyName("producttypeid")]
public int? ProductTypeId
{
get { return _ProductTypeId; }
set { _ProductTypeId = value; }
}
private DateTime? _CreatedDate;
[JsonPropertyName("createddate")]
public DateTime? CreatedDate
{
get { return _CreatedDate; }
set { _CreatedDate = value; }
}
private DateTime? _UpdatedDate;
[JsonPropertyName("updateddate")]
public DateTime? UpdatedDate
{
get { return _UpdatedDate; }
set { _UpdatedDate = value; }
}
private int? _CreatedBy;
[JsonPropertyName("createdby")]
public int? CreatedBy
{
get { return _CreatedBy; }
set { _CreatedBy = value; }
}
private int? _UpdatedBy;
[JsonPropertyName("updatedby")]
public int? UpdatedBy
{
get { return _UpdatedBy; }
set { _UpdatedBy = value; }
}
private int? _Fee;
[JsonPropertyName("fee")]
public int? Fee
{
get { return _Fee; }
set { _Fee = value; }
}
}
}
