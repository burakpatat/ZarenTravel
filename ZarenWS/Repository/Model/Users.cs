using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Users")]
public class Users: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _GovernmentID;
[JsonPropertyName("governmentid")]
public string GovernmentID
{
get { return _GovernmentID; }
set { _GovernmentID = value; }
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
private int? _Status;
[JsonPropertyName("status")]
public int? Status
{
get { return _Status; }
set { _Status = value; }
}
private string _UserName;
[JsonPropertyName("username")]
public string UserName
{
get { return _UserName; }
set { _UserName = value; }
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
private bool? _IsMaster;
[JsonPropertyName("ismaster")]
public bool? IsMaster
{
get { return _IsMaster; }
set { _IsMaster = value; }
}
private int? _Gender;
[JsonPropertyName("gender")]
public int? Gender
{
get { return _Gender; }
set { _Gender = value; }
}
private int? _UserType;
[JsonPropertyName("usertype")]
public int? UserType
{
get { return _UserType; }
set { _UserType = value; }
}
private DateTime? _CreateDate;
[JsonPropertyName("createdate")]
public DateTime? CreateDate
{
get { return _CreateDate; }
set { _CreateDate = value; }
}
private string _BirthPlace;
[JsonPropertyName("birthplace")]
public string BirthPlace
{
get { return _BirthPlace; }
set { _BirthPlace = value; }
}
private int? _MaritalStatus;
[JsonPropertyName("maritalstatus")]
public int? MaritalStatus
{
get { return _MaritalStatus; }
set { _MaritalStatus = value; }
}
private DateTime? _BirthDate;
[JsonPropertyName("birthdate")]
public DateTime? BirthDate
{
get { return _BirthDate; }
set { _BirthDate = value; }
}
private string _MotherName;
[JsonPropertyName("mothername")]
public string MotherName
{
get { return _MotherName; }
set { _MotherName = value; }
}
private bool? _IsSuperAdmin;
[JsonPropertyName("issuperadmin")]
public bool? IsSuperAdmin
{
get { return _IsSuperAdmin; }
set { _IsSuperAdmin = value; }
}
private int? _Products;
[JsonPropertyName("products")]
public int? Products
{
get { return _Products; }
set { _Products = value; }
}
}
}
