using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class IndustrySegmentGetByInSeTimestampResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _InSeDescription;
[JsonPropertyName("inSeDescription")]
public string InSeDescription
{
get { return _InSeDescription; }
set { _InSeDescription = value; }
}
private DateTime? _InSeTimestamp;
[JsonPropertyName("inSeTimestamp")]
public DateTime? InSeTimestamp
{
get { return _InSeTimestamp; }
set { _InSeTimestamp = value; }
}
private bool? _InSeActive;
[JsonPropertyName("inSeActive")]
public bool? InSeActive
{
get { return _InSeActive; }
set { _InSeActive = value; }
}
}
}
