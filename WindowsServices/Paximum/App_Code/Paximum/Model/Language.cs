using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Language")]
public class Language: IEntity
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
}
}
