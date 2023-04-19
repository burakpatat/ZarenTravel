using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class CompanyCustomFieldsGetCoCuTimestampBetweenResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _CompanyId;
[JsonPropertyName("companyId")]
public int? CompanyId
{
get { return _CompanyId; }
set { _CompanyId = value; }
}
private string _CoCuCode;
[JsonPropertyName("coCuCode")]
public string CoCuCode
{
get { return _CoCuCode; }
set { _CoCuCode = value; }
}
private int? _FiTyId;
[JsonPropertyName("fiTyId")]
public int? FiTyId
{
get { return _FiTyId; }
set { _FiTyId = value; }
}
private DateTime? _CoCuTimestamp;
[JsonPropertyName("coCuTimestamp")]
public DateTime? CoCuTimestamp
{
get { return _CoCuTimestamp; }
set { _CoCuTimestamp = value; }
}
private int? _CoCuActive;
[JsonPropertyName("coCuActive")]
public int? CoCuActive
{
get { return _CoCuActive; }
set { _CoCuActive = value; }
}
}
}
