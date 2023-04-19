using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyContractsHotelInformationImage")]
public class AgencyContractsHotelInformationImage: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private string _ImageUrl;
[JsonPropertyName("imageurl")]
public string ImageUrl
{
get { return _ImageUrl; }
set { _ImageUrl = value; }
}
private string _ImagePath;
[JsonPropertyName("imagepath")]
public string ImagePath
{
get { return _ImagePath; }
set { _ImagePath = value; }
}
}
}
