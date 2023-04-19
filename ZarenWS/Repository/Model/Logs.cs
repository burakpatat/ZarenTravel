using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Logs")]
public class Logs: IEntity
{
private int _ID;
[Key]
[JsonPropertyName("id")]
public int ID
{
get { return _ID; }
set { _ID = value; }
}
private string _Description;
[JsonPropertyName("description")]
public string Description
{
get { return _Description; }
set { _Description = value; }
}
private DateTime? _Date;
[JsonPropertyName("date")]
public DateTime? Date
{
get { return _Date; }
set { _Date = value; }
}
private int? _Type;
[JsonPropertyName("type")]
public int? Type
{
get { return _Type; }
set { _Type = value; }
}
private string _LogPath;
[JsonPropertyName("logpath")]
public string LogPath
{
get { return _LogPath; }
set { _LogPath = value; }
}
private string _LogMethod;
[JsonPropertyName("logmethod")]
public string LogMethod
{
get { return _LogMethod; }
set { _LogMethod = value; }
}
private int? _UserID;
[JsonPropertyName("userid")]
public int? UserID
{
get { return _UserID; }
set { _UserID = value; }
}
private string _UserAgent;
[JsonPropertyName("useragent")]
public string UserAgent
{
get { return _UserAgent; }
set { _UserAgent = value; }
}
private string _UserHostAddress;
[JsonPropertyName("userhostaddress")]
public string UserHostAddress
{
get { return _UserHostAddress; }
set { _UserHostAddress = value; }
}
private string _UrlOriginalString;
[JsonPropertyName("urloriginalstring")]
public string UrlOriginalString
{
get { return _UrlOriginalString; }
set { _UrlOriginalString = value; }
}
}
}
