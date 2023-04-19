using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarenTravel.Models.ZarenSoft
{
    public partial class DatabaseColumnsGetByTableId
    {
        public int ID { get; set; }

        public int? TableID { get; set; }

        public string ColumnName { get; set; }

        public int? DbType { get; set; }

        public bool? IsRoutingField { get; set; }

        public int? CMSInputType { get; set; }

        public string CMSColumnTitle { get; set; }

        public int? TableOrder { get; set; }

        public string SelectedValue { get; set; }

        public string SelectedText { get; set; }

        public bool? HasShowedOnList { get; set; }

        public bool? IsFilter { get; set; }

        public string Resize { get; set; }

        public bool? IsLanguageField { get; set; }

        public bool? IsPrimary { get; set; }

        public bool? IsSecondry { get; set; }

        public string SelectedDataSourceTable { get; set; }

        public string JsonName { get; set; }

        public string Tooltip { get; set; }

        public bool? IsNullable { get; set; }

        public int? MaxLength { get; set; }

        public bool? IsRequired { get; set; }

        public bool? HasDefaultValue { get; set; }

        public bool? IsPublic { get; set; }

        public bool? ReturnColumnNameFromCMSTitle { get; set; }

        public string ErrorDescription { get; set; }

        public string ParameterDescription { get; set; }

    }
}