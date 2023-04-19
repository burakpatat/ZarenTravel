using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Contacts")]
public class Contacts: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _TelNumber;
[JsonPropertyName("telnumber")]
public string TelNumber
{
get { return _TelNumber; }
set { _TelNumber = value; }
}
private string _FaxNumber;
[JsonPropertyName("faxnumber")]
public string FaxNumber
{
get { return _FaxNumber; }
set { _FaxNumber = value; }
}
private string _Email;
[JsonPropertyName("email")]
public string Email
{
get { return _Email; }
set { _Email = value; }
}
}
}
