using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("HotelSeasonMediaFiles")]
public class HotelSeasonMediaFiles: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private string _SystemId;
[JsonPropertyName("systemid")]
public string SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
}
private int? _LanguageId;
[JsonPropertyName("languageid")]
public int? LanguageId
{
get { return _LanguageId; }
set { _LanguageId = value; }
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
private string _UrlFull;
[JsonPropertyName("urlfull")]
public string UrlFull
{
get { return _UrlFull; }
set { _UrlFull = value; }
}
private string _Url;
[JsonPropertyName("url")]
public string Url
{
get { return _Url; }
set { _Url = value; }
}
private int? _FileType;
[JsonPropertyName("filetype")]
public int? FileType
{
get { return _FileType; }
set { _FileType = value; }
}
private int? _SeasonId;
[JsonPropertyName("seasonid")]
public int? SeasonId
{
get { return _SeasonId; }
set { _SeasonId = value; }
}
private int? _Type;
[JsonPropertyName("type")]
public int? Type
{
get { return _Type; }
set { _Type = value; }
}
}
}
