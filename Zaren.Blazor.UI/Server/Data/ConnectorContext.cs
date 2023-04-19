using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ZarenUI.Server.Models.Connector;

namespace ZarenUI.Server.Data
{
    public partial class ConnectorContext : DbContext
    {
        public ConnectorContext()
        {
        }

        public ConnectorContext(DbContextOptions<ConnectorContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ZarenUI.Server.Models.Connector.DesignScheme>().HasNoKey();
            this.OnModelBuilding(builder);
        }

        public DbSet<ZarenUI.Server.Models.Connector.ColorGroup> ColorGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.Country> Countries { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.CountryLanguage> CountryLanguages { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.DeviceGroup> DeviceGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.Device> Devices { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.DistributedServerCache> DistributedServerCaches { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.Field> Fields { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProgrammingCategory> ProgrammingCategories { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProgrammingCode> ProgrammingCodes { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProgrammingCodeTemplate> ProgrammingCodeTemplates { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectCategory> ProjectCategories { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectConfigurationKeyAndValue> ProjectConfigurationKeyAndValues { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectConfiguration> ProjectConfigurations { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectFunctionGroup> ProjectFunctionGroups { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectFunction> ProjectFunctions { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectPageComponentElement> ProjectPageComponentElements { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectPageComponent> ProjectPageComponents { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectPage> ProjectPages { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.Project> Projects { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectTableColumn> ProjectTableColumns { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ProjectTable> ProjectTables { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.ReferenceWebSite> ReferenceWebSites { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.Scheme> Schemes { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.Table> Tables { get; set; }

        public DbSet<ZarenUI.Server.Models.Connector.DesignScheme> DesignSchemes { get; set; }
    }
}