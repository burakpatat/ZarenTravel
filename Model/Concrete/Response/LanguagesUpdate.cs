using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class LanguagesUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _LanguagesName;
[JsonPropertyName("languagesName")]
public string LanguagesName
{
get { return _LanguagesName; }
set { _LanguagesName = value; }
}
private string _LanguagesCode;
[JsonPropertyName("languagesCode")]
public string LanguagesCode
{
get { return _LanguagesCode; }
set { _LanguagesCode = value; }
}
private DateTime? _LanguagesTimestamp;
[JsonPropertyName("languagesTimestamp")]
public DateTime? LanguagesTimestamp
{
get { return _LanguagesTimestamp; }
set { _LanguagesTimestamp = value; }
}
private bool? _LanguagesActive;
[JsonPropertyName("languagesActive")]
public bool? LanguagesActive
{
get { return _LanguagesActive; }
set { _LanguagesActive = value; }
}
}
}
