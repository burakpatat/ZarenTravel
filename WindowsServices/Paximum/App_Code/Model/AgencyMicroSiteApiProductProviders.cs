﻿using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{
[Table("AgencyMicroSiteApiProductProviders")]
public class AgencyMicroSiteApiProductProviders: IEntity
{
private int _Id;
[Key]
[JsonPropertyName("id")]
public int Id
{
get { return _Id; }
set { _Id = value; }
}
private int? _ApiId;
[JsonPropertyName("apiid")]
public int? ApiId
{
get { return _ApiId; }
set { _ApiId = value; }
}
private int? _ApiProductId;
[JsonPropertyName("apiproductid")]
public int? ApiProductId
{
get { return _ApiProductId; }
set { _ApiProductId = value; }
}
private int? _MicroSiteId;
[JsonPropertyName("micrositeid")]
public int? MicroSiteId
{
get { return _MicroSiteId; }
set { _MicroSiteId = value; }
}
private int? _Priority;
[JsonPropertyName("priority")]
public int? Priority
{
get { return _Priority; }
set { _Priority = value; }
}
private int? _AgencyId;
[JsonPropertyName("agencyid")]
public int? AgencyId
{
get { return _AgencyId; }
set { _AgencyId = value; }
}
private bool? _HasConsolidate;
[JsonPropertyName("hasconsolidate")]
public bool? HasConsolidate
{
get { return _HasConsolidate; }
set { _HasConsolidate = value; }
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
}
}
