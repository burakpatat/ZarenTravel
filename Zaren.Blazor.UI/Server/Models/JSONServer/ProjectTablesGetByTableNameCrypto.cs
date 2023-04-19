using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectTablesGetByTableNameCrypto
    {
        public int Id { get; set; }

        public string TableName { get; set; }

        public string TableNameCrypto { get; set; }

        public string UniqueColumns { get; set; }

        public string DataIndex { get; set; }

        public string ProjectName { get; set; }

        public string UserProjectConnections { get; set; }

        public string Columns { get; set; }

        public string ProjectTableConfiguration { get; set; }

        public string DiagramConfiguration { get; set; }

        public string AuditConfiguration { get; set; }

        public string Comment { get; set; }

        public string CMSMenuConfiguration { get; set; }

        public string CMSPermissionConfiguration { get; set; }

        public string CMSExportConfiguration { get; set; }

        public string CMSCustomFilterConfiguration { get; set; }

        public decimal? Price { get; set; }

        public int? CurrencyId { get; set; }

        public decimal? Commission { get; set; }

        public string CustomCode { get; set; }

        public string CMSRouteConfiguration { get; set; }

        public string ApiConfiguration { get; set; }

        public int? ProgrammingLanguageId { get; set; }

        public string I18Configuration { get; set; }

    }
}