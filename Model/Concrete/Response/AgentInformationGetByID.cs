using Dapper.Contrib.Extensions;
using System;
using System.Text.Json.Serialization;
using Core.Interfaces;

     namespace Model.Concrete
{
public class AgentInformationGetByIDResponse: IEntity
{
private int _Id;
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _AgentCode;
[JsonPropertyName("agentCode")]
public string AgentCode
{
get { return _AgentCode; }
set { _AgentCode = value; }
}
private string _AgentName;
[JsonPropertyName("agentName")]
public string AgentName
{
get { return _AgentName; }
set { _AgentName = value; }
}
private string _AgentStation;
[JsonPropertyName("agentStation")]
public string AgentStation
{
get { return _AgentStation; }
set { _AgentStation = value; }
}
private int? _FILE_ID;
[JsonPropertyName("fILE_ID")]
public int? FILE_ID
{
get { return _FILE_ID; }
set { _FILE_ID = value; }
}
private string _FILE_NAME;
[JsonPropertyName("fILE_NAME")]
public string FILE_NAME
{
get { return _FILE_NAME; }
set { _FILE_NAME = value; }
}
private DateTime? _RecordDateStamp;
[JsonPropertyName("recordDateStamp")]
public DateTime? RecordDateStamp
{
get { return _RecordDateStamp; }
set { _RecordDateStamp = value; }
}
}
}
