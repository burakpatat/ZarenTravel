using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("CarTypes")]
public class CarTypes: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _CaTyCode;
[JsonPropertyName("catycode")]
public string CaTyCode
{
get { return _CaTyCode; }
set { _CaTyCode = value; }
}
private string _CaTyDescription;
[JsonPropertyName("catydescription")]
public string CaTyDescription
{
get { return _CaTyDescription; }
set { _CaTyDescription = value; }
}
private DateTime? _CaTyTimestamp;
[JsonPropertyName("catytimestamp")]
public DateTime? CaTyTimestamp
{
get { return _CaTyTimestamp; }
set { _CaTyTimestamp = value; }
}
private bool? _CaTyActive;
[JsonPropertyName("catyactive")]
public bool? CaTyActive
{
get { return _CaTyActive; }
set { _CaTyActive = value; }
}
}
}
