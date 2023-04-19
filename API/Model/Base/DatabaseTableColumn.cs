using System.Text.Json.Serialization;
using Dapper.Contrib.Extensions;
namespace Model.Concrete
{

    public class DatabaseTableColumn
    {
        private bool? _IsPrimary;
        public bool? IsPrimary
        {
            get { return _IsPrimary; }
            set { _IsPrimary = value; }
        }

        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private string _ColumnName;
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        private string _DbType;
        public string DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }
        private int? _TableOrder;
        public int? TableOrder
        {
            get { return _TableOrder; }
            set { _TableOrder = value; }
        }
        private bool? _IsNullable;
        public bool? IsNullable
        {
            get { return _IsNullable; }
            set { _IsNullable = value; }
        }
        private int? _MaxLength;
        public int? MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }

        private string _DefaultValue;
        public string DefaultValue
        {
            get { return _DefaultValue; }
            set { _DefaultValue = value; }
        }
        private bool _HasDefaultValue;
        public bool HasDefaultValue
        {
            get { return _HasDefaultValue; }
            set { _HasDefaultValue = value; }
        }
        private string _IndexDesc;
        public string IndexDesc
        {
            get { return _IndexDesc; }
            set { _IndexDesc = value; }
        }

        private string _IndexName;
        public string IndexName
        {
            get { return _IndexName; }
            set { _IndexName = value; }
        }

        private bool? _IsRoutingField;
        public bool? IsRoutingField
        {
            get { return _IsRoutingField; }
            set { _IsRoutingField = value; }
        }
        private int? _CMSInputType;
        public int? CMSInputType
        {
            get { return _CMSInputType; }
            set { _CMSInputType = value; }
        }
        private string _CMSColumnTitle;
        public string CMSColumnTitle
        {
            get { return _CMSColumnTitle; }
            set { _CMSColumnTitle = value; }
        }

        private string _SelectedValue;
        public string SelectedValue
        {
            get { return _SelectedValue; }
            set { _SelectedValue = value; }
        }
        private string _SelectedText;
        public string SelectedText
        {
            get { return _SelectedText; }
            set { _SelectedText = value; }
        }
        private bool? _HasShowedOnList;
        public bool? HasShowedOnList
        {
            get { return _HasShowedOnList; }
            set { _HasShowedOnList = value; }
        }
        private bool? _IsFilter;
        public bool? IsFilter
        {
            get { return _IsFilter; }
            set { _IsFilter = value; }
        }
        private string _Resize;
        public string Resize
        {
            get { return _Resize; }
            set { _Resize = value; }
        }
        private bool? _IsLanguageField;
        public bool? IsLanguageField
        {
            get { return _IsLanguageField; }
            set { _IsLanguageField = value; }
        }

        private bool? _IsSecondry;
        public bool? IsSecondry
        {
            get { return _IsSecondry; }
            set { _IsSecondry = value; }
        }
        private string _SelectedDataSourceTable;
        public string SelectedDataSourceTable
        {
            get { return _SelectedDataSourceTable; }
            set { _SelectedDataSourceTable = value; }
        }
        private string _JsonName;
        public string JsonName
        {
            get { return _JsonName; }
            set { _JsonName = value; }
        }
        private string _Tooltip;
        public string Tooltip
        {
            get { return _Tooltip; }
            set { _Tooltip = value; }
        }

        private string _ErrorDescription;
        public string ErrorDescription
        {
            get { return _ErrorDescription; }
            set { _ErrorDescription = value; }
        }
        private string _ParameterDescription;
        public string ParameterDescription
        {
            get { return _ParameterDescription; }
            set { _ParameterDescription = value; }
        }
        private bool? _IsRequired;
        public bool? IsRequired
        {
            get { return _IsRequired; }
            set { _IsRequired = value; }
        }

        private bool? _IsPublic;
        public bool? IsPublic
        {
            get { return _IsPublic; }
            set { _IsPublic = value; }
        }
        private bool? _ReturnColumnNameFromCMSTitle;
        public bool? ReturnColumnNameFromCMSTitle
        {
            get { return _ReturnColumnNameFromCMSTitle; }
            set { _ReturnColumnNameFromCMSTitle = value; }
        }
    }
    [Table("INFORMATION_SCHEMA.COLUMNS")]
    public class DBColumns
    {
        [JsonPropertyName("IsPrimary")]
        public bool IsPrimary;

        [JsonPropertyName("TableName")]
        public string TableName;

        [JsonPropertyName("ColumnName")]
        public string ColumnName;

        [JsonPropertyName("DbType")]
        public string DbType;

        [JsonPropertyName("TableOrder")]
        public int TableOrder;

        [JsonPropertyName("IsNullable")]
        public bool IsNullable;

        [JsonPropertyName("MaxLength")]
        public int MaxLength;

        [JsonPropertyName("HasDefaultValue")]
        public string HasDefaultValue;

        [JsonPropertyName("IndexDesc")]
        public string IndexDesc;

        [JsonPropertyName("IndexName")]
        public string IndexName;


    }

    [Table("INFORMATION_SCHEMA.COLUMNS")]
    public class Database
    {

        private string _ConnectionString;
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }

        private string _DatabaseName;
        public string DatabaseName
        {
            get { return _DatabaseName; }
            set { _DatabaseName = value; }
        }

        private bool? _IsPrimary;
        public bool? IsPrimary
        {
            get { return _IsPrimary; }
            set { _IsPrimary = value; }
        }

        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private string _ColumnName;
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }
        private string _DbType;
        public string DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }
        private int? _TableOrder;
        public int? TableOrder
        {
            get { return _TableOrder; }
            set { _TableOrder = value; }
        }
        private bool? _IsNullable;
        public bool? IsNullable
        {
            get { return _IsNullable; }
            set { _IsNullable = value; }
        }
        private int? _MaxLength;
        public int? MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }

        private string _HasDefaultValue;
        public string HasDefaultValue
        {
            get { return _HasDefaultValue; }
            set { _HasDefaultValue = value; }
        }
        private string _IndexDesc;
        public string IndexDesc
        {
            get { return _IndexDesc; }
            set { _IndexDesc = value; }
        }

        private string _IndexName;
        public string IndexName
        {
            get { return _IndexName; }
            set { _IndexName = value; }
        }


    }



    public class DatabaseTableAndColumns
    {


        private string _TableName;
        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private string _ColumnName;
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }
        private string _DbType;
        public string DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }
        private int? _TableOrder;
        public int? TableOrder
        {
            get { return _TableOrder; }
            set { _TableOrder = value; }
        }
        private bool? _IsNullable;
        public bool? IsNullable
        {
            get { return _IsNullable; }
            set { _IsNullable = value; }
        }
        private int? _MaxLength;
        public int? MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }

        private string _HasDefaultValue;
        public string HasDefaultValue
        {
            get { return _HasDefaultValue; }
            set { _HasDefaultValue = value; }
        }
        private string _IndexType;
        public string IndexType
        {
            get { return _IndexType; }
            set { _IndexType = value; }
        }

        private string _IndexName;
        public string IndexName
        {
            get { return _IndexName; }
            set { _IndexName = value; }
        }
        private bool? _AddedFromTo;
        public bool? AddedFromTo
        {
            get { return _AddedFromTo; }
            set { _AddedFromTo = value; }
        }
        private bool? _AddedToFrom;
        public bool? AddedToFrom
        {
            get { return _AddedToFrom; }
            set { _AddedToFrom = value; }
        }
    }

}


public class FKTables
{

    public string FK_CONSTRAINT_SCHEMA { get; set; }
    public string FK_CONSTRAINT_NAME { get; set; }
    public string FK_TABLE_SCHEMA { get; set; }
    public string FK_TABLE_NAME { get; set; }
    public string REFERENCED_TABLE_SCHEMA { get; set; }
    public string REFERENCED_TABLE_NAME { get; set; }
    public string FK_COLUMNS { get; set; }
    public string REFERENCED_COLUMNS { get; set; }
    public string SqlCreateFK { get; set; }
}