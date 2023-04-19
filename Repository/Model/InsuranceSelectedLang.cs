using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("InsuranceSelectedLang")]
public class InsuranceSelectedLang: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _LangId;
[JsonPropertyName("langid")]
public int? LangId
{
get { return _LangId; }
set { _LangId = value; }
}
private int? _InsurancesId;
[JsonPropertyName("insurancesid")]
public int? InsurancesId
{
get { return _InsurancesId; }
set { _InsurancesId = value; }
}
}
}
