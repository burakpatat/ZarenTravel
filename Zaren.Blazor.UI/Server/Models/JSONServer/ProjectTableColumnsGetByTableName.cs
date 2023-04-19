using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ZarenUI.Server.Models.JSONServer
{
    public partial class ProjectTableColumnsGetByTableName
    {
        public int Id { get; set; }

        public string ColumnName { get; set; }

        public string ColumnNameCrypto { get; set; }

        public string DbType { get; set; }

        public string PrimitiveType { get; set; }

        public string DefaultValue { get; set; }

        public bool? IsNullable { get; set; }

        public string MaxLength { get; set; }

        public string FKDetails { get; set; }

        public string TableName { get; set; }

        public int? TableId { get; set; }

        public bool? IsPrimary { get; set; }

        public int? InputType { get; set; }

        public string KeyConfiguration { get; set; }

        public string Extra { get; set; }

        public string Comment { get; set; }

        public string DataTypeMapping { get; set; }

        public string ColumnsConfiguration { get; set; }

        public string MappingConfiguration { get; set; }

        public string DependencyConfiguration { get; set; }

        public decimal? Price { get; set; }

        public int? CurrencyId { get; set; }

        public decimal? Commission { get; set; }

        public string CustomCode { get; set; }

        public string ComponentConfiguration { get; set; }

        public string CMSListPageConfiguration { get; set; }

        public string CMSEditPageConfiguration { get; set; }

        public string CMSCreatePageConfiguration { get; set; }

        public string CMSDeletePageConfiguration { get; set; }

        public string DatabaseCreateMigrationScript { get; set; }

        public string ColumnNameI18 { get; set; }

    }
}