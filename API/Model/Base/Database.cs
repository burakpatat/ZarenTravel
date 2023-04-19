using Dapper.Contrib.Extensions;
using System.Text.Json.Serialization;

[Table("BriefOffer")]
public class Database
{

    [JsonPropertyName("dbid")]
    public int Id;

    [JsonPropertyName("TABLE_CATALOG")]
    public string TABLECATALOG;

    [JsonPropertyName("TABLE_SCHEMA")]
    public string TABLESCHEMA;

    [JsonPropertyName("TABLE_NAME")]
    public string TABLENAME;

    [JsonPropertyName("COLUMN_NAME")]
    public string COLUMNNAME;

    [JsonPropertyName("ORDINAL_POSITION")]
    public int? ORDINALPOSITION;

    [JsonPropertyName("COLUMN_DEFAULT")]
    public string COLUMNDEFAULT;

    [JsonPropertyName("IS_NULLABLE")]
    public string ISNULLABLE;

    [JsonPropertyName("DATA_TYPE")]
    public string DATATYPE;

    [JsonPropertyName("CHARACTER_MAXIMUM_LENGTH")]
    public long? CHARACTERMAXIMUMLENGTH;

    [JsonPropertyName("CHARACTER_OCTET_LENGTH")]
    public long? CHARACTEROCTETLENGTH;

    [JsonPropertyName("NUMERIC_PRECISION")]
    public int? NUMERICPRECISION;

    [JsonPropertyName("NUMERIC_PRECISION_RADIX")]
    public int? NUMERICPRECISIONRADIX;

    [JsonPropertyName("NUMERIC_SCALE")]
    public int? NUMERICSCALE;

    [JsonPropertyName("DATETIME_PRECISION")]
    public int? DATETIMEPRECISION;

    [JsonPropertyName("CHARACTER_SET_CATALOG")]
    public object CHARACTERSETCATALOG;

    [JsonPropertyName("CHARACTER_SET_SCHEMA")]
    public object CHARACTERSETSCHEMA;

    [JsonPropertyName("CHARACTER_SET_NAME")]
    public string CHARACTERSETNAME;

    [JsonPropertyName("COLLATION_CATALOG")]
    public object COLLATIONCATALOG;

    [JsonPropertyName("COLLATION_SCHEMA")]
    public object COLLATIONSCHEMA;

    [JsonPropertyName("COLLATION_NAME")]
    public string COLLATIONNAME;

    [JsonPropertyName("DOMAIN_CATALOG")]
    public object DOMAINCATALOG;

    [JsonPropertyName("DOMAIN_SCHEMA")]
    public object DOMAINSCHEMA;

    [JsonPropertyName("DOMAIN_NAME")]
    public object DOMAINNAME;
}

