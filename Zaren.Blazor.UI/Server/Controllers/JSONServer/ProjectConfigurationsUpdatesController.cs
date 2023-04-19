using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ZarenUI.Server.Controllers.JSONServer
{
    public partial class ProjectConfigurationsUpdatesController : ODataController
    {
        private ZarenUI.Server.Data.JSONServerContext context;

        public ProjectConfigurationsUpdatesController(ZarenUI.Server.Data.JSONServerContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
        [Route("odata/JSONServer/ProjectConfigurationsUpdatesFunc(Id={Id},Name={Name},ConfigurationJsonScheme={ConfigurationJsonScheme},NoteHistory={NoteHistory},Descriptions={Descriptions},CanOverRide={CanOverRide},HasNeedCompileOnChange={HasNeedCompileOnChange},CreatedById={CreatedById},SecurityConfiguration={SecurityConfiguration},LogConfiguration={LogConfiguration},CacheConfiguration={CacheConfiguration},DataBaseConfiguration={DataBaseConfiguration},NameSpaceConfiguration={NameSpaceConfiguration},ReactConfiguration={ReactConfiguration},AngularConfiguration={AngularConfiguration},NodeJsExpressConfiguration={NodeJsExpressConfiguration},NetCoreAPIConfiguration={NetCoreAPIConfiguration},IISConfiguration={IISConfiguration},HostingConfiguration={HostingConfiguration},BuildConfiguration={BuildConfiguration},BackUpConfiguration={BackUpConfiguration},DBJobConfiguration={DBJobConfiguration},DataTypeConfiguration={DataTypeConfiguration},FileManagementConfiguration={FileManagementConfiguration},DapperConfiguration={DapperConfiguration},RateLimitConfiguration={RateLimitConfiguration},TenantConfiguration={TenantConfiguration},TenantApiKeyConfiguration={TenantApiKeyConfiguration},TenantPriceConfiguration={TenantPriceConfiguration},NginxConfiguration={NginxConfiguration},LastValidDate={LastValidDate},CreatedDate={CreatedDate},PublishPathConfiguration={PublishPathConfiguration},FtpConfiguration={FtpConfiguration},BackgroundJobConfiguration={BackgroundJobConfiguration},WindowsServiceConfiguration={WindowsServiceConfiguration},ConsoleAppConfiguration={ConsoleAppConfiguration},WCFConfiguration={WCFConfiguration},TokenConfiguration={TokenConfiguration},PaymentConfiguration={PaymentConfiguration},PurchasedToolConfiguration={PurchasedToolConfiguration},TenantWhiteListConfiguration={TenantWhiteListConfiguration},HelpDocumentConfiguration={HelpDocumentConfiguration},HeaderConfiguration={HeaderConfiguration},RoleConfiguration={RoleConfiguration},MongoConfiguration={MongoConfiguration},MsSqlConfiguration={MsSqlConfiguration},MySqlConfiguration={MySqlConfiguration},ElasticSearchConfiguration={ElasticSearchConfiguration},TableConfiguration={TableConfiguration},ColumnConfiguration={ColumnConfiguration},FunctionConfiguration={FunctionConfiguration},InputConfiguration={InputConfiguration},CMSConfiguration={CMSConfiguration},ThemeConfiguration={ThemeConfiguration},SSLConfiguration={SSLConfiguration},SoftwareVersionConfiguration={SoftwareVersionConfiguration},ExceptionHandlingConfiguration={ExceptionHandlingConfiguration},JsonConfiguration={JsonConfiguration},XMLConfiguration={XMLConfiguration},SoftwareLanguageId={SoftwareLanguageId},CssConfiguration={CssConfiguration},HtmlConfiguration={HtmlConfiguration},TsConfiguration={TsConfiguration},PackageConfiguration={PackageConfiguration},TestConfiguration={TestConfiguration},DeviceConfiguration={DeviceConfiguration},RedisConfiguration={RedisConfiguration},FileOutputExtensionName={FileOutputExtensionName},ExportConfiguration={ExportConfiguration},MailConfiguration={MailConfiguration},ThirdPartyConfiguration={ThirdPartyConfiguration},DiagramConfiguration={DiagramConfiguration},PrismaConfiguration={PrismaConfiguration},BootStrapConfiguration={BootStrapConfiguration},LayoutConfiguration={LayoutConfiguration},ComponentConfiguration={ComponentConfiguration},FigmaConfigiration={FigmaConfigiration})")]
        public IActionResult ProjectConfigurationsUpdatesFunc([FromODataUri] int? Id, [FromODataUri] string Name, [FromODataUri] string ConfigurationJsonScheme, [FromODataUri] string NoteHistory, [FromODataUri] string Descriptions, [FromODataUri] bool? CanOverRide, [FromODataUri] string HasNeedCompileOnChange, [FromODataUri] int? CreatedById, [FromODataUri] string SecurityConfiguration, [FromODataUri] string LogConfiguration, [FromODataUri] string CacheConfiguration, [FromODataUri] string DataBaseConfiguration, [FromODataUri] string NameSpaceConfiguration, [FromODataUri] string ReactConfiguration, [FromODataUri] string AngularConfiguration, [FromODataUri] string NodeJsExpressConfiguration, [FromODataUri] string NetCoreAPIConfiguration, [FromODataUri] string IISConfiguration, [FromODataUri] string HostingConfiguration, [FromODataUri] string BuildConfiguration, [FromODataUri] string BackUpConfiguration, [FromODataUri] string DBJobConfiguration, [FromODataUri] string DataTypeConfiguration, [FromODataUri] string FileManagementConfiguration, [FromODataUri] string DapperConfiguration, [FromODataUri] string RateLimitConfiguration, [FromODataUri] string TenantConfiguration, [FromODataUri] string TenantApiKeyConfiguration, [FromODataUri] string TenantPriceConfiguration, [FromODataUri] string NginxConfiguration, [FromODataUri] string LastValidDate, [FromODataUri] string CreatedDate, [FromODataUri] string PublishPathConfiguration, [FromODataUri] string FtpConfiguration, [FromODataUri] string BackgroundJobConfiguration, [FromODataUri] string WindowsServiceConfiguration, [FromODataUri] string ConsoleAppConfiguration, [FromODataUri] string WCFConfiguration, [FromODataUri] string TokenConfiguration, [FromODataUri] string PaymentConfiguration, [FromODataUri] string PurchasedToolConfiguration, [FromODataUri] string TenantWhiteListConfiguration, [FromODataUri] string HelpDocumentConfiguration, [FromODataUri] string HeaderConfiguration, [FromODataUri] string RoleConfiguration, [FromODataUri] string MongoConfiguration, [FromODataUri] string MsSqlConfiguration, [FromODataUri] string MySqlConfiguration, [FromODataUri] string ElasticSearchConfiguration, [FromODataUri] string TableConfiguration, [FromODataUri] string ColumnConfiguration, [FromODataUri] string FunctionConfiguration, [FromODataUri] string InputConfiguration, [FromODataUri] string CMSConfiguration, [FromODataUri] string ThemeConfiguration, [FromODataUri] string SSLConfiguration, [FromODataUri] string SoftwareVersionConfiguration, [FromODataUri] string ExceptionHandlingConfiguration, [FromODataUri] string JsonConfiguration, [FromODataUri] string XMLConfiguration, [FromODataUri] int? SoftwareLanguageId, [FromODataUri] string CssConfiguration, [FromODataUri] string HtmlConfiguration, [FromODataUri] string TsConfiguration, [FromODataUri] string PackageConfiguration, [FromODataUri] string TestConfiguration, [FromODataUri] string DeviceConfiguration, [FromODataUri] string RedisConfiguration, [FromODataUri] string FileOutputExtensionName, [FromODataUri] string ExportConfiguration, [FromODataUri] string MailConfiguration, [FromODataUri] string ThirdPartyConfiguration, [FromODataUri] string DiagramConfiguration, [FromODataUri] string PrismaConfiguration, [FromODataUri] string BootStrapConfiguration, [FromODataUri] string LayoutConfiguration, [FromODataUri] string ComponentConfiguration, [FromODataUri] string FigmaConfigiration)
        {
            this.OnProjectConfigurationsUpdatesDefaultParams(ref Id, ref Name, ref ConfigurationJsonScheme, ref NoteHistory, ref Descriptions, ref CanOverRide, ref HasNeedCompileOnChange, ref CreatedById, ref SecurityConfiguration, ref LogConfiguration, ref CacheConfiguration, ref DataBaseConfiguration, ref NameSpaceConfiguration, ref ReactConfiguration, ref AngularConfiguration, ref NodeJsExpressConfiguration, ref NetCoreAPIConfiguration, ref IISConfiguration, ref HostingConfiguration, ref BuildConfiguration, ref BackUpConfiguration, ref DBJobConfiguration, ref DataTypeConfiguration, ref FileManagementConfiguration, ref DapperConfiguration, ref RateLimitConfiguration, ref TenantConfiguration, ref TenantApiKeyConfiguration, ref TenantPriceConfiguration, ref NginxConfiguration, ref LastValidDate, ref CreatedDate, ref PublishPathConfiguration, ref FtpConfiguration, ref BackgroundJobConfiguration, ref WindowsServiceConfiguration, ref ConsoleAppConfiguration, ref WCFConfiguration, ref TokenConfiguration, ref PaymentConfiguration, ref PurchasedToolConfiguration, ref TenantWhiteListConfiguration, ref HelpDocumentConfiguration, ref HeaderConfiguration, ref RoleConfiguration, ref MongoConfiguration, ref MsSqlConfiguration, ref MySqlConfiguration, ref ElasticSearchConfiguration, ref TableConfiguration, ref ColumnConfiguration, ref FunctionConfiguration, ref InputConfiguration, ref CMSConfiguration, ref ThemeConfiguration, ref SSLConfiguration, ref SoftwareVersionConfiguration, ref ExceptionHandlingConfiguration, ref JsonConfiguration, ref XMLConfiguration, ref SoftwareLanguageId, ref CssConfiguration, ref HtmlConfiguration, ref TsConfiguration, ref PackageConfiguration, ref TestConfiguration, ref DeviceConfiguration, ref RedisConfiguration, ref FileOutputExtensionName, ref ExportConfiguration, ref MailConfiguration, ref ThirdPartyConfiguration, ref DiagramConfiguration, ref PrismaConfiguration, ref BootStrapConfiguration, ref LayoutConfiguration, ref ComponentConfiguration, ref FigmaConfigiration);

            var items = this.context.ProjectConfigurationsUpdates.FromSqlRaw("EXEC [dbo].[ProjectConfigurationsUpdate] @Id={0}, @Name={1}, @ConfigurationJsonScheme={2}, @NoteHistory={3}, @Descriptions={4}, @CanOverRide={5}, @HasNeedCompileOnChange={6}, @CreatedById={7}, @SecurityConfiguration={8}, @LogConfiguration={9}, @CacheConfiguration={10}, @DataBaseConfiguration={11}, @NameSpaceConfiguration={12}, @ReactConfiguration={13}, @AngularConfiguration={14}, @NodeJsExpressConfiguration={15}, @NetCoreAPIConfiguration={16}, @IISConfiguration={17}, @HostingConfiguration={18}, @BuildConfiguration={19}, @BackUpConfiguration={20}, @DBJobConfiguration={21}, @DataTypeConfiguration={22}, @FileManagementConfiguration={23}, @DapperConfiguration={24}, @RateLimitConfiguration={25}, @TenantConfiguration={26}, @TenantApiKeyConfiguration={27}, @TenantPriceConfiguration={28}, @NginxConfiguration={29}, @LastValidDate={30}, @CreatedDate={31}, @PublishPathConfiguration={32}, @FtpConfiguration={33}, @BackgroundJobConfiguration={34}, @WindowsServiceConfiguration={35}, @ConsoleAppConfiguration={36}, @WCFConfiguration={37}, @TokenConfiguration={38}, @PaymentConfiguration={39}, @PurchasedToolConfiguration={40}, @TenantWhiteListConfiguration={41}, @HelpDocumentConfiguration={42}, @HeaderConfiguration={43}, @RoleConfiguration={44}, @MongoConfiguration={45}, @MsSqlConfiguration={46}, @MySqlConfiguration={47}, @ElasticSearchConfiguration={48}, @TableConfiguration={49}, @ColumnConfiguration={50}, @FunctionConfiguration={51}, @InputConfiguration={52}, @CMSConfiguration={53}, @ThemeConfiguration={54}, @SSLConfiguration={55}, @SoftwareVersionConfiguration={56}, @ExceptionHandlingConfiguration={57}, @JsonConfiguration={58}, @XMLConfiguration={59}, @SoftwareLanguageId={60}, @CssConfiguration={61}, @HtmlConfiguration={62}, @TsConfiguration={63}, @PackageConfiguration={64}, @TestConfiguration={65}, @DeviceConfiguration={66}, @RedisConfiguration={67}, @FileOutputExtensionName={68}, @ExportConfiguration={69}, @MailConfiguration={70}, @ThirdPartyConfiguration={71}, @DiagramConfiguration={72}, @PrismaConfiguration={73}, @BootStrapConfiguration={74}, @LayoutConfiguration={75}, @ComponentConfiguration={76}, @FigmaConfigiration={77}", Id, Name, ConfigurationJsonScheme, NoteHistory, Descriptions, CanOverRide, HasNeedCompileOnChange, CreatedById, SecurityConfiguration, LogConfiguration, CacheConfiguration, DataBaseConfiguration, NameSpaceConfiguration, ReactConfiguration, AngularConfiguration, NodeJsExpressConfiguration, NetCoreAPIConfiguration, IISConfiguration, HostingConfiguration, BuildConfiguration, BackUpConfiguration, DBJobConfiguration, DataTypeConfiguration, FileManagementConfiguration, DapperConfiguration, RateLimitConfiguration, TenantConfiguration, TenantApiKeyConfiguration, TenantPriceConfiguration, NginxConfiguration, LastValidDate, CreatedDate, PublishPathConfiguration, FtpConfiguration, BackgroundJobConfiguration, WindowsServiceConfiguration, ConsoleAppConfiguration, WCFConfiguration, TokenConfiguration, PaymentConfiguration, PurchasedToolConfiguration, TenantWhiteListConfiguration, HelpDocumentConfiguration, HeaderConfiguration, RoleConfiguration, MongoConfiguration, MsSqlConfiguration, MySqlConfiguration, ElasticSearchConfiguration, TableConfiguration, ColumnConfiguration, FunctionConfiguration, InputConfiguration, CMSConfiguration, ThemeConfiguration, SSLConfiguration, SoftwareVersionConfiguration, ExceptionHandlingConfiguration, JsonConfiguration, XMLConfiguration, SoftwareLanguageId, CssConfiguration, HtmlConfiguration, TsConfiguration, PackageConfiguration, TestConfiguration, DeviceConfiguration, RedisConfiguration, FileOutputExtensionName, ExportConfiguration, MailConfiguration, ThirdPartyConfiguration, DiagramConfiguration, PrismaConfiguration, BootStrapConfiguration, LayoutConfiguration, ComponentConfiguration, FigmaConfigiration).ToList().AsQueryable();

            this.OnProjectConfigurationsUpdatesInvoke(ref items);

            return Ok(items);
        }

        partial void OnProjectConfigurationsUpdatesDefaultParams(ref int? Id, ref string Name, ref string ConfigurationJsonScheme, ref string NoteHistory, ref string Descriptions, ref bool? CanOverRide, ref string HasNeedCompileOnChange, ref int? CreatedById, ref string SecurityConfiguration, ref string LogConfiguration, ref string CacheConfiguration, ref string DataBaseConfiguration, ref string NameSpaceConfiguration, ref string ReactConfiguration, ref string AngularConfiguration, ref string NodeJsExpressConfiguration, ref string NetCoreAPIConfiguration, ref string IISConfiguration, ref string HostingConfiguration, ref string BuildConfiguration, ref string BackUpConfiguration, ref string DBJobConfiguration, ref string DataTypeConfiguration, ref string FileManagementConfiguration, ref string DapperConfiguration, ref string RateLimitConfiguration, ref string TenantConfiguration, ref string TenantApiKeyConfiguration, ref string TenantPriceConfiguration, ref string NginxConfiguration, ref string LastValidDate, ref string CreatedDate, ref string PublishPathConfiguration, ref string FtpConfiguration, ref string BackgroundJobConfiguration, ref string WindowsServiceConfiguration, ref string ConsoleAppConfiguration, ref string WCFConfiguration, ref string TokenConfiguration, ref string PaymentConfiguration, ref string PurchasedToolConfiguration, ref string TenantWhiteListConfiguration, ref string HelpDocumentConfiguration, ref string HeaderConfiguration, ref string RoleConfiguration, ref string MongoConfiguration, ref string MsSqlConfiguration, ref string MySqlConfiguration, ref string ElasticSearchConfiguration, ref string TableConfiguration, ref string ColumnConfiguration, ref string FunctionConfiguration, ref string InputConfiguration, ref string CMSConfiguration, ref string ThemeConfiguration, ref string SSLConfiguration, ref string SoftwareVersionConfiguration, ref string ExceptionHandlingConfiguration, ref string JsonConfiguration, ref string XMLConfiguration, ref int? SoftwareLanguageId, ref string CssConfiguration, ref string HtmlConfiguration, ref string TsConfiguration, ref string PackageConfiguration, ref string TestConfiguration, ref string DeviceConfiguration, ref string RedisConfiguration, ref string FileOutputExtensionName, ref string ExportConfiguration, ref string MailConfiguration, ref string ThirdPartyConfiguration, ref string DiagramConfiguration, ref string PrismaConfiguration, ref string BootStrapConfiguration, ref string LayoutConfiguration, ref string ComponentConfiguration, ref string FigmaConfigiration);

        partial void OnProjectConfigurationsUpdatesInvoke(ref IQueryable<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsUpdate> items);
    }
}