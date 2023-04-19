using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("HotelRoomLanguages")]
public class HotelRoomLanguages: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _HotelRoomId;
[JsonPropertyName("hotelroomid")]
public int? HotelRoomId
{
get { return _HotelRoomId; }
set { _HotelRoomId = value; }
}
private int? _LanguageId;
[JsonPropertyName("languageid")]
public int? LanguageId
{
get { return _LanguageId; }
set { _LanguageId = value; }
}
private string _Name;
[JsonPropertyName("name")]
public string Name
{
get { return _Name; }
set { _Name = value; }
}
private string _Description;
[JsonPropertyName("description")]
public string Description
{
get { return _Description; }
set { _Description = value; }
}
}
}
