using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectConfigurationsGetByReactConfiguration
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ConfigurationJsonScheme { get; set; }

        public string NoteHistory { get; set; }

        public string Descriptions { get; set; }

        public bool? CanOverRide { get; set; }

        public string HasNeedCompileOnChange { get; set; }

        public int? CreatedById { get; set; }

        public string SecurityConfiguration { get; set; }

        public string LogConfiguration { get; set; }

        public string CacheConfiguration { get; set; }

        public string DataBaseConfiguration { get; set; }

        public string NameSpaceConfiguration { get; set; }

        public string ReactConfiguration { get; set; }

        public string AngularConfiguration { get; set; }

        public string NodeJsExpressConfiguration { get; set; }

        public string NetCoreAPIConfiguration { get; set; }

        public string IISConfiguration { get; set; }

        public string HostingConfiguration { get; set; }

        public string BuildConfiguration { get; set; }

        public string BackUpConfiguration { get; set; }

        public string DBJobConfiguration { get; set; }

        public string DataTypeConfiguration { get; set; }

        public string FileManagementConfiguration { get; set; }

        public string DapperConfiguration { get; set; }

        public string RateLimitConfiguration { get; set; }

        public string TenantConfiguration { get; set; }

        public string TenantApiKeyConfiguration { get; set; }

        public string TenantPriceConfiguration { get; set; }

        public string NginxConfiguration { get; set; }

        public DateTime? LastValidDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string PublishPathConfiguration { get; set; }

        public string FtpConfiguration { get; set; }

        public string BackgroundJobConfiguration { get; set; }

        public string WindowsServiceConfiguration { get; set; }

        public string ConsoleAppConfiguration { get; set; }

        public string WCFConfiguration { get; set; }

        public string TokenConfiguration { get; set; }

        public string PaymentConfiguration { get; set; }

        public string PurchasedToolConfiguration { get; set; }

        public string TenantWhiteListConfiguration { get; set; }

        public string HelpDocumentConfiguration { get; set; }

        public string HeaderConfiguration { get; set; }

        public string RoleConfiguration { get; set; }

        public string MongoConfiguration { get; set; }

        public string MsSqlConfiguration { get; set; }

        public string MySqlConfiguration { get; set; }

        public string ElasticSearchConfiguration { get; set; }

        public string TableConfiguration { get; set; }

        public string ColumnConfiguration { get; set; }

        public string FunctionConfiguration { get; set; }

        public string InputConfiguration { get; set; }

        public string CMSConfiguration { get; set; }

        public string ThemeConfiguration { get; set; }

        public string SSLConfiguration { get; set; }

        public string SoftwareVersionConfiguration { get; set; }

        public string ExceptionHandlingConfiguration { get; set; }

        public string JsonConfiguration { get; set; }

        public string XMLConfiguration { get; set; }

        public int? SoftwareLanguageId { get; set; }

        public string CssConfiguration { get; set; }

        public string HtmlConfiguration { get; set; }

        public string TsConfiguration { get; set; }

        public string PackageConfiguration { get; set; }

        public string TestConfiguration { get; set; }

        public string DeviceConfiguration { get; set; }

        public string RedisConfiguration { get; set; }

        public string FileOutputExtensionName { get; set; }

        public string ExportConfiguration { get; set; }

        public string MailConfiguration { get; set; }

        public string ThirdPartyConfiguration { get; set; }

        public string DiagramConfiguration { get; set; }

        public string PrismaConfiguration { get; set; }

        public string BootStrapConfiguration { get; set; }

        public string LayoutConfiguration { get; set; }

        public string ComponentConfiguration { get; set; }

        public string FigmaConfigiration { get; set; }

    }
}