using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

namespace Model.Concrete
{


    [Table("INFORMATION_SCHEMA.PARAMETERS")]
    public class RequestParameter
    {


        private string _Parameter_Name;

        [JsonPropertyName("pn")]
        public string Parameter_Name
        {
            get { return _Parameter_Name; }
            set { _Parameter_Name = value; }
        }


        private string _DbType;

        [JsonPropertyName("dt")]
        public string DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }
        private string _Value;

        [JsonPropertyName("vl")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private string _MaxLength;

        [JsonPropertyName("ml")]
        public string MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }
    }


    [Table("INFORMATION_SCHEMA.PARAMETERS")]
    public class RequestParams
    {
        private string _ProcedureName;
        public string ProcedureName
        {
            get { return _ProcedureName; }
            set { _ProcedureName = value; }
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

        private string _CompileType;
        public string CompileType
        {
            get { return _CompileType; }
            set { _CompileType = value; }
        }

        private int? _TableOrder;
        public int? TableOrder
        {
            get { return _TableOrder; }
            set { _TableOrder = value; }
        }

        private int? _MaxLength;
        public int? MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }

        public string Schema { get; set; }
    }

    public class ResponseParams
    {

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

        private int? _MaxLength;
        public int? MaxLength
        {
            get { return _MaxLength; }
            set { _MaxLength = value; }
        }


        private bool _IsPrimary;
        public bool IsPrimary
        {
            get { return _IsPrimary; }
            set { _IsPrimary = value; }
        }


        private bool _IsNullable;
        public bool IsNullable
        {
            get { return _IsNullable; }
            set { _IsNullable = value; }
        }


        private bool _IsUpdatable;
        public bool IsUpdatable
        {
            get { return _IsUpdatable; }
            set { _IsUpdatable = value; }
        }
    }

    public class ResponseParameter
    {


        private string _ColumnName;
        [JsonPropertyName("cn")]
        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        private string _DbType;
        [JsonPropertyName("dt")]
        public string DbType
        {
            get { return _DbType; }
            set { _DbType = value; }
        }

    }
}
