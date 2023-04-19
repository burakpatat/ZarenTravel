using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ZarenUI.Server.Models.JSONServer;

namespace ZarenUI.Server.Data
{
    public partial class JSONServerContext : DbContext
    {
        public JSONServerContext()
        {
        }

        public JSONServerContext(DbContextOptions<JSONServerContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByBrightnessValue>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByGroupList>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByHexCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByIsDark>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByPossibleName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByRgbCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ColorGroupsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByAddWithCheck>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByAddWithNoCheck>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByCheckConstraint>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByColumnId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByComment>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByProjectId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByProjectName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByTableId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByTableName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ConstraintRulesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByAbbreviation>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByArea>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByBarcode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByCallingCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByCity>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByContinent>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByCostLine>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByCurrencyCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByCurrencyName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByDefaultLanguageId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByDensity>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByDish>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByDomainTld>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByEast>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByElevation>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByExpectancy>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByFlagBase64>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByGovernment>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByHeight>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByIndependence>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByIso>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByLandlocked>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByLanguagesJson>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByLocation>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByNorth>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByPopulation>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByReligion>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByShortName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetBySouth>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetBySymbol>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByTemperature>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryGetByWest>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryLanguagesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByCountryId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByCountryName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByLanguageName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryLanguagesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryLanguagesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.CountryUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignSchemesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignSchemesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyBackground>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFont>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFontColor>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFontSize>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Brightness>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Isdark>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Rgb>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Brightness>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Hex>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Isdark>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Rgb>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Brightness>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Hex>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Isdark>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Rgb>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Brightness>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Hex>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Isdark>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Rgb>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Brightness>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Hex>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Isdark>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Rgb>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentBackground>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentBorderColor>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentMargin>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentPadding>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentTextColor>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterBackground>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterFontSize>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterMargin>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterPadding>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsGroup>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderBackground>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderFontSize>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderMargin>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderPadding>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuBackground>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuFontSize>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuMargin>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuPadding>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperBackground>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperFontSize>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperMargin>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperPadding>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperWidth>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignSchemesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignSchemesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DesignSchemesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DeviceGroupsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DeviceGroupsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DeviceGroupsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DeviceGroupsGetByName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DeviceGroupsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DeviceGroupsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByBrand>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByDeviceGroupId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByDeviceName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByHeight>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByImg>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByIsLandScape>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation1x>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation2x>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation3x>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesGetByWidth>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DevicesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicJson>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicQuery>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicQueueList>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicSpaceReport>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.Dynamicstatistic>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTable>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTableCount>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTableForeignKey>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTablePager>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTableReport>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTableRow>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTableSearch>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTableSearchAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTableSearchTable>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicTransactionReport>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicUpsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicViewDto>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.DynamicViewReport>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByColumnName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByComment>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByConstraintRule>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByDbType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByDefaultValue>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByIsNullable>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByIsPrimary>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByMaxLength>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByPrimitiveType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByProjectId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByProjectName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByTableId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsGetByTableName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.FieldsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByColumnId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByColumnName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByConstraintId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByDeleteRule>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByProjectId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByProjectName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByReferencedColumnDbTypeCompare>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByReferencedColumnName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByReferencedTableName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByTableId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByTableName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByUpdateRule>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetAccessControl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetAny>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetColumn>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetColumnsWithOutIdentity>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetDependency>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetExtended>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetExtendedInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetExtendedRemove>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetGroupBy>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetIdentityList>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetIndexStat>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetModifyDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetPager>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetParameterName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetProcedureName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetRequestParameterName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetReturnParameterName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetSearchWithList>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetServerInfo>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetSpLog>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetStoredProceduresForATable>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetTableColumn>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetTableFk>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetTableInfo>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetTableName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetTable>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetTableSize>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetViewBackupHistory>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.GetViewList>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryGetByTypeName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByExampleCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByLanguageType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByTargetLanguageCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByTargetLanguageType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByProgrammingLanguage>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByReplacedField>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByTemplate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetByCodeFamilyName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetByCodeType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetByIde>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetByCategoryName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetByCategoryNameTr>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetByParentId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetBySampleUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectCategoryUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKey>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationValue>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationValueType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByParentConfigurationKeyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByAngularConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBackgroundJobConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBackUpConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBootStrapConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBuildConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCacheConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCanOverRide>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCmsConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByColumnConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByComponentConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByConfigurationJsonScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByConsoleAppConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCreatedById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCssConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDapperConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDataBaseConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDataTypeConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDbJobConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDescription>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDeviceConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDiagramConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByElasticSearchConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByExceptionHandlingConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByExportConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFigmaConfigiration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFileManagementConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFileOutputExtensionName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFtpConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFunctionConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHasNeedCompileOnChange>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHeaderConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHelpDocumentConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHostingConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHtmlConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByIısConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByInputConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByJsonConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByLastValidDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByLayoutConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByLogConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMailConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMongoConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMsSqlConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMySqlConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNameSpaceConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNetCoreApıConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNginxConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNodeJsExpressConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNoteHistory>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPackageConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPaymentConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPrismaConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPublishPathConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPurchasedToolConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRateLimitConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByReactConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRedisConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRoleConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySecurityConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySoftwareLanguageId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySoftwareVersionConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySslConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTableConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantApiKeyConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantPriceConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantWhiteListConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTestConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByThemeConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByThirdPartyConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTokenConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTsConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByWcfConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByWindowsServiceConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByXmlConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetLastValidDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponse>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCommission>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByFunctionGroupName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByPrice>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetBySoftWareLanguageId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByAcceptableQuerystring>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByAccessModifierId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByApiMethodComment>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCacheDbConnection>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCacheType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCommission>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCrudType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCustomCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByDatabaseTypesId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByDocumentUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByEventType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByExampleRequest>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByExampleResponse>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionCallRankInGroup>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionGroupId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionIsParentInGroup>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasAsync>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasAuditEvent>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasBusEvent>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasCacheMethod>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasRateLimit>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHeaderScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByi18Json>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByIsDeleted>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByLastScanDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByLogCodeMergeDateDbConnection>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByLogCodeMergeDateDbType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByNameSpaceList>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByPrice>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByPublishedDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByQuery>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRateLimitProperty>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRequestScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseHasMultiModel>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseHasReturnValue>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRoute>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetBySoftwareLanguageId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByStatu>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetBySuccessNotificationTemplate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserAgent>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserConnectionsId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserDescriptionForMethod>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogAllRequest>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogAllResponse>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogCodeMergeDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithHeader>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithMethod>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithOrigin>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetLastScanDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetPublishedDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectFunctionsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByApiRequestUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByBusEventConnectionId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCacheDbConnection>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCacheType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComment>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCommission>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentCallRankInGroup>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentGroupId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentIsParentInGroup>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCrudType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomAnimationScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomCss>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomScript>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByDatabaseTypesId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByDocumentUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByEventType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByExampleHtmlCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByExampleRequest>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByExampleResponse>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTrigger>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerGroupId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerRank>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasAsync>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasBusEvent>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasCacheMethod>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasCodeBuild>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByi18Json>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByIsDeleted>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLastScanDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLogCodeMergeDateDbConnection>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLogCodeMergeDateDbType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByNameSpaceList>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPreviewCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPreviewUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPrice>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPublishedDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByQuery>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByRequestHeader>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByRequestScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByResponseHasMultiModel>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByResponseHasReturnValue>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByResponseScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetBySoftwareLanguageId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByStatu>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetBySuccessNotificationTemplate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByUserAgent>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByUserDescriptionForComponent>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByUserId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWebSitePageComponentsId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogAllRequest>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogAllResponse>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogCodeMergeDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWithHeader>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWithMethod>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWithOrigin>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetLastScanDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetPublishedDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByApiRequestUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCommission>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByComponentName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCrudType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByDatabaseId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByDefaultLanguage>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByFormActionUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByHasFinishedSuccessfully>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByHasForm>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByHasMultiLanguage>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByLastScanDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByLastValidDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByModifyDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByOnHover>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByParentWebSitePartsId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByPrice>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByQuery>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByRequestScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByResponseScheme>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByScannedLanguage>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByUserAgent>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByUserId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByWebSitePagesId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetLastScanDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetLastValidDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetModifyDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCommission>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCssCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCustomCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByDefaultLanguage>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasFinishedSuccessfully>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasMultipleLanguage>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasPaid>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHtmlCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByJsCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByJsonCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByLastScanDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageCycleEventDefination>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageCycleEventDefination1>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPrice>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByProjectId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByReferralUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByRoute>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByScannedLanguage>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByUserId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesGetLastScanDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectPagesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByConnectionSetting>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByDatabaseSchema>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByEndpoint>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByEnumList>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByGuid>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByLanguageDefination>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByLookup>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByRuleGroup>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByTableGroup>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByTable>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsGetByUserId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsCreatePageConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsDeletePageConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsEditPageConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsListPageConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnNameCrypto>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnNameI18>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnsConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByComment>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCommission>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByComponentConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCustomCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDatabaseCreateMigrationScript>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDataTypeMapping>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDbType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDefaultValue>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDependencyConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByExtra>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByFkDetail>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByInputType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByIsNullable>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByIsPrimary>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByKeyConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByMappingConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByMaxLength>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByPrice>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByPrimitiveType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByTableId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByTableName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByApiConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByAuditConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsCustomFilterConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsExportConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsMenuConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsPermissionConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsRouteConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByColumn>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByComment>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCommission>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCustomCode>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByDataIndex>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByDiagramConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByI18Configuration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByPrice>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProgrammingLanguageId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProjectName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProjectTableConfiguration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByTableName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByTableNameCrypto>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByUniqueColumn>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByUserProjectConnection>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ProjectTablesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByAvgVisitDuration>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByBounceRate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCommission>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCreatedDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCurrencyId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByDefaultLanguage>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByGuid>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByIsLastPublishSuccessfully>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByLastCompileDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByLogo>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByModifyDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByPageVisit>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByPrice>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByProjectCategoryId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByRanking>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetBySiteName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetBySoftwareLanguageId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByUrl>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByUserId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByValidDate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetCreatedDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetLastCompileDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetModifyDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetValidDateBetween>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SchemesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SchemesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SchemesGetByDatabaseType>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SchemesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SchemesGetByName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SchemesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SchemesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpColumn>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpDatatypeInfo>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpDbmmonitoraddmonitoring>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpDbmmonitorhelpalert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpDbmmonitorresult>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpDbmmonitorupdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpDroplogin>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpHelpDatatypeMapping>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpKillOldestTransactionOnSecondaryResult>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpMonitor>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.SpMsgetalertinfo>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.TablesDelete>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.TablesGetAll>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.TablesGetById>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.TablesGetByProjectId>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.TablesGetByTableName>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.TablesInsert>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.TablesUpdate>().HasNoKey();

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditColorGroup>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditConstraintRule>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditCountry>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditCountryLanguage>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditDesignScheme>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditDeviceGroup>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditDevice>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditField>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProgrammingCode>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectCategory>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectFunction>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectPage>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProject>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditProjectTable>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditScheme>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");

            builder.Entity<ZarenUI.Server.Models.JSONServer.AuditTable>()
              .Property(p => p.EventDate)
              .HasDefaultValueSql(@"(getdate())");
            this.OnModelBuilding(builder);
        }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditColorGroup> AuditColorGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditConstraintRule> AuditConstraintRules { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditCountry> AuditCountries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditCountryLanguage> AuditCountryLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditDesignScheme> AuditDesignSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditDeviceGroup> AuditDeviceGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditDevice> AuditDevices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditField> AuditFields { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditForeignKeyRule> AuditForeignKeyRules { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProgrammingCategory> AuditProgrammingCategories { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProgrammingCode> AuditProgrammingCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProgrammingCodeTemplate> AuditProgrammingCodeTemplates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProgrammingTechnology> AuditProgrammingTechnologies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectCategory> AuditProjectCategories { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectConfigurationKeyAndValue> AuditProjectConfigurationKeyAndValues { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectConfiguration> AuditProjectConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectFunctionGroup> AuditProjectFunctionGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectFunction> AuditProjectFunctions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponentElement> AuditProjectPageComponentElements { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectPageComponent> AuditProjectPageComponents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectPage> AuditProjectPages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProject> AuditProjects { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectTableColumn> AuditProjectTableColumns { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditProjectTable> AuditProjectTables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditReferenceWebSite> AuditReferenceWebSites { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditScheme> AuditSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.AuditTable> AuditTables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroup> ColorGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRule> ConstraintRules { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.Country> Countries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguage> CountryLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DeviceGroup> DeviceGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.Device> Devices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DistributedServerCache> DistributedServerCaches { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.Field> Fields { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRule> ForeignKeyRules { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCategory> ProgrammingCategories { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCode> ProgrammingCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplate> ProgrammingCodeTemplates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategory> ProjectCategories { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValue> ProjectConfigurationKeyAndValues { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfiguration> ProjectConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroup> ProjectFunctionGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunction> ProjectFunctions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElement> ProjectPageComponentElements { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponent> ProjectPageComponents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPage> ProjectPages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.Project> Projects { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumn> ProjectTableColumns { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTable> ProjectTables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSite> ReferenceWebSites { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.Scheme> Schemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.Table> Tables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignScheme> DesignSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsDelete> ColorGroupsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsGetAll> ColorGroupsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByBrightnessValue> ColorGroupsGetByBrightnessValues { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByGroupList> ColorGroupsGetByGroupLists { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByHexCode> ColorGroupsGetByHexCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsGetById> ColorGroupsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByIsDark> ColorGroupsGetByIsDarks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByPossibleName> ColorGroupsGetByPossibleNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsGetByRgbCode> ColorGroupsGetByRgbCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsInsert> ColorGroupsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ColorGroupsUpdate> ColorGroupsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesDelete> ConstraintRulesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetAll> ConstraintRulesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByAddWithCheck> ConstraintRulesGetByAddWithChecks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByAddWithNoCheck> ConstraintRulesGetByAddWithNoChecks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByCheckConstraint> ConstraintRulesGetByCheckConstraints { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByColumnId> ConstraintRulesGetByColumnIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByComment> ConstraintRulesGetByComments { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetById> ConstraintRulesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByName> ConstraintRulesGetByNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByProjectId> ConstraintRulesGetByProjectIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByProjectName> ConstraintRulesGetByProjectNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByTableId> ConstraintRulesGetByTableIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesGetByTableName> ConstraintRulesGetByTableNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesInsert> ConstraintRulesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ConstraintRulesUpdate> ConstraintRulesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryDelete> CountryDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetAll> CountryGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByAbbreviation> CountryGetByAbbreviations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByArea> CountryGetByAreas { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByBarcode> CountryGetByBarcodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByCallingCode> CountryGetByCallingCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByCity> CountryGetByCities { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByContinent> CountryGetByContinents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByCostLine> CountryGetByCostLines { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByCurrencyCode> CountryGetByCurrencyCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByCurrencyName> CountryGetByCurrencyNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByDefaultLanguageId> CountryGetByDefaultLanguageIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByDensity> CountryGetByDensities { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByDish> CountryGetByDishes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByDomainTld> CountryGetByDomainTlds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByEast> CountryGetByEasts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByElevation> CountryGetByElevations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByExpectancy> CountryGetByExpectancies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByFlagBase64> CountryGetByFlagBase64S { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByGovernment> CountryGetByGovernments { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByHeight> CountryGetByHeights { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetById> CountryGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByIndependence> CountryGetByIndependences { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByIso> CountryGetByIsos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByLandlocked> CountryGetByLandlockeds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByLanguagesJson> CountryGetByLanguagesJsons { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByLocation> CountryGetByLocations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByName> CountryGetByNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByNorth> CountryGetByNorths { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByPopulation> CountryGetByPopulations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByReligion> CountryGetByReligions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByShortName> CountryGetByShortNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetBySouth> CountryGetBySouths { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetBySymbol> CountryGetBySymbols { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByTemperature> CountryGetByTemperatures { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryGetByWest> CountryGetByWests { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryInsert> CountryInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguagesDelete> CountryLanguagesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetAll> CountryLanguagesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByCountryId> CountryLanguagesGetByCountryIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByCountryName> CountryLanguagesGetByCountryNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetById> CountryLanguagesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguagesGetByLanguageName> CountryLanguagesGetByLanguageNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguagesInsert> CountryLanguagesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryLanguagesUpdate> CountryLanguagesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.CountryUpdate> CountryUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignSchemesDelete> DesignSchemesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignSchemesGetAll> DesignSchemesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyBackground> DesignschemesgetbycolorsBodyBackgrounds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFont> DesignschemesgetbycolorsBodyFonts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFontColor> DesignschemesgetbycolorsBodyFontColors { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsBodyFontSize> DesignschemesgetbycolorsBodyFontSizes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Brightness> DesignschemesgetbycolorsColor1Brightnesses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Isdark> DesignschemesgetbycolorsColor1Isdarks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor1Rgb> DesignschemesgetbycolorsColor1Rgbs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Brightness> DesignschemesgetbycolorsColor2Brightnesses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Hex> DesignschemesgetbycolorsColor2Hexes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Isdark> DesignschemesgetbycolorsColor2Isdarks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor2Rgb> DesignschemesgetbycolorsColor2Rgbs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Brightness> DesignschemesgetbycolorsColor3Brightnesses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Hex> DesignschemesgetbycolorsColor3Hexes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Isdark> DesignschemesgetbycolorsColor3Isdarks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor3Rgb> DesignschemesgetbycolorsColor3Rgbs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Brightness> DesignschemesgetbycolorsColor4Brightnesses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Hex> DesignschemesgetbycolorsColor4Hexes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Isdark> DesignschemesgetbycolorsColor4Isdarks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor4Rgb> DesignschemesgetbycolorsColor4Rgbs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Brightness> DesignschemesgetbycolorsColor5Brightnesses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Hex> DesignschemesgetbycolorsColor5Hexes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Isdark> DesignschemesgetbycolorsColor5Isdarks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsColor5Rgb> DesignschemesgetbycolorsColor5Rgbs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentBackground> DesignschemesgetbycolorsContentBackgrounds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentBorderColor> DesignschemesgetbycolorsContentBorderColors { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentMargin> DesignschemesgetbycolorsContentMargins { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentPadding> DesignschemesgetbycolorsContentPaddings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsContentTextColor> DesignschemesgetbycolorsContentTextColors { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterBackground> DesignschemesgetbycolorsFooterBackgrounds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterFontSize> DesignschemesgetbycolorsFooterFontSizes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterMargin> DesignschemesgetbycolorsFooterMargins { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsFooterPadding> DesignschemesgetbycolorsFooterPaddings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsGroup> DesignschemesgetbycolorsGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderBackground> DesignschemesgetbycolorsHeaderBackgrounds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderFontSize> DesignschemesgetbycolorsHeaderFontSizes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderMargin> DesignschemesgetbycolorsHeaderMargins { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsHeaderPadding> DesignschemesgetbycolorsHeaderPaddings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuBackground> DesignschemesgetbycolorsMenuBackgrounds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuFontSize> DesignschemesgetbycolorsMenuFontSizes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuMargin> DesignschemesgetbycolorsMenuMargins { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsMenuPadding> DesignschemesgetbycolorsMenuPaddings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperBackground> DesignschemesgetbycolorsWrapperBackgrounds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperFontSize> DesignschemesgetbycolorsWrapperFontSizes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperMargin> DesignschemesgetbycolorsWrapperMargins { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperPadding> DesignschemesgetbycolorsWrapperPaddings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignschemesgetbycolorsWrapperWidth> DesignschemesgetbycolorsWrapperWidths { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignSchemesGetById> DesignSchemesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignSchemesInsert> DesignSchemesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DesignSchemesUpdate> DesignSchemesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DeviceGroupsDelete> DeviceGroupsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DeviceGroupsGetAll> DeviceGroupsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DeviceGroupsGetById> DeviceGroupsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DeviceGroupsGetByName> DeviceGroupsGetByNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DeviceGroupsInsert> DeviceGroupsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DeviceGroupsUpdate> DeviceGroupsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesDelete> DevicesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetAll> DevicesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByBrand> DevicesGetByBrands { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByDeviceGroupId> DevicesGetByDeviceGroupIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByDeviceName> DevicesGetByDeviceNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByHeight> DevicesGetByHeights { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetById> DevicesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByImg> DevicesGetByImgs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByIsLandScape> DevicesGetByIsLandScapes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation1x> DevicesGetByResulation1xes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation2x> DevicesGetByResulation2xes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByResulation3x> DevicesGetByResulation3xes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesGetByWidth> DevicesGetByWidths { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesInsert> DevicesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DevicesUpdate> DevicesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicJson> DynamicJsons { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicQuery> DynamicQueries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicQueueList> DynamicQueueLists { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicSpaceReport> DynamicSpaceReports { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.Dynamicstatistic> Dynamicstatistics { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTable> DynamicTables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTableCount> DynamicTableCounts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTableForeignKey> DynamicTableForeignKeys { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTablePager> DynamicTablePagers { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTableReport> DynamicTableReports { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTableRow> DynamicTableRows { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTableSearch> DynamicTableSearches { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTableSearchAll> DynamicTableSearchAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTableSearchTable> DynamicTableSearchTables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicTransactionReport> DynamicTransactionReports { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicUpsert> DynamicUpserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicViewDto> DynamicViewDtos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.DynamicViewReport> DynamicViewReports { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsDelete> FieldsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetAll> FieldsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByColumnName> FieldsGetByColumnNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByComment> FieldsGetByComments { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByConstraintRule> FieldsGetByConstraintRules { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByDbType> FieldsGetByDbTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByDefaultValue> FieldsGetByDefaultValues { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetById> FieldsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByIsNullable> FieldsGetByIsNullables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByIsPrimary> FieldsGetByIsPrimaries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByMaxLength> FieldsGetByMaxLengths { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByPrimitiveType> FieldsGetByPrimitiveTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByProjectId> FieldsGetByProjectIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByProjectName> FieldsGetByProjectNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByTableId> FieldsGetByTableIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsGetByTableName> FieldsGetByTableNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsInsert> FieldsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.FieldsUpdate> FieldsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesDelete> ForeignKeyRulesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetAll> ForeignKeyRulesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByColumnId> ForeignKeyRulesGetByColumnIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByColumnName> ForeignKeyRulesGetByColumnNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByConstraintId> ForeignKeyRulesGetByConstraintIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByDeleteRule> ForeignKeyRulesGetByDeleteRules { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetById> ForeignKeyRulesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByProjectId> ForeignKeyRulesGetByProjectIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByProjectName> ForeignKeyRulesGetByProjectNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByReferencedColumnDbTypeCompare> ForeignKeyRulesGetByReferencedColumnDbTypeCompares { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByReferencedColumnName> ForeignKeyRulesGetByReferencedColumnNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByReferencedTableName> ForeignKeyRulesGetByReferencedTableNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByTableId> ForeignKeyRulesGetByTableIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByTableName> ForeignKeyRulesGetByTableNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesGetByUpdateRule> ForeignKeyRulesGetByUpdateRules { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesInsert> ForeignKeyRulesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ForeignKeyRulesUpdate> ForeignKeyRulesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetAccessControl> GetAccessControls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetAny> GetAnies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetColumn> GetColumns { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetColumnsWithOutIdentity> GetColumnsWithOutIdentities { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetDependency> GetDependencies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetExtended> GetExtendeds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetExtendedInsert> GetExtendedInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetExtendedRemove> GetExtendedRemoves { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetGroupBy> GetGroupBies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetIdentityList> GetIdentityLists { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetIndexStat> GetIndexStats { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetModifyDate> GetModifyDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetPager> GetPagers { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetParameterName> GetParameterNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetProcedureName> GetProcedureNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetRequestParameterName> GetRequestParameterNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetReturnParameterName> GetReturnParameterNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetSearchWithList> GetSearchWithLists { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetServerInfo> GetServerInfos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetSpLog> GetSpLogs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetStoredProceduresForATable> GetStoredProceduresForATables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetTableColumn> GetTableColumns { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetTableFk> GetTableFks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetTableInfo> GetTableInfos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetTableName> GetTableNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetTable> GetTables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetTableSize> GetTableSizes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetViewBackupHistory> GetViewBackupHistories { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.GetViewList> GetViewLists { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryDelete> ProgrammingCategoryDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryGetAll> ProgrammingCategoryGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryGetById> ProgrammingCategoryGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryGetByTypeName> ProgrammingCategoryGetByTypeNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryInsert> ProgrammingCategoryInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCategoryUpdate> ProgrammingCategoryUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesDelete> ProgrammingCodesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetAll> ProgrammingCodesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByCode> ProgrammingCodesGetByCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByExampleCode> ProgrammingCodesGetByExampleCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetById> ProgrammingCodesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByLanguageType> ProgrammingCodesGetByLanguageTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByTargetLanguageCode> ProgrammingCodesGetByTargetLanguageCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesGetByTargetLanguageType> ProgrammingCodesGetByTargetLanguageTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesInsert> ProgrammingCodesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodesUpdate> ProgrammingCodesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesDelete> ProgrammingCodeTemplatesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetAll> ProgrammingCodeTemplatesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetById> ProgrammingCodeTemplatesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByProgrammingLanguage> ProgrammingCodeTemplatesGetByProgrammingLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByReplacedField> ProgrammingCodeTemplatesGetByReplacedFields { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesGetByTemplate> ProgrammingCodeTemplatesGetByTemplates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesInsert> ProgrammingCodeTemplatesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingCodeTemplatesUpdate> ProgrammingCodeTemplatesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyDelete> ProgrammingTechnologyDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetAll> ProgrammingTechnologyGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetByCodeFamilyName> ProgrammingTechnologyGetByCodeFamilyNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetByCodeType> ProgrammingTechnologyGetByCodeTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetById> ProgrammingTechnologyGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyGetByIde> ProgrammingTechnologyGetByIdes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyInsert> ProgrammingTechnologyInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProgrammingTechnologyUpdate> ProgrammingTechnologyUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryDelete> ProjectCategoryDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetAll> ProjectCategoryGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetByCategoryName> ProjectCategoryGetByCategoryNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetByCategoryNameTr> ProjectCategoryGetByCategoryNameTrs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetById> ProjectCategoryGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetByParentId> ProjectCategoryGetByParentIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryGetBySampleUrl> ProjectCategoryGetBySampleUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryInsert> ProjectCategoryInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectCategoryUpdate> ProjectCategoryUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueDelete> ProjectConfigurationKeyAndValueDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetAll> ProjectConfigurationKeyAndValueGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKey> ProjectConfigurationKeyAndValueGetByConfigurationKeys { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldType> ProjectConfigurationKeyAndValueGetByConfigurationKeyFieldTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputType> ProjectConfigurationKeyAndValueGetByConfigurationKeyFromInputTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationValue> ProjectConfigurationKeyAndValueGetByConfigurationValues { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByConfigurationValueType> ProjectConfigurationKeyAndValueGetByConfigurationValueTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetById> ProjectConfigurationKeyAndValueGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueGetByParentConfigurationKeyId> ProjectConfigurationKeyAndValueGetByParentConfigurationKeyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueInsert> ProjectConfigurationKeyAndValueInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationKeyAndValueUpdate> ProjectConfigurationKeyAndValueUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsDelete> ProjectConfigurationsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetAll> ProjectConfigurationsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByAngularConfiguration> ProjectConfigurationsGetByAngularConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBackgroundJobConfiguration> ProjectConfigurationsGetByBackgroundJobConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBackUpConfiguration> ProjectConfigurationsGetByBackUpConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBootStrapConfiguration> ProjectConfigurationsGetByBootStrapConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByBuildConfiguration> ProjectConfigurationsGetByBuildConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCacheConfiguration> ProjectConfigurationsGetByCacheConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCanOverRide> ProjectConfigurationsGetByCanOverRides { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCmsConfiguration> ProjectConfigurationsGetByCmsConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByColumnConfiguration> ProjectConfigurationsGetByColumnConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByComponentConfiguration> ProjectConfigurationsGetByComponentConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByConfigurationJsonScheme> ProjectConfigurationsGetByConfigurationJsonSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByConsoleAppConfiguration> ProjectConfigurationsGetByConsoleAppConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCreatedById> ProjectConfigurationsGetByCreatedByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCreatedDate> ProjectConfigurationsGetByCreatedDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByCssConfiguration> ProjectConfigurationsGetByCssConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDapperConfiguration> ProjectConfigurationsGetByDapperConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDataBaseConfiguration> ProjectConfigurationsGetByDataBaseConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDataTypeConfiguration> ProjectConfigurationsGetByDataTypeConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDbJobConfiguration> ProjectConfigurationsGetByDbJobConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDescription> ProjectConfigurationsGetByDescriptions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDeviceConfiguration> ProjectConfigurationsGetByDeviceConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByDiagramConfiguration> ProjectConfigurationsGetByDiagramConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByElasticSearchConfiguration> ProjectConfigurationsGetByElasticSearchConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByExceptionHandlingConfiguration> ProjectConfigurationsGetByExceptionHandlingConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByExportConfiguration> ProjectConfigurationsGetByExportConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFigmaConfigiration> ProjectConfigurationsGetByFigmaConfigirations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFileManagementConfiguration> ProjectConfigurationsGetByFileManagementConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFileOutputExtensionName> ProjectConfigurationsGetByFileOutputExtensionNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFtpConfiguration> ProjectConfigurationsGetByFtpConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByFunctionConfiguration> ProjectConfigurationsGetByFunctionConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHasNeedCompileOnChange> ProjectConfigurationsGetByHasNeedCompileOnChanges { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHeaderConfiguration> ProjectConfigurationsGetByHeaderConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHelpDocumentConfiguration> ProjectConfigurationsGetByHelpDocumentConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHostingConfiguration> ProjectConfigurationsGetByHostingConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByHtmlConfiguration> ProjectConfigurationsGetByHtmlConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetById> ProjectConfigurationsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByIısConfiguration> ProjectConfigurationsGetByIısConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByInputConfiguration> ProjectConfigurationsGetByInputConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByJsonConfiguration> ProjectConfigurationsGetByJsonConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByLastValidDate> ProjectConfigurationsGetByLastValidDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByLayoutConfiguration> ProjectConfigurationsGetByLayoutConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByLogConfiguration> ProjectConfigurationsGetByLogConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMailConfiguration> ProjectConfigurationsGetByMailConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMongoConfiguration> ProjectConfigurationsGetByMongoConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMsSqlConfiguration> ProjectConfigurationsGetByMsSqlConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByMySqlConfiguration> ProjectConfigurationsGetByMySqlConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByName> ProjectConfigurationsGetByNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNameSpaceConfiguration> ProjectConfigurationsGetByNameSpaceConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNetCoreApıConfiguration> ProjectConfigurationsGetByNetCoreApıConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNginxConfiguration> ProjectConfigurationsGetByNginxConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNodeJsExpressConfiguration> ProjectConfigurationsGetByNodeJsExpressConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByNoteHistory> ProjectConfigurationsGetByNoteHistories { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPackageConfiguration> ProjectConfigurationsGetByPackageConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPaymentConfiguration> ProjectConfigurationsGetByPaymentConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPrismaConfiguration> ProjectConfigurationsGetByPrismaConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPublishPathConfiguration> ProjectConfigurationsGetByPublishPathConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByPurchasedToolConfiguration> ProjectConfigurationsGetByPurchasedToolConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRateLimitConfiguration> ProjectConfigurationsGetByRateLimitConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByReactConfiguration> ProjectConfigurationsGetByReactConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRedisConfiguration> ProjectConfigurationsGetByRedisConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByRoleConfiguration> ProjectConfigurationsGetByRoleConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySecurityConfiguration> ProjectConfigurationsGetBySecurityConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySoftwareLanguageId> ProjectConfigurationsGetBySoftwareLanguageIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySoftwareVersionConfiguration> ProjectConfigurationsGetBySoftwareVersionConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetBySslConfiguration> ProjectConfigurationsGetBySslConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTableConfiguration> ProjectConfigurationsGetByTableConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantApiKeyConfiguration> ProjectConfigurationsGetByTenantApiKeyConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantConfiguration> ProjectConfigurationsGetByTenantConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantPriceConfiguration> ProjectConfigurationsGetByTenantPriceConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTenantWhiteListConfiguration> ProjectConfigurationsGetByTenantWhiteListConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTestConfiguration> ProjectConfigurationsGetByTestConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByThemeConfiguration> ProjectConfigurationsGetByThemeConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByThirdPartyConfiguration> ProjectConfigurationsGetByThirdPartyConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTokenConfiguration> ProjectConfigurationsGetByTokenConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByTsConfiguration> ProjectConfigurationsGetByTsConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByWcfConfiguration> ProjectConfigurationsGetByWcfConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByWindowsServiceConfiguration> ProjectConfigurationsGetByWindowsServiceConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetByXmlConfiguration> ProjectConfigurationsGetByXmlConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetCreatedDateBetween> ProjectConfigurationsGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsGetLastValidDateBetween> ProjectConfigurationsGetLastValidDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsInsert> ProjectConfigurationsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectConfigurationsUpdate> ProjectConfigurationsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsDelete> ProjectFunctionGroupsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetAll> ProjectFunctionGroupsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponse> ProjectFunctionGroupsGetByCallAfterFunctionsSuccessfullResponses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCommission> ProjectFunctionGroupsGetByCommissions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByCurrencyId> ProjectFunctionGroupsGetByCurrencyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByFunctionGroupName> ProjectFunctionGroupsGetByFunctionGroupNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetById> ProjectFunctionGroupsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetByPrice> ProjectFunctionGroupsGetByPrices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsGetBySoftWareLanguageId> ProjectFunctionGroupsGetBySoftWareLanguageIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsInsert> ProjectFunctionGroupsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionGroupsUpdate> ProjectFunctionGroupsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsDelete> ProjectFunctionsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetAll> ProjectFunctionsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByAcceptableQuerystring> ProjectFunctionsGetByAcceptableQuerystrings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByAccessModifierId> ProjectFunctionsGetByAccessModifierIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByApiMethodComment> ProjectFunctionsGetByApiMethodComments { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCacheDbConnection> ProjectFunctionsGetByCacheDbConnections { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCacheType> ProjectFunctionsGetByCacheTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCommission> ProjectFunctionsGetByCommissions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCreatedDate> ProjectFunctionsGetByCreatedDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCrudType> ProjectFunctionsGetByCrudTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCurrencyId> ProjectFunctionsGetByCurrencyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByCustomCode> ProjectFunctionsGetByCustomCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByDatabaseTypesId> ProjectFunctionsGetByDatabaseTypesIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByDocumentUrl> ProjectFunctionsGetByDocumentUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByEventType> ProjectFunctionsGetByEventTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByExampleRequest> ProjectFunctionsGetByExampleRequests { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByExampleResponse> ProjectFunctionsGetByExampleResponses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionCallRankInGroup> ProjectFunctionsGetByFunctionCallRankInGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionGroupId> ProjectFunctionsGetByFunctionGroupIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByFunctionIsParentInGroup> ProjectFunctionsGetByFunctionIsParentInGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasAsync> ProjectFunctionsGetByHasAsyncs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasAuditEvent> ProjectFunctionsGetByHasAuditEvents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasBusEvent> ProjectFunctionsGetByHasBusEvents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasCacheMethod> ProjectFunctionsGetByHasCacheMethods { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHasRateLimit> ProjectFunctionsGetByHasRateLimits { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByHeaderScheme> ProjectFunctionsGetByHeaderSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByi18Json> ProjectFunctionsGetByi18Jsons { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetById> ProjectFunctionsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionId> ProjectFunctionsGetByIfResponseIsSuccessCallThisFunctionIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByIsDeleted> ProjectFunctionsGetByIsDeleteds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByLastScanDate> ProjectFunctionsGetByLastScanDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByLogCodeMergeDateDbConnection> ProjectFunctionsGetByLogCodeMergeDateDbConnections { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByLogCodeMergeDateDbType> ProjectFunctionsGetByLogCodeMergeDateDbTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByNameSpaceList> ProjectFunctionsGetByNameSpaceLists { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByPrice> ProjectFunctionsGetByPrices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByPublishedDate> ProjectFunctionsGetByPublishedDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByQuery> ProjectFunctionsGetByQueries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRateLimitProperty> ProjectFunctionsGetByRateLimitProperties { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRequestScheme> ProjectFunctionsGetByRequestSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseHasMultiModel> ProjectFunctionsGetByResponseHasMultiModels { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseHasReturnValue> ProjectFunctionsGetByResponseHasReturnValues { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByResponseScheme> ProjectFunctionsGetByResponseSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByRoute> ProjectFunctionsGetByRoutes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetBySoftwareLanguageId> ProjectFunctionsGetBySoftwareLanguageIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByStatu> ProjectFunctionsGetByStatus { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetBySuccessNotificationTemplate> ProjectFunctionsGetBySuccessNotificationTemplates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserAgent> ProjectFunctionsGetByUserAgents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserConnectionsId> ProjectFunctionsGetByUserConnectionsIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserDescriptionForMethod> ProjectFunctionsGetByUserDescriptionForMethods { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByUserId> ProjectFunctionsGetByUserIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogAllRequest> ProjectFunctionsGetByWillLogAllRequests { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogAllResponse> ProjectFunctionsGetByWillLogAllResponses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWillLogCodeMergeDate> ProjectFunctionsGetByWillLogCodeMergeDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithHeader> ProjectFunctionsGetByWithHeaders { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithMethod> ProjectFunctionsGetByWithMethods { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetByWithOrigin> ProjectFunctionsGetByWithOrigins { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetCreatedDateBetween> ProjectFunctionsGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetLastScanDateBetween> ProjectFunctionsGetLastScanDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsGetPublishedDateBetween> ProjectFunctionsGetPublishedDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsInsert> ProjectFunctionsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectFunctionsUpdate> ProjectFunctionsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsDelete> ProjectPageComponentElementsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetAll> ProjectPageComponentElementsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByApiRequestUrl> ProjectPageComponentElementsGetByApiRequestUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByBusEventConnectionId> ProjectPageComponentElementsGetByBusEventConnectionIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCacheDbConnection> ProjectPageComponentElementsGetByCacheDbConnections { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCacheType> ProjectPageComponentElementsGetByCacheTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComment> ProjectPageComponentElementsGetByComments { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCommission> ProjectPageComponentElementsGetByCommissions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentCallRankInGroup> ProjectPageComponentElementsGetByComponentCallRankInGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentGroupId> ProjectPageComponentElementsGetByComponentGroupIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByComponentIsParentInGroup> ProjectPageComponentElementsGetByComponentIsParentInGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCreatedDate> ProjectPageComponentElementsGetByCreatedDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCrudType> ProjectPageComponentElementsGetByCrudTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCurrencyId> ProjectPageComponentElementsGetByCurrencyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomAnimationScheme> ProjectPageComponentElementsGetByCustomAnimationSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomCode> ProjectPageComponentElementsGetByCustomCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomCss> ProjectPageComponentElementsGetByCustomCsses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomScheme> ProjectPageComponentElementsGetByCustomSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByCustomScript> ProjectPageComponentElementsGetByCustomScripts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByDatabaseTypesId> ProjectPageComponentElementsGetByDatabaseTypesIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByDocumentUrl> ProjectPageComponentElementsGetByDocumentUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByEventType> ProjectPageComponentElementsGetByEventTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByExampleHtmlCode> ProjectPageComponentElementsGetByExampleHtmlCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByExampleRequest> ProjectPageComponentElementsGetByExampleRequests { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByExampleResponse> ProjectPageComponentElementsGetByExampleResponses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTrigger> ProjectPageComponentElementsGetByFunctionTriggerCallAfterSuccessfullTriggers { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerGroupId> ProjectPageComponentElementsGetByFunctionTriggerGroupIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByFunctionTriggerRank> ProjectPageComponentElementsGetByFunctionTriggerRanks { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasAsync> ProjectPageComponentElementsGetByHasAsyncs { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasBusEvent> ProjectPageComponentElementsGetByHasBusEvents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasCacheMethod> ProjectPageComponentElementsGetByHasCacheMethods { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByHasCodeBuild> ProjectPageComponentElementsGetByHasCodeBuilds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByi18Json> ProjectPageComponentElementsGetByi18Jsons { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetById> ProjectPageComponentElementsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartId> ProjectPageComponentElementsGetByIfResponseIsSuccessCallThisComponentPartIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByIsDeleted> ProjectPageComponentElementsGetByIsDeleteds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLastScanDate> ProjectPageComponentElementsGetByLastScanDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLogCodeMergeDateDbConnection> ProjectPageComponentElementsGetByLogCodeMergeDateDbConnections { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByLogCodeMergeDateDbType> ProjectPageComponentElementsGetByLogCodeMergeDateDbTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByNameSpaceList> ProjectPageComponentElementsGetByNameSpaceLists { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPreviewCode> ProjectPageComponentElementsGetByPreviewCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPreviewUrl> ProjectPageComponentElementsGetByPreviewUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPrice> ProjectPageComponentElementsGetByPrices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByPublishedDate> ProjectPageComponentElementsGetByPublishedDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByQuery> ProjectPageComponentElementsGetByQueries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByRequestHeader> ProjectPageComponentElementsGetByRequestHeaders { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByRequestScheme> ProjectPageComponentElementsGetByRequestSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByResponseHasMultiModel> ProjectPageComponentElementsGetByResponseHasMultiModels { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByResponseHasReturnValue> ProjectPageComponentElementsGetByResponseHasReturnValues { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByResponseScheme> ProjectPageComponentElementsGetByResponseSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetBySoftwareLanguageId> ProjectPageComponentElementsGetBySoftwareLanguageIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByStatu> ProjectPageComponentElementsGetByStatus { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetBySuccessNotificationTemplate> ProjectPageComponentElementsGetBySuccessNotificationTemplates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByUserAgent> ProjectPageComponentElementsGetByUserAgents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByUserDescriptionForComponent> ProjectPageComponentElementsGetByUserDescriptionForComponents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByUserId> ProjectPageComponentElementsGetByUserIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWebSitePageComponentsId> ProjectPageComponentElementsGetByWebSitePageComponentsIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogAllRequest> ProjectPageComponentElementsGetByWillLogAllRequests { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogAllResponse> ProjectPageComponentElementsGetByWillLogAllResponses { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWillLogCodeMergeDate> ProjectPageComponentElementsGetByWillLogCodeMergeDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWithHeader> ProjectPageComponentElementsGetByWithHeaders { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWithMethod> ProjectPageComponentElementsGetByWithMethods { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetByWithOrigin> ProjectPageComponentElementsGetByWithOrigins { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetCreatedDateBetween> ProjectPageComponentElementsGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetLastScanDateBetween> ProjectPageComponentElementsGetLastScanDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsGetPublishedDateBetween> ProjectPageComponentElementsGetPublishedDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsInsert> ProjectPageComponentElementsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentElementsUpdate> ProjectPageComponentElementsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsDelete> ProjectPageComponentsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetAll> ProjectPageComponentsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByApiRequestUrl> ProjectPageComponentsGetByApiRequestUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCommission> ProjectPageComponentsGetByCommissions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByComponentName> ProjectPageComponentsGetByComponentNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCreatedDate> ProjectPageComponentsGetByCreatedDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCrudType> ProjectPageComponentsGetByCrudTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByCurrencyId> ProjectPageComponentsGetByCurrencyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByDatabaseId> ProjectPageComponentsGetByDatabaseIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByDefaultLanguage> ProjectPageComponentsGetByDefaultLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByFormActionUrl> ProjectPageComponentsGetByFormActionUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByHasFinishedSuccessfully> ProjectPageComponentsGetByHasFinishedSuccessfullies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByHasForm> ProjectPageComponentsGetByHasForms { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByHasMultiLanguage> ProjectPageComponentsGetByHasMultiLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetById> ProjectPageComponentsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByLastScanDate> ProjectPageComponentsGetByLastScanDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByLastValidDate> ProjectPageComponentsGetByLastValidDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByModifyDate> ProjectPageComponentsGetByModifyDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByOnHover> ProjectPageComponentsGetByOnHovers { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByParentWebSitePartsId> ProjectPageComponentsGetByParentWebSitePartsIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByPrice> ProjectPageComponentsGetByPrices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByQuery> ProjectPageComponentsGetByQueries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByRequestScheme> ProjectPageComponentsGetByRequestSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByResponseScheme> ProjectPageComponentsGetByResponseSchemes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByScannedLanguage> ProjectPageComponentsGetByScannedLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByUserAgent> ProjectPageComponentsGetByUserAgents { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByUserId> ProjectPageComponentsGetByUserIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetByWebSitePagesId> ProjectPageComponentsGetByWebSitePagesIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetCreatedDateBetween> ProjectPageComponentsGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetLastScanDateBetween> ProjectPageComponentsGetLastScanDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetLastValidDateBetween> ProjectPageComponentsGetLastValidDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsGetModifyDateBetween> ProjectPageComponentsGetModifyDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsInsert> ProjectPageComponentsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPageComponentsUpdate> ProjectPageComponentsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesDelete> ProjectPagesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetAll> ProjectPagesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCommission> ProjectPagesGetByCommissions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCreatedDate> ProjectPagesGetByCreatedDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCssCode> ProjectPagesGetByCssCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCurrencyId> ProjectPagesGetByCurrencyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByCustomCode> ProjectPagesGetByCustomCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByDefaultLanguage> ProjectPagesGetByDefaultLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasFinishedSuccessfully> ProjectPagesGetByHasFinishedSuccessfullies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasMultipleLanguage> ProjectPagesGetByHasMultipleLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHasPaid> ProjectPagesGetByHasPaids { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByHtmlCode> ProjectPagesGetByHtmlCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetById> ProjectPagesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByJsCode> ProjectPagesGetByJsCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByJsonCode> ProjectPagesGetByJsonCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByLastScanDate> ProjectPagesGetByLastScanDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageCycleEventDefination> ProjectPagesGetByPageCycleEventDefinations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageCycleEventDefination1> ProjectPagesGetByPageCycleEventDefination1S { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageName> ProjectPagesGetByPageNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPageUrl> ProjectPagesGetByPageUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByPrice> ProjectPagesGetByPrices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByProjectId> ProjectPagesGetByProjectIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByReferralUrl> ProjectPagesGetByReferralUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByRoute> ProjectPagesGetByRoutes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByScannedLanguage> ProjectPagesGetByScannedLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetByUserId> ProjectPagesGetByUserIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetCreatedDateBetween> ProjectPagesGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesGetLastScanDateBetween> ProjectPagesGetLastScanDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesInsert> ProjectPagesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectPagesUpdate> ProjectPagesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsDelete> ProjectsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetAll> ProjectsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByConfiguration> ProjectsGetByConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByConnectionSetting> ProjectsGetByConnectionSettings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByDatabaseSchema> ProjectsGetByDatabaseSchemas { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByEndpoint> ProjectsGetByEndpoints { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByEnumList> ProjectsGetByEnumLists { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByGuid> ProjectsGetByGuids { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetById> ProjectsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByLanguageDefination> ProjectsGetByLanguageDefinations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByLookup> ProjectsGetByLookups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByName> ProjectsGetByNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByRuleGroup> ProjectsGetByRuleGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByTableGroup> ProjectsGetByTableGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByTable> ProjectsGetByTables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsGetByUserId> ProjectsGetByUserIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsInsert> ProjectsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectsUpdate> ProjectsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsDelete> ProjectTableColumnsDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetAll> ProjectTableColumnsGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsCreatePageConfiguration> ProjectTableColumnsGetByCmsCreatePageConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsDeletePageConfiguration> ProjectTableColumnsGetByCmsDeletePageConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsEditPageConfiguration> ProjectTableColumnsGetByCmsEditPageConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCmsListPageConfiguration> ProjectTableColumnsGetByCmsListPageConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnName> ProjectTableColumnsGetByColumnNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnNameCrypto> ProjectTableColumnsGetByColumnNameCryptos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnNameI18> ProjectTableColumnsGetByColumnNameI18S { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByColumnsConfiguration> ProjectTableColumnsGetByColumnsConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByComment> ProjectTableColumnsGetByComments { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCommission> ProjectTableColumnsGetByCommissions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByComponentConfiguration> ProjectTableColumnsGetByComponentConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCurrencyId> ProjectTableColumnsGetByCurrencyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByCustomCode> ProjectTableColumnsGetByCustomCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDatabaseCreateMigrationScript> ProjectTableColumnsGetByDatabaseCreateMigrationScripts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDataTypeMapping> ProjectTableColumnsGetByDataTypeMappings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDbType> ProjectTableColumnsGetByDbTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDefaultValue> ProjectTableColumnsGetByDefaultValues { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByDependencyConfiguration> ProjectTableColumnsGetByDependencyConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByExtra> ProjectTableColumnsGetByExtras { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByFkDetail> ProjectTableColumnsGetByFkDetails { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetById> ProjectTableColumnsGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByInputType> ProjectTableColumnsGetByInputTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByIsNullable> ProjectTableColumnsGetByIsNullables { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByIsPrimary> ProjectTableColumnsGetByIsPrimaries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByKeyConfiguration> ProjectTableColumnsGetByKeyConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByMappingConfiguration> ProjectTableColumnsGetByMappingConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByMaxLength> ProjectTableColumnsGetByMaxLengths { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByPrice> ProjectTableColumnsGetByPrices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByPrimitiveType> ProjectTableColumnsGetByPrimitiveTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByTableId> ProjectTableColumnsGetByTableIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsGetByTableName> ProjectTableColumnsGetByTableNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsInsert> ProjectTableColumnsInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTableColumnsUpdate> ProjectTableColumnsUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesDelete> ProjectTablesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetAll> ProjectTablesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByApiConfiguration> ProjectTablesGetByApiConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByAuditConfiguration> ProjectTablesGetByAuditConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsCustomFilterConfiguration> ProjectTablesGetByCmsCustomFilterConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsExportConfiguration> ProjectTablesGetByCmsExportConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsMenuConfiguration> ProjectTablesGetByCmsMenuConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsPermissionConfiguration> ProjectTablesGetByCmsPermissionConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCmsRouteConfiguration> ProjectTablesGetByCmsRouteConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByColumn> ProjectTablesGetByColumns { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByComment> ProjectTablesGetByComments { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCommission> ProjectTablesGetByCommissions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCurrencyId> ProjectTablesGetByCurrencyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByCustomCode> ProjectTablesGetByCustomCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByDataIndex> ProjectTablesGetByDataIndices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByDiagramConfiguration> ProjectTablesGetByDiagramConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByI18Configuration> ProjectTablesGetByI18Configurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetById> ProjectTablesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByPrice> ProjectTablesGetByPrices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProgrammingLanguageId> ProjectTablesGetByProgrammingLanguageIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProjectName> ProjectTablesGetByProjectNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByProjectTableConfiguration> ProjectTablesGetByProjectTableConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByTableName> ProjectTablesGetByTableNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByTableNameCrypto> ProjectTablesGetByTableNameCryptos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByUniqueColumn> ProjectTablesGetByUniqueColumns { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesGetByUserProjectConnection> ProjectTablesGetByUserProjectConnections { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesInsert> ProjectTablesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ProjectTablesUpdate> ProjectTablesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesDelete> ReferenceWebSitesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetAll> ReferenceWebSitesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByAvgVisitDuration> ReferenceWebSitesGetByAvgVisitDurations { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByBounceRate> ReferenceWebSitesGetByBounceRates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCommission> ReferenceWebSitesGetByCommissions { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCreatedDate> ReferenceWebSitesGetByCreatedDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByCurrencyId> ReferenceWebSitesGetByCurrencyIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByDefaultLanguage> ReferenceWebSitesGetByDefaultLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByGuid> ReferenceWebSitesGetByGuids { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetById> ReferenceWebSitesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByIsLastPublishSuccessfully> ReferenceWebSitesGetByIsLastPublishSuccessfullies { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByLastCompileDate> ReferenceWebSitesGetByLastCompileDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByLogo> ReferenceWebSitesGetByLogos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByModifyDate> ReferenceWebSitesGetByModifyDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByPageVisit> ReferenceWebSitesGetByPageVisits { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByPrice> ReferenceWebSitesGetByPrices { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByProjectCategoryId> ReferenceWebSitesGetByProjectCategoryIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByRanking> ReferenceWebSitesGetByRankings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetBySiteName> ReferenceWebSitesGetBySiteNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetBySoftwareLanguageId> ReferenceWebSitesGetBySoftwareLanguageIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByUrl> ReferenceWebSitesGetByUrls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByUserId> ReferenceWebSitesGetByUserIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetByValidDate> ReferenceWebSitesGetByValidDates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetCreatedDateBetween> ReferenceWebSitesGetCreatedDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetLastCompileDateBetween> ReferenceWebSitesGetLastCompileDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetModifyDateBetween> ReferenceWebSitesGetModifyDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesGetValidDateBetween> ReferenceWebSitesGetValidDateBetweens { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesInsert> ReferenceWebSitesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.ReferenceWebSitesUpdate> ReferenceWebSitesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SchemesDelete> SchemesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SchemesGetAll> SchemesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SchemesGetByDatabaseType> SchemesGetByDatabaseTypes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SchemesGetById> SchemesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SchemesGetByName> SchemesGetByNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SchemesInsert> SchemesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SchemesUpdate> SchemesUpdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpColumn> SpColumns { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpDatatypeInfo> SpDatatypeInfos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpDbmmonitoraddmonitoring> SpDbmmonitoraddmonitorings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpDbmmonitorhelpalert> SpDbmmonitorhelpalerts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpDbmmonitorresult> SpDbmmonitorresults { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpDbmmonitorupdate> SpDbmmonitorupdates { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpDroplogin> SpDroplogins { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpHelpDatatypeMapping> SpHelpDatatypeMappings { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpKillOldestTransactionOnSecondaryResult> SpKillOldestTransactionOnSecondaries { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpMonitor> SpMonitors { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.SpMsgetalertinfo> SpMsgetalertinfos { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.TablesDelete> TablesDeletes { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.TablesGetAll> TablesGetAlls { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.TablesGetById> TablesGetByIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.TablesGetByProjectId> TablesGetByProjectIds { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.TablesGetByTableName> TablesGetByTableNames { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.TablesInsert> TablesInserts { get; set; }

        public DbSet<ZarenUI.Server.Models.JSONServer.TablesUpdate> TablesUpdates { get; set; }
    }
}