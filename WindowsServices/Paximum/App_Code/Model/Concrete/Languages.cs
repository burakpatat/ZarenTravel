﻿using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Languages")]
public class Languages: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _ShortCode;
[JsonPropertyName("shortcode")]
public string ShortCode
{
get { return _ShortCode; }
set { _ShortCode = value; }
}
private string _Tr;
[JsonPropertyName("tr")]
public string Tr
{
get { return _Tr; }
set { _Tr = value; }
}
private string _En;
[JsonPropertyName("en")]
public string En
{
get { return _En; }
set { _En = value; }
}
private string _De;
[JsonPropertyName("de")]
public string De
{
get { return _De; }
set { _De = value; }
}
private string _Fr;
[JsonPropertyName("fr")]
public string Fr
{
get { return _Fr; }
set { _Fr = value; }
}
private string _Es;
[JsonPropertyName("es")]
public string Es
{
get { return _Es; }
set { _Es = value; }
}
private string _It;
[JsonPropertyName("it")]
public string It
{
get { return _It; }
set { _It = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private int? _LanguageId;
[JsonPropertyName("languageid")]
public int? LanguageId
{
get { return _LanguageId; }
set { _LanguageId = value; }
}
private string _SystemId;
[JsonPropertyName("systemid")]
public string SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
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