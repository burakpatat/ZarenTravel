using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Model.Concrete
{
    public class Component : IEntity
    {
        public CodeType ExportLanguage { get; set; }
        public string Name { get; set; }
        public string FrontEndRender { get; set; }
        public string BackendRender { get; set; }
        public Method Request { get; set; }
        public List<Module> Modules { get; set; }
        public List<string> Inherits { get; set; }
    }


    public class Module : IEntity
    {
        public List<string> Inherits { get; set; }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _FileExtension;
        public string FileExtension
        {
            get { return _FileExtension; }
            set { _FileExtension = value; }
        }

        private int _Version;
        public int Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        private string _RunningPath;
        public string RunningPath
        {
            get { return _RunningPath; }
            set { _RunningPath = value; }
        }

        private string _ExportPath;
        public string ExportPath
        {
            get { return _ExportPath; }
            set { _ExportPath = value; }
        }

        private string _UrlTemplate;
        public string UrlTemplate
        {
            get { return _UrlTemplate; }
            set { _UrlTemplate = value; }
        }
        private string _OnMaster;
        public string OnMaster
        {
            get { return _OnMaster; }
            set { _OnMaster = value; }
        }

        private string _OnClickFunction;
        public string OnClickFunction
        {
            get { return _OnClickFunction; }
            set { _OnClickFunction = value; }
        }

        private string _OnLoad;
        public string OnLoad
        {
            get { return _OnLoad; }
            set { _OnLoad = value; }
        }

        private string _OnChange;
        public string OnChange
        {
            get { return _OnChange; }
            set { _OnChange = value; }
        }

        private string _OnFocus;
        public string OnFocus
        {
            get { return _OnFocus; }
            set { _OnFocus = value; }
        }
        private string _OnSubmitForm;
        public string OnSubmitForm
        {
            get { return _OnSubmitForm; }
            set { _OnSubmitForm = value; }
        }

        private List<string> _ClassList;
        public List<string> ClassList
        {
            get { return _ClassList; }
            set { _ClassList = value; }
        }



        private List<HtmlAttribute> _HtmlAttributeList;
        public List<HtmlAttribute> HtmlAttributeList
        {
            get { return _HtmlAttributeList; }
            set { _HtmlAttributeList = value; }
        }

        private string _CrtptoKey;
        public string CrtptoKey
        {
            get { return _CrtptoKey; }
            set { _CrtptoKey = value; }
        }
        private int _PageView;
        public int PageView
        {
            get { return _PageView; }
            set { _PageView = value; }
        }



        public string HttpRequest
        {
            get { return "HttpContext.Current.Request.ToJson()"; }

        }

        public string HttpUser
        {
            get { return "HttpContext.Current.User.ToJson()"; }

        }

        private string _HTMLReplaceCacther;
        public string HTMLReplaceCacther
        {
            get { return _HTMLReplaceCacther; }
            set { _HTMLReplaceCacther = value; }
        }

        private CodeType _CodeExport;
        public CodeType CodeExport
        {
            get { return _CodeExport; }
        }

        private List<Module> _SubModules;
        public List<Module> SubModules
        {
            get { return _SubModules; }
            set { _SubModules = value; }
        }

        private List<Module> _ChildModules;
        public List<Module> ChildModules
        {
            get { return _SubModules; }
            set { _SubModules = value; }
        }

        private List<Module> _PrefferedModuleGroups;
        public List<Module> PrefferedModuleGroups
        {
            get { return _PrefferedModuleGroups; }
            set { _PrefferedModuleGroups = value; }
        }

        private List<Validation> _ValidationList;
        public List<Validation> ValidationList
        {
            get { return _ValidationList; }
            set { _ValidationList = value; }
        }

        public string FormName { get; set; }
        public string CodeComment { get; set; }

        public string ToolTipDescription { get; set; }

        public string ResizeWidth { get; set; }
        public string ResizeHeight { get; set; }
    }
    public enum CodeType
    {
        BlazorCMS = 1,
        WebFormCMS = 2,
        NetCoreApi = 3,
        TypeScript = 4,
        Javascript = 5,
        JSX = 6,
        HTML = 7,
        IOnic = 8,
        ReactNative = 9,
        Vue = 10,
        ReactRedux = 11,
        ReactNext = 12
    }

    public class CodeTemplates
    {
        public string Template { get; set; }
        public string TemplateName { get; set; }
        public CodeType CodeType { get; set; }
    }

    public enum CssStyle
    {
        Border = 1,
        Cursor = 2,
        Color = 3,
        BoxSizing = 4,
        Width = 5,
        Height = 6,
        TextTransform = 7,
        Margin = 8,
        Padding = 9,
        Display = 10,
        Background = 11,
        ListStyle = 12,
        Position = 13,
        Top = 14,
        Left = 15,
        Right = 16,
        Bottom = 17,
        BorderRadius = 18,
        TextAlign = 19,
        VerticalAlign = 20,
        Overflow = 21,
        Float = 22,
        FontFamily = 23
    }

    public enum HtmlAttribute
    {
        ElementPrefix = 0,
        Type = 1,
        Value = 2,
        Cheched = 23,
        PlaceHolder = 3,
        Group = 4,
        Name = 5,
        Id = 6,
        Class = 7,
        Style = 8,
        ContentEditable = 9,
        CloseTag = 10,
        Label = 11,
        HasChild = 12,
        ApiUrl = 13,
        Data = 14,
        Custom = 15,
        Mask = 16,
        MobileClass = 17,
        IsResponsive = 18,
        Src = 19,
        AutoFocus = 20,
        TabIndex = 21,
        For = 22
    }

    public class HtmlAttributeTemplate
    {
        public string ElementPrefix;
        public string Type;
        public string Value;

        public string Cheched;
        public string PlaceHolder;
        public string Group;
        public string Name;
        public string Id;
        public string Class;
        public string Style;
        public string ContentEditable;
        public string CloseTag;
        public string Label;
        public string HasChild;
        public string ApiUrl;
        public string Data;
        public string Custom;
        public string Mask;
        public string MobileClass;
        public string IsResponsive;
        public string Src;
        public string AutoFocus;
        public string TabIndex;
        public string For;
    }



    public class Validation
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Class { get; set; }
        public List<Resources> Messages { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public string GroupName { get; set; }
        public object IfThisValue { get; set; }
        public Type IfThisType { get; set; }
        public Regex Regex { get; set; }

    }

    public class Values
    {
        [JsonPropertyName("label")]
        public string Label;

        [JsonPropertyName("value")]
        public string Value;

        [JsonPropertyName("selected")]
        public bool Selected;
    }


}
