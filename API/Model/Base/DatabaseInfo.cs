
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class DatabaseInfo : IEntity
{

    [JsonPropertyName("Name")]
    public string Name;

    [JsonPropertyName("Dbid")]
    public int Dbid;

    [JsonPropertyName("Sid")]
    public string Sid;

    [JsonPropertyName("Mode")]
    public int Mode;

    [JsonPropertyName("Status")]
    public int Status;

    [JsonPropertyName("Status2")]
    public int Status2;

    [JsonPropertyName("Crdate")]
    public DateTime Crdate;

    [JsonPropertyName("Reserved")]
    public DateTime Reserved;

    [JsonPropertyName("Category")]
    public int Category;

    [JsonPropertyName("Cmptlevel")]
    public int Cmptlevel;

    [JsonPropertyName("Version")]
    public int Version;

    [JsonPropertyName("ConnectionString")]
    public string ConnectionString;

    [JsonPropertyName("ServerCridential")]
    public string ServerCridential;

    [JsonPropertyName("RootPath")]
    public string RootPath;

    [JsonPropertyName("SiteUrl")]
    public string SiteUrl;

    [JsonPropertyName("ProjectBase")]
    public string ProjectBase;

    [JsonPropertyName("NetCoreApi")]
    public string NetCoreApi;

    [JsonPropertyName("DataAbstractDapper")]
    public string DataAbstractDapper;

    [JsonPropertyName("DataConcreteDapper")]
    public string DataConcreteDapper;

    [JsonPropertyName("BusinessAbstractDapper")]
    public string BusinessAbstractDapper;

    [JsonPropertyName("BusinessConcreteDapper")]
    public string BusinessConcreteDapper;

    [JsonPropertyName("ModelConcreteDapper")]
    public string ModelConcreteDapper;

    [JsonPropertyName("BlazorModel")]
    public string BlazorModel;

    [JsonPropertyName("EFModel")]
    public string EFModel;

    [JsonPropertyName("EFModelBuilder")]
    public string EFModelBuilder;

    [JsonPropertyName("ModelDTO")]
    public string ModelDTO;

    [JsonPropertyName("ModelCsProj")]
    public string ModelCsProj;

    [JsonPropertyName("BusinessCsProj")]
    public string BusinessCsProj;

    [JsonPropertyName("DataProj")]
    public string DataProj;

    [JsonPropertyName("CopyClass")]
    public string CopyClass;

    [JsonPropertyName("GeneratedCs")]
    public string GeneratedCs;

    [JsonPropertyName("CMSModel")]
    public string CMSModel;

    [JsonPropertyName("CMSRepository")]
    public string CMSRepository;

    [JsonPropertyName("BackUps")]
    public string BackUps;

    [JsonPropertyName("BackUpsDirectory")]
    public string BackUpsDirectory;

    [JsonPropertyName("Product")]
    public string Product;

    [JsonPropertyName("StartTableList")]
    public string StartTableList;

    [JsonPropertyName("ApiAppSettingDEV")]
    public string ApiAppSettingDEV;

    [JsonPropertyName("ApiAppSettingTEST")]
    public string ApiAppSettingTEST;

    [JsonPropertyName("ApiAppSettingPROD")]
    public string ApiAppSettingPROD;

    [JsonPropertyName("TargetFrameworkMoniker")]
    public string TargetFrameworkMoniker;

    [JsonPropertyName("Debug.AspNetCompiler.VirtualPath")]
    public string DebugAspNetCompilerVirtualPath;

    [JsonPropertyName("Debug.AspNetCompiler.PhysicalPath")]
    public string DebugAspNetCompilerPhysicalPath;

    [JsonPropertyName("Debug.AspNetCompiler.TargetPath")]
    public string DebugAspNetCompilerTargetPath;

    [JsonPropertyName("Debug.AspNetCompiler.Updateable")]
    public string DebugAspNetCompilerUpdateable;

    [JsonPropertyName("Debug.AspNetCompiler.ForceOverwrite")]
    public string DebugAspNetCompilerForceOverwrite;

    [JsonPropertyName("Debug.AspNetCompiler.FixedNames")]
    public string DebugAspNetCompilerFixedNames;

    [JsonPropertyName("Debug.AspNetCompiler.Debug")]
    public string DebugAspNetCompilerDebug;

    [JsonPropertyName("Release.AspNetCompiler.VirtualPath")]
    public string ReleaseAspNetCompilerVirtualPath;

    [JsonPropertyName("Release.AspNetCompiler.PhysicalPath")]
    public string ReleaseAspNetCompilerPhysicalPath;

    [JsonPropertyName("Release.AspNetCompiler.TargetPath")]
    public string ReleaseAspNetCompilerTargetPath;

    [JsonPropertyName("Release.AspNetCompiler.Updateable")]
    public string ReleaseAspNetCompilerUpdateable;

    [JsonPropertyName("Release.AspNetCompiler.ForceOverwrite")]
    public string ReleaseAspNetCompilerForceOverwrite;

    [JsonPropertyName("Release.AspNetCompiler.FixedNames")]
    public string ReleaseAspNetCompilerFixedNames;

    [JsonPropertyName("Release.AspNetCompiler.Debug")]
    public string ReleaseAspNetCompilerDebug;

    [JsonPropertyName("VWDPort")]
    public string VWDPort;

    [JsonPropertyName("SlnRelativePath")]
    public string SlnRelativePath;

    [JsonPropertyName("DatabaseInfoPath")]
    public string DatabaseInfoPath;

    [JsonPropertyName("TwitterDatabase")]
    public string TwitterDatabase;

    [JsonPropertyName("ConsumerKey")]
    public string ConsumerKey;

    [JsonPropertyName("AccessToken")]
    public string AccessToken;

    [JsonPropertyName("ConsumerSecret")]
    public string ConsumerSecret;

    [JsonPropertyName("AccessTokenSecret")]
    public string AccessTokenSecret;

    [JsonPropertyName("SideBarInfo")]
    public string SideBarInfo;


    [JsonPropertyName("mobileUI")]
    public string MobileUI;


    [JsonPropertyName("mobileService")]
    public string MobileService;

    public string ReactNextRequestModel;
    public string ReactNextResponseModel { get; set; }
    public string ReactNextFunctionAxios { get; set; }
    public string ReactNextModel { get; set; }
    public string AdminUrl { get; set; }
    public string ApiUrl { get; set; }
    public string SettingUrl { get; set; }
    public string TableUrl { get; set; }
    public string React { get; set; }

    public string DynamicModel { get; set; }
    public string BlazorHeroApplication { get; set; }
    public string BlazorHeroClient { get; set; }
    public string BlazorHeroClientInfrastructure { get; set; }
    public string BlazorHeroDomain { get; set; }
    public string BlazorHeroInfrastructure { get; set; }
    public string BlazorHeroInfrastructureShared { get; set; }
    public string BlazorHeroServer { get; set; }
    public string BlazorHeroShared { get; set; }

    public string BlazorHeroPermission { get; set; }
    public string BlazorHeroPermissionTemplate { get; set; }


    public string BlazorHeroNavMenu { get; set; }
    public string BlazorHeroNavMenuTemplate { get; set; }

    public string BlazorHeroHostBuilderPath { get; set; }
    public string BlazorHeroDbContext { get; set; }
    public string BlazorHeroCMSModel { get; set; }
    public string BlazorHeroDataAbstractDapper { get; set; }
    public string BlazorHeroDataConcreteDapper { get; set; }
    public string BlazorHeroBusinessAbstractDapper { get; set; }
    public string BlazorHeroBusinessConcreteDapper { get; set; }

    public string BlazorOutput { get; set; }
    public string BlazorSourceTemplate { get; set; }
    public string BlazorTargetTemplate { get; set; }
    public string BlazorAppName { get; set; }

    public string AngularEnvironment { get; set; }
    public string AngularEnvironmentProd { get; set; }
    public string AngularEnvironmentProdCMS { get; set; }
    public string AngularEnvironmentCMS { get; set; }

    public string MongoModelFolder { get; set; }

    public string MongoModel { get; set; }

    public string MongoModeljs { get; set; }

    public List<string> CorsList { get; set; }
}


