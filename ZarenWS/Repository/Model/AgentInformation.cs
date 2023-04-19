using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgentInformation")]
public class AgentInformation: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _AgentCode;
[Key]
[JsonPropertyName("agentcode")]
public string AgentCode
{
get { return _AgentCode; }
set { _AgentCode = value; }
}
private string _AgentName;
[JsonPropertyName("agentname")]
public string AgentName
{
get { return _AgentName; }
set { _AgentName = value; }
}
private string _AgentStation;
[JsonPropertyName("agentstation")]
public string AgentStation
{
get { return _AgentStation; }
set { _AgentStation = value; }
}
private int? _FILE_ID;
[JsonPropertyName("file_id")]
public int? FILE_ID
{
get { return _FILE_ID; }
set { _FILE_ID = value; }
}
private string _FILE_NAME;
[JsonPropertyName("file_name")]
public string FILE_NAME
{
get { return _FILE_NAME; }
set { _FILE_NAME = value; }
}
private DateTime? _RecordDateStamp;
[JsonPropertyName("recorddatestamp")]
public DateTime? RecordDateStamp
{
get { return _RecordDateStamp; }
set { _RecordDateStamp = value; }
}
}
}
