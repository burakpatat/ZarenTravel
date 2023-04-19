using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyUsers")]
public class AgencyUsers: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _UserName;
[JsonPropertyName("username")]
public string UserName
{
get { return _UserName; }
set { _UserName = value; }
}
private bool? _IsB2C;
[JsonPropertyName("isb2c")]
public bool? IsB2C
{
get { return _IsB2C; }
set { _IsB2C = value; }
}
private bool? _IsB2B;
[JsonPropertyName("isb2b")]
public bool? IsB2B
{
get { return _IsB2B; }
set { _IsB2B = value; }
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
private string _Password;
[JsonPropertyName("password")]
public string Password
{
get { return _Password; }
set { _Password = value; }
}
private string _Email;
[JsonPropertyName("email")]
public string Email
{
get { return _Email; }
set { _Email = value; }
}
private string _ForwardToEmail;
[JsonPropertyName("forwardtoemail")]
public string ForwardToEmail
{
get { return _ForwardToEmail; }
set { _ForwardToEmail = value; }
}
private string _Phone;
[JsonPropertyName("phone")]
public string Phone
{
get { return _Phone; }
set { _Phone = value; }
}
private int? _Gender;
[JsonPropertyName("gender")]
public int? Gender
{
get { return _Gender; }
set { _Gender = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _Surname;
[JsonPropertyName("surname")]
public string Surname
{
get { return _Surname; }
set { _Surname = value; }
}
private int? _Country;
[JsonPropertyName("country")]
public int? Country
{
get { return _Country; }
set { _Country = value; }
}
private DateTime? _BirthDate;
[JsonPropertyName("birthdate")]
public DateTime? BirthDate
{
get { return _BirthDate; }
set { _BirthDate = value; }
}
private string _DocumentNumber;
[JsonPropertyName("documentnumber")]
public string DocumentNumber
{
get { return _DocumentNumber; }
set { _DocumentNumber = value; }
}
private string _ExternalCode;
[JsonPropertyName("externalcode")]
public string ExternalCode
{
get { return _ExternalCode; }
set { _ExternalCode = value; }
}
private string _Remark;
[JsonPropertyName("remark")]
public string Remark
{
get { return _Remark; }
set { _Remark = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _Statu;
[JsonPropertyName("statu")]
public int? Statu
{
get { return _Statu; }
set { _Statu = value; }
}
private decimal? _ManagementFeeAmount;
[JsonPropertyName("managementfeeamount")]
public decimal? ManagementFeeAmount
{
get { return _ManagementFeeAmount; }
set { _ManagementFeeAmount = value; }
}
private bool? _ManagementFeeByPercentage;
[JsonPropertyName("managementfeebypercentage")]
public bool? ManagementFeeByPercentage
{
get { return _ManagementFeeByPercentage; }
set { _ManagementFeeByPercentage = value; }
}
private int? _ManagementFeeCurrencyId;
[JsonPropertyName("managementfeecurrencyid")]
public int? ManagementFeeCurrencyId
{
get { return _ManagementFeeCurrencyId; }
set { _ManagementFeeCurrencyId = value; }
}
}
}
