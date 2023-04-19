using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyCmsThemes")]
public class AgencyCmsThemes: IEntity
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
private string _Icon;
[JsonPropertyName("icon")]
public string Icon
{
get { return _Icon; }
set { _Icon = value; }
}
private int? _Orders;
[JsonPropertyName("orders")]
public int? Orders
{
get { return _Orders; }
set { _Orders = value; }
}
private string _ImagePath;
[JsonPropertyName("imagepath")]
public string ImagePath
{
get { return _ImagePath; }
set { _ImagePath = value; }
}
private string _ImageLink;
[JsonPropertyName("imagelink")]
public string ImageLink
{
get { return _ImageLink; }
set { _ImageLink = value; }
}
private bool? _IsMainTheme;
[JsonPropertyName("ismaintheme")]
public bool? IsMainTheme
{
get { return _IsMainTheme; }
set { _IsMainTheme = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
}
}
