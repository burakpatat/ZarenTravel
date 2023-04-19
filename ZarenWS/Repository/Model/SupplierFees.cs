using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("SupplierFees")]
public class SupplierFees: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _SupplierId;
[JsonPropertyName("supplierid")]
public int? SupplierId
{
get { return _SupplierId; }
set { _SupplierId = value; }
}
private int? _ProductId;
[JsonPropertyName("productid")]
public int? ProductId
{
get { return _ProductId; }
set { _ProductId = value; }
}
private int? _Amount;
[JsonPropertyName("amount")]
public int? Amount
{
get { return _Amount; }
set { _Amount = value; }
}
private int? _CurrencyId;
[JsonPropertyName("currencyid")]
public int? CurrencyId
{
get { return _CurrencyId; }
set { _CurrencyId = value; }
}
private bool? _ByPercentage;
[JsonPropertyName("bypercentage")]
public bool? ByPercentage
{
get { return _ByPercentage; }
set { _ByPercentage = value; }
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
