using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("SupplierSellingDestinations")]
public class SupplierSellingDestinations: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int _SupplierId;
[Key]
[JsonPropertyName("supplierid")]
public int SupplierId
{
get { return _SupplierId; }
set { _SupplierId = value; }
}
private int? _City;
[JsonPropertyName("city")]
public int? City
{
get { return _City; }
set { _City = value; }
}
private int? _Country;
[JsonPropertyName("country")]
public int? Country
{
get { return _Country; }
set { _Country = value; }
}
private int? _TableOrder;
[JsonPropertyName("tableorder")]
public int? TableOrder
{
get { return _TableOrder; }
set { _TableOrder = value; }
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
}
}
