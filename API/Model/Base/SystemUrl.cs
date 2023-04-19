using System.Collections.Generic;

/// <summary>
/// SystemUrl için özet açıklama
/// </summary>
public class ProjectFile
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public List<RouteDefines> RouteDefines { get; set; }

    public List<string> Url { get; set; }
    public bool? HasGuard { get; set; }
    public bool? IsAccessable { get; set; }
    public string BackUpPath { get; set; }
    public bool? HasLayout { get; set; }
    public List<string> Permissions { get; set; }
    public string FilePath { get; set; }
    public bool? IsClass { get; set; }
    public bool? IsStartPage { get; set; }
    public bool? IsErrorPage { get; set; }
}


public class DefinedUrl
{
    public string Name { get; set; }
    public string Route { get; set; }
    public string RouteKey { get; set; }

    public string PhysicalPath { get; set; }
    public List<string> RedirectUrl { get; set; }
    public List<string> Url { get; set; }
    public Language Language { get; set; }
    public List<string> SecurityParameters { get; set; }
    public Dictionary<string, string> Header { get; set; }
    public Dictionary<string, string> QueryStrings { get; set; }
    public List<string> DefinedQueryParams { get; set; }
    public Dictionary<string, string> RequestColumns { get; set; }
    public bool IsListRequest { get; set; }
    public Dictionary<string, string> InsertColumns { get; set; }
    public Dictionary<string, string> CreateColumns { get; set; }
    public Dictionary<string, string> SelectColumns { get; set; }

    public Dictionary<string, string> OrderColumns { get; set; }
    public Dictionary<string, string> WherePairs { get; set; }
    public Dictionary<string, string> ResponseColumns { get; set; }

    public bool? HasGuard { get; set; }
    public List<string> Permissions { get; set; }
    public string ReplacePrefix { get; set; }
}

public class RouteDefines
{

    public string routeName { get; set; }
    public string routeUrl { get; set; }
    public string physicalFile { get; set; }
    public bool checkPhysicalUrlAccess { get; set; }

}