using System;
using Core.Entities;
using System.Text.Json.Serialization;
using Dapper;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Model.Concrete
{
    [Table("DataTypeMapping")]
    public class DataTypeMapping : IEntity
    {

        private string _SQLServerDatabaseEngineType;
        [JsonPropertyName("sQLServerDatabaseEngineType")]
        public string SQLServerDatabaseEngineType
        {
            get { return _SQLServerDatabaseEngineType; }
            set { _SQLServerDatabaseEngineType = value; }
        }
        private string _NetFrameworkType;
        [JsonPropertyName("netFrameworkType")]
        public string NetFrameworkType
        {
            get { return _NetFrameworkType; }
            set { _NetFrameworkType = value; }
        }
        private string _SqlDbTypeEnumeration;
        [JsonPropertyName("sqlDbTypeEnumeration")]
        public string SqlDbTypeEnumeration
        {
            get { return _SqlDbTypeEnumeration; }
            set { _SqlDbTypeEnumeration = value; }
        }
        private string _SqlDataReaderSqlTypes;
        [JsonPropertyName("sqlDataReaderSqlTypes")]
        public string SqlDataReaderSqlTypes
        {
            get { return _SqlDataReaderSqlTypes; }
            set { _SqlDataReaderSqlTypes = value; }
        }
        private string _DbTypeEnumeration;
        [JsonPropertyName("dbTypeEnumeration")]
        public string DbTypeEnumeration
        {
            get { return _DbTypeEnumeration; }
            set { _DbTypeEnumeration = value; }
        }
        private string _SqlDataReaderDbType;
        [JsonPropertyName("sqlDataReaderDbType")]
        public string SqlDataReaderDbType
        {
            get { return _SqlDataReaderDbType; }
            set { _SqlDataReaderDbType = value; }
        }
    }

}
