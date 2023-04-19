using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class ChainUpdateResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _ChainCode;
[JsonPropertyName("chainCode")]
public string ChainCode
{
get { return _ChainCode; }
set { _ChainCode = value; }
}
private string _ChainName;
[JsonPropertyName("chainName")]
public string ChainName
{
get { return _ChainName; }
set { _ChainName = value; }
}
private DateTime? _ChainTimestamp;
[JsonPropertyName("chainTimestamp")]
public DateTime? ChainTimestamp
{
get { return _ChainTimestamp; }
set { _ChainTimestamp = value; }
}
private bool? _ChainActive;
[JsonPropertyName("chainActive")]
public bool? ChainActive
{
get { return _ChainActive; }
set { _ChainActive = value; }
}
}
}
