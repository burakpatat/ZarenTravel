using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("PageContents")]
public class PageContents: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _ContentTitle;
[JsonPropertyName("contenttitle")]
public string ContentTitle
{
get { return _ContentTitle; }
set { _ContentTitle = value; }
}
private string _Contents;
[JsonPropertyName("contents")]
public string Contents
{
get { return _Contents; }
set { _Contents = value; }
}
}
}
