using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("Hotels")]
public class Hotels: IEntity
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
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private string _SystemId;
[JsonPropertyName("systemid")]
public string SystemId
{
get { return _SystemId; }
set { _SystemId = value; }
}
private string _GiataId;
[JsonPropertyName("giataid")]
public string GiataId
{
get { return _GiataId; }
set { _GiataId = value; }
}
private string _FaxNumber;
[JsonPropertyName("faxnumber")]
public string FaxNumber
{
get { return _FaxNumber; }
set { _FaxNumber = value; }
}
private string _PhoneNumber;
[JsonPropertyName("phonenumber")]
public string PhoneNumber
{
get { return _PhoneNumber; }
set { _PhoneNumber = value; }
}
private string _HomePage;
[JsonPropertyName("homepage")]
public string HomePage
{
get { return _HomePage; }
set { _HomePage = value; }
}
private int? _StopSaleGuaranteed;
[JsonPropertyName("stopsaleguaranteed")]
public int? StopSaleGuaranteed
{
get { return _StopSaleGuaranteed; }
set { _StopSaleGuaranteed = value; }
}
private int? _StopSaleStandart;
[JsonPropertyName("stopsalestandart")]
public int? StopSaleStandart
{
get { return _StopSaleStandart; }
set { _StopSaleStandart = value; }
}
private double? _Stars;
[JsonPropertyName("stars")]
public double? Stars
{
get { return _Stars; }
set { _Stars = value; }
}
private double? _Rating;
[JsonPropertyName("rating")]
public double? Rating
{
get { return _Rating; }
set { _Rating = value; }
}
private string _Provider;
[JsonPropertyName("provider")]
public string Provider
{
get { return _Provider; }
set { _Provider = value; }
}
private string _Thumbnail;
[JsonPropertyName("thumbnail")]
public string Thumbnail
{
get { return _Thumbnail; }
set { _Thumbnail = value; }
}
private string _ThumbnailFull;
[JsonPropertyName("thumbnailfull")]
public string ThumbnailFull
{
get { return _ThumbnailFull; }
set { _ThumbnailFull = value; }
}
private DateTime? _CreatedDate;
[JsonPropertyName("createddate")]
public DateTime? CreatedDate
{
get { return _CreatedDate; }
set { _CreatedDate = value; }
}
private DateTime? _UpdatedDate;
[JsonPropertyName("updateddate")]
public DateTime? UpdatedDate
{
get { return _UpdatedDate; }
set { _UpdatedDate = value; }
}
private int? _CreatedBy;
[JsonPropertyName("createdby")]
public int? CreatedBy
{
get { return _CreatedBy; }
set { _CreatedBy = value; }
}
private int? _UpdatedBy;
[JsonPropertyName("updatedby")]
public int? UpdatedBy
{
get { return _UpdatedBy; }
set { _UpdatedBy = value; }
}
private int? _Statu;
[JsonPropertyName("statu")]
public int? Statu
{
get { return _Statu; }
set { _Statu = value; }
}
}
}
