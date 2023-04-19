using Model.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

public static class DataTypeExtensions
{
    public static bool ToBool(this object value)
    {
        try
        {
            if (value != null)
                return Boolean.Parse(value.ToString());
            else
                return false;

        }
        catch
        {
            return false;
        }
    }

    public static string intDictionaryToJson(this Dictionary<int, List<int>> dict)
    {
        var entries = dict.Select(d =>
            string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
        return "{" + string.Join(",", entries) + "}";
    }

    public static string stringDictionaryToJson(this Dictionary<string, string> dict)
    {
        var entries = dict.Select(d =>
            string.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
        return "{" + string.Join(",", entries) + "}";
    }
    public static string objectDictionaryToJson(this Dictionary<string, object> dict)
    {
        var entries = dict.Select(d =>
            string.Format("\"{0}\": {1}", d.Key, string.Join(",", d.Value)));
        return "{" + string.Join(",", entries) + "}";
    }
    public static byte ToByte(this string value)
    {
        try
        {
            return Byte.Parse(value);
        }
        catch
        {
            return new Byte();
        }
    }

    public static double ConvertBytesToMegabytes(this long bytes)
    {
        return (bytes / 1024f) / 1024f;
    }

    public static double ConvertKilobytesToMegabytes(this long kilobytes)
    {
        return kilobytes / 1024f;
    }

    public static Char ToChar(this string value)
    {
        try
        {
            return Convert.ToChar(value);
        }
        catch
        {
            return new Char();
        }
    }

    public static Decimal ToDecimal(this string value)
    {
        try
        {
            return Decimal.Parse(value);
        }
        catch
        {
            return new Decimal();
        }
    }

    public static Double ToDouble(this string value)
    {
        try
        {
            return Double.Parse(value);
        }
        catch
        {
            return new Double();
        }
    }

    public static float ToFloat(this string value)
    {
        try
        {
            return float.Parse(value);
        }
        catch
        {
            return new float();
        }
    }

    public static Int16 ToInt16(this object value)
    {
        try
        {
            return Int16.Parse(value.ToString());
        }
        catch
        {
            return new Int16();
        }
    }

    public static Int32 ToInt32(this object value)
    {
        try
        {
            if (value != null)
                return Int32.Parse(value.ToString());
            else
                return 0;

        }
        catch
        {
            return new Int32();
        }
    }
    public static Decimal ToDecimal(this object value)
    {
        try
        {
            if (value != null)
                return Convert.ToDecimal(value);
            else
                return 0;

        }
        catch
        {
            return 0;
        }
    }
    public static string ToMaskedDateTime(this object value)
    {
        try
        {
            if (value.GetType() == typeof(string))
            {

                return Convert.ToDateTime(value).ToString("dd/MM/yyyy", Thread.CurrentThread.CurrentUICulture);
            }
            else if (value.GetType() == typeof(DateTime))
            {
                return Convert.ToDateTime(value).ToString("dd/MM/yyyy", Thread.CurrentThread.CurrentUICulture);
            }
            else
            {
                return new DateTime().ToShortDateString();
            }



        }
        catch (Exception)
        {
            return new DateTime().ToShortDateString();
        }
    }


    public static DateTime ToDateTime(this object value, string pattern = "dd/MM/yyyy")
    {
        try
        {
            if (value.GetType() == typeof(string))
            {

                return Convert.ToDateTime(Convert.ToDateTime(value).ToString(pattern, Thread.CurrentThread.CurrentUICulture));
            }
            else if (value.GetType() == typeof(DateTime))
            {
                return Convert.ToDateTime(Convert.ToDateTime(value).ToString(pattern, Thread.CurrentThread.CurrentUICulture));
            }
            else
            {
                return DateTime.Now;
            }
        }
        catch (Exception)
        {
            return DateTime.Now;
        }
    }


    public static string ToImage(this object value)
    {
        if (value.ToString().Contains(".mp4") || value.ToString().Contains(".flv") || value.ToString().Contains(".webm") || value.ToString().Contains(".avi") || value.ToString().Contains(".mov") || value.ToString().Contains(".3gp"))
        {
            try
            {
                return "<video src='" + value + "' controls='controls' height='100' />";
            }
            catch (Exception)
            {
                return "<video src='" + value + "' controls='controls' height='100' />";
            }
        }
        else
        {
            try
            {
                return "<img src='" + value + "' height='100'/>";
            }
            catch (Exception)
            {
                return "<img src='" + value + "' height='100'/>";
            }
        }

    }
    public static string ToImage(this object value, int width)
    {
        if (width == 0)
        {
            try
            {
                return "<img src='" + value + "' />";
            }
            catch (Exception)
            {
                return "<img src='" + value + "' />";
            }
        }
        else
        {
            try
            {
                return "<img src='" + value + "' height='" + width + "'/>";
            }
            catch (Exception)
            {
                return "<img src='" + value + "' height='" + width + "'/>";
            }
        }

    }
    public static string ToImageNoWidth(this object value)
    {

        try
        {
            return "<img src='" + value + "' />";
        }
        catch (Exception)
        {
            return "<img src='" + value + "' />";
        }



    }
    public static string ToShortDateTime(this object value)
    {
        try
        {
            if (value.GetType() == typeof(string))
            {

                return Convert.ToDateTime(value).ToString("dd MMMM yyyy", Thread.CurrentThread.CurrentUICulture);
            }
            else if (value.GetType() == typeof(DateTime))
            {
                return Convert.ToDateTime(value).ToString("dd MMMM yyyy", Thread.CurrentThread.CurrentUICulture);
            }
            else
            {
                return new DateTime().ToShortDateString();
            }



        }
        catch (Exception)
        {
            return new DateTime().ToShortDateString();
        }
    }

    public static string ToMapPath(this string path)
    {
        return Path.Combine(
            (string)AppDomain.CurrentDomain.GetData("ContentRootPath"),
            path);
    }
    public static Int64 ToInt64(this object value)
    {
        try
        {
            if (value == null)
            {
                return 0;
            }
            return Int64.Parse(value.ToString());
        }
        catch (Exception)
        {
            return new Int64();
        }
    }

    public static string ToMoneyString(this decimal value)
    {
        try
        {
            return value.ToString("#.##");
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public static string ToPublishedStatu(this object value)
    {
        var yayindaDegil = "<span class='label label-danger'>Yayında Değil</span>";
        var yayinda = "<span class='label label-success'>Yayında</span>";
        try
        {
            if (value.GetType() == typeof(int))
            {
                if (value.ToString().ToInt32() == 1)
                {
                    return yayinda;
                }
                else
                {
                    return yayindaDegil;
                }
            }
            if (value.GetType() == typeof(bool))
            {
                if (Convert.ToBoolean(value) == true)
                {
                    return yayinda;
                }
                else
                {
                    return yayindaDegil;
                }
            }
            return yayindaDegil;
        }
        catch (Exception)
        {
            return yayindaDegil;
        }
    }


    public static string ToYesNo(this object value)
    {
        const string hayir = "<span class='label label-danger'>Hayır</span>";
        const string evet = "<span class='label label-success'>Evet</span>";

        try
        {
            if (value.GetType() == typeof(int))
            {
                if (value.ToString().ToInt32() == 1)
                {
                    return evet;
                }
                if (value.ToString().ToInt32() == 0)
                {
                    return hayir;
                }

            }
            else if (value.GetType() == typeof(bool))
            {
                if (Convert.ToBoolean(value) == true)
                {
                    return evet;
                }
                else
                {
                    return hayir;
                }

            }

            return hayir;
        }
        catch (Exception)
        {
            return hayir;
        }
    }
    public static string ToFormat(this string value, params string[] parameters)
    {
        return string.Format(value, parameters);
    }

    public static string ToJson(this object obj)
    {
        try
        {
            if (obj != null)
                return JsonConvert.SerializeObject(obj, Formatting.Indented);
            else
                return "";
        }
        catch
        {
            return "";
        }
    }


    public static object FromJson(this object obj)
    {

        return JsonConvert.DeserializeObject(obj.ToJson());


    }


    public static string ToSqlDate(this DateTime value)
    {
        return value.ToString("yyyy-MM-dd HH:mm:ss.fff");
    }

    public static string ShowMatch(this string text, string expr)
    {
        MatchCollection mc = Regex.Matches(text, expr);
        string result = "";
        foreach (Match m in mc)
        {
            result += m.ToString() + "\n";
        }
        return result;
    }


    public static string ToDbNvarcharType(this object value, int? maxLength)
    {
        try
        {
            if (value.ToString().Contains("varchar"))
            {
                if (maxLength == -1)
                {
                    return value + " (max)";
                }
                else
                {
                    return value + " (" + maxLength / 2 + ")";
                }
            }
            else
            {
                return value.ToString();
            }

        }
        catch (Exception)
        {
            return value + " (max)";
        }
    }


    public static string ToDbNvarcharType(this object value, int? maxLength, bool? isNullable)
    {
        try
        {
            if (value.ToString().Contains("varchar"))
            {
                if (maxLength == -1)
                {
                    return value + " (max)";
                }
                else
                {
                    return value + " (" + maxLength / 2 + ")";
                }
            }
            else
            {
                return value.ToString();
            }

        }
        catch (Exception)
        {
            return value + " (max)";
        }
    }

    public static string ReturnNetType(this string type)
    {
        var _Type = MyConfiguration.Configuration.GetSection("Type").Value;
        var retVal = JsonConvert.DeserializeObject<List<DataTypeMapping>>(File.ReadAllText(_Type)).Where(a => a.SqlDbTypeEnumeration.ToLowerInvariant() == type).FirstOrDefault();
        if (retVal != null)
        {
            return retVal.NetFrameworkType;
        }
        else
        {
            return "string";
        }
    }

    public static string ReturnSqlType(this string type)
    {
        var _Type = MyConfiguration.Configuration.GetSection("Type").Value;
        var retVal = JsonConvert.DeserializeObject<List<DataTypeMapping>>(File.ReadAllText(_Type)).Where(a => a.NetFrameworkType.ToLowerInvariant() == type).FirstOrDefault();
        if (retVal != null)
        {
            return retVal.SqlDbTypeEnumeration;
        }
        else
        {
            return "nvarchar";
        }
    }

    public static string ReturnSqlTypeWithLength(this string type, int MaxLength = -1)
    {
        var _Type = MyConfiguration.Configuration.GetSection("Type").Value;
        var retVal = JsonConvert.DeserializeObject<List<DataTypeMapping>>(File.ReadAllText(_Type)).Where(a => a.NetFrameworkType.ToLowerInvariant() == type).FirstOrDefault();
        if (retVal != null)
        {
            if (MaxLength != -1)
            {
                return retVal.SqlDbTypeEnumeration + "(" + MaxLength + ")";
            }
            else
            {
                return retVal.SqlDbTypeEnumeration + "(max)";
            }

        }
        else
        {
            return "nvarchar " + "(max)";
        }
    }

    public static string ReturnType(string type, bool? sqlType, bool? isNullable = false)
    {
        if (sqlType == false)
        {
            if (type == "xml") return "Xml" + (isNullable == true ? "?" : "");
            if (type == "varchar") return "string" + (isNullable == true ? "" : "");
            if (type == "varbinary") return "byte[]" + (isNullable == true ? "?" : "");
            if (type == "uniqueidentifier") return "Guid" + (isNullable == true ? "?" : "");
            if (type == "tinyint") return "byte" + (isNullable == true ? "?" : "");
            if (type == "timestamp") return "byte[]" + (isNullable == true ? "?" : "");
            if (type == "time") return "TimeSpan" + (isNullable == true ? "?" : "");
            if (type == "text") return "string" + (isNullable == true ? "" : "");
            if (type == "sql_variant") return "object" + (isNullable == true ? "?" : "");
            if (type == "smallmoney") return "decimal" + (isNullable == true ? "?" : "");
            if (type == "smallint") return "small" + (isNullable == true ? "?" : "");
            if (type == "smalldatetime") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "rowversion") return "byte[]" + (isNullable == true ? "?" : "");
            if (type == "real") return "float" + (isNullable == true ? "?" : "");
            if (type == "nvarchar") return "string" + (isNullable == true ? "" : "");
            if (type == "numeric") return "decimal" + (isNullable == true ? "?" : "");
            if (type == "ntext") return "string" + (isNullable == true ? "" : "");
            if (type == "nchar") return "string" + (isNullable == true ? "" : "");
            if (type == "money") return "decimal" + (isNullable == true ? "?" : "");
            if (type == "int") return "int" + (isNullable == true ? "?" : "");
            if (type == "image") return "byte[]" + (isNullable == true ? "?" : "");
            if (type == "float") return "double" + (isNullable == true ? "?" : "");
            if (type == "varbinary(max)") return "byte[]" + (isNullable == true ? "?" : "");
            if (type == "decimal") return "decimal" + (isNullable == true ? "?" : "");
            if (type == "datetimeoffset") return "DateTimeOffset" + (isNullable == true ? "?" : "");
            if (type == "datetime2") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "datetime") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "date") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "char") return "string" + (isNullable == true ? "" : "");
            if (type == "bit") return "bool" + (isNullable == true ? "?" : "");
            if (type == "binary") return "byte[]" + (isNullable == true ? "?" : "");
            if (type == "bigint") return "long" + (isNullable == true ? "?" : "");

            return "string";
        }
        else if (sqlType == true)
        {
            if (type == "xml") return "SqlDbType.Xml";
            if (type == "varchar") return "SqlDbType.VarChar";
            if (type == "varbinary") return "SqlDbType.VarBinary";
            if (type == "uniqueidentifier") return "SqlDbType.UniqueIdentifier";
            if (type == "tinyint") return "SqlDbType.TinyInt";
            if (type == "timestamp") return "SqlDbType.Timestamp";
            if (type == "time") return "SqlDbType.Time";
            if (type == "text") return "SqlDbType.Text";
            if (type == "sql_variant") return "SqlDbType.Variant";
            if (type == "smallmoney") return "SqlDbType.SmallMoney";
            if (type == "smallint") return "SqlDbType.SmallInt";
            if (type == "smalldatetime") return "SqlDbType.DateTime";
            if (type == "rowversion") return "SqlDbType.Timestamp";
            if (type == "real") return "SqlDbType.Real";
            if (type == "nvarchar") return "SqlDbType.NVarChar";
            if (type == "numeric") return "SqlDbType.Decimal";
            if (type == "ntext") return "SqlDbType.NText";
            if (type == "nchar") return "SqlDbType.NChar";
            if (type == "money") return "SqlDbType.Money";
            if (type == "int") return "SqlDbType.Int";
            if (type == "image") return "SqlDbType.Binary";
            if (type == "float") return "SqlDbType.Float";
            if (type == "varbinary(max)") return "SqlDbType.VarBinary";
            if (type == "decimal") return "SqlDbType.Decimal";
            if (type == "datetimeoffset") return "SqlDbType.DateTimeOffset";
            if (type == "datetime2") return "SqlDbType.DateTime2";
            if (type == "datetime") return "SqlDbType.DateTime";
            if (type == "date") return "SqlDbType.Date 1";
            if (type == "char") return "SqlDbType.Char";
            if (type == "bit") return "SqlDbType.Bit";
            if (type == "binary") return "SqlDbType.VarBinary";
            if (type == "bigint") return "SqlDbType.BigInt";

            return "SqlDbType.NVarChar";
        }
        else
        {
            if (type == "xml") return "Xml" + (isNullable == true ? "?" : "");
            if (type == "varchar") return "String" + (isNullable == true ? "" : "");
            if (type == "varbinary") return "Bytes" + (isNullable == true ? "?" : "");
            if (type == "uniqueidentifier") return "Guid" + (isNullable == true ? "?" : "");
            if (type == "tinyint") return "Byte" + (isNullable == true ? "?" : "");
            if (type == "timestamp") return "Bytes" + (isNullable == true ? "?" : "");
            if (type == "time") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "text") return "String" + (isNullable == true ? "" : "");
            if (type == "sql_variant") return "Object" + (isNullable == true ? "?" : "");
            if (type == "smallmoney") return "Decimal" + (isNullable == true ? "?" : "");
            if (type == "smallint") return "Int16" + (isNullable == true ? "?" : "");
            if (type == "smalldatetime") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "rowversion") return "Bytes" + (isNullable == true ? "?" : "");
            if (type == "real") return "Single" + (isNullable == true ? "?" : "");
            if (type == "nvarchar") return "String" + (isNullable == true ? "" : "");
            if (type == "numeric") return "Decimal" + (isNullable == true ? "?" : "");
            if (type == "ntext") return "String" + (isNullable == true ? "" : "");
            if (type == "nchar") return "String" + (isNullable == true ? "" : "");
            if (type == "money") return "Decimal" + (isNullable == true ? "?" : "");
            if (type == "int") return "Int32" + (isNullable == true ? "?" : "");
            if (type == "image") return "Bytes" + (isNullable == true ? "?" : "");
            if (type == "float") return "Double" + (isNullable == true ? "?" : "");
            if (type == "varbinary(max)") return "Bytes" + (isNullable == true ? "?" : "");
            if (type == "decimal") return "Decimal" + (isNullable == true ? "?" : "");
            if (type == "datetimeoffset") return "DateTimeOffset" + (isNullable == true ? "?" : "");
            if (type == "datetime2") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "datetime") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "date") return "DateTime" + (isNullable == true ? "?" : "");
            if (type == "char") return "String" + (isNullable == true ? "" : "");
            if (type == "bit") return "Boolean" + (isNullable == true ? "?" : "");
            if (type == "binary") return "Bytes" + (isNullable == true ? "?" : "");
            if (type == "bigint") return "Int64" + (isNullable == true ? "?" : "");
            return "string";
        }

    }

    public static string ReturnType(DataTypeMapping Sqltype, bool isNullable = false)
    {

        var type = Sqltype.NetFrameworkType;
        if (type == "xml") return "Xml" + (isNullable == true ? "?" : "");
        if (type == "varchar") return "string" + (isNullable == true ? "" : "");
        if (type == "varbinary") return "byte[]" + (isNullable == true ? "?" : "");
        if (type == "uniqueidentifier") return "Guid" + (isNullable == true ? "?" : "");
        if (type == "tinyint") return "byte" + (isNullable == true ? "?" : "");
        if (type == "timestamp") return "byte[]" + (isNullable == true ? "?" : "");
        if (type == "time") return "TimeSpan" + (isNullable == true ? "?" : "");
        if (type == "text") return "string" + (isNullable == true ? "" : "");
        if (type == "sql_variant") return "object" + (isNullable == true ? "?" : "");
        if (type == "smallmoney") return "decimal" + (isNullable == true ? "?" : "");
        if (type == "smallint") return "small" + (isNullable == true ? "?" : "");
        if (type == "smalldatetime") return "DateTime" + (isNullable == true ? "?" : "");
        if (type == "rowversion") return "byte[]" + (isNullable == true ? "?" : "");
        if (type == "real") return "float" + (isNullable == true ? "?" : "");
        if (type == "nvarchar") return "string" + (isNullable == true ? "" : "");
        if (type == "numeric") return "decimal" + (isNullable == true ? "?" : "");
        if (type == "ntext") return "string" + (isNullable == true ? "" : "");
        if (type == "nchar") return "string" + (isNullable == true ? "" : "");
        if (type == "money") return "decimal" + (isNullable == true ? "?" : "");
        if (type == "int") return "int" + (isNullable == true ? "?" : "");
        if (type == "image") return "byte[]" + (isNullable == true ? "?" : "");
        if (type == "float") return "double" + (isNullable == true ? "?" : "");
        if (type == "varbinary(max)") return "byte[]" + (isNullable == true ? "?" : "");
        if (type == "decimal") return "decimal" + (isNullable == true ? "?" : "");
        if (type == "datetimeoffset") return "DateTimeOffset" + (isNullable == true ? "?" : "");
        if (type == "datetime2") return "DateTime" + (isNullable == true ? "?" : "");
        if (type == "datetime") return "DateTime" + (isNullable == true ? "?" : "");
        if (type == "date") return "DateTime" + (isNullable == true ? "?" : "");
        if (type == "char") return "string" + (isNullable == true ? "" : "");
        if (type == "bit") return "bool" + (isNullable == true ? "?" : "");
        if (type == "binary") return "byte[]" + (isNullable == true ? "?" : "");
        if (type == "bigint") return "long" + (isNullable == true ? "?" : "");
        else return "string";


    }


    public static string ClearTextFilter(this string value)
    {

        if (value != null)
        {
            value = value.Trim().ToLower();
            value = value.Replace("  ", "-");
            value = value.Replace(" ", "-");
            value = value.Replace("---", "-");
            value = value.Replace("--", "-");
            value = value.Replace("----", "-");
            value = value.Replace("ç", "c");
            value = value.Replace("ý", "i");
            value = value.Replace("ð", "g");
            value = value.Replace("ö", "o");
            value = value.Replace("þ", "s");
            value = value.Replace("ü", "u");
            value = value.Replace("Ç", "C");
            value = value.Replace("Ş", "s");
            value = value.Replace("ş", "s");
            value = value.Replace("I", "i");
            value = value.Replace("ı", "i");
            value = value.Replace("Ð", "G");
            value = value.Replace("Ö", "O");
            value = value.Replace("Ğ", "G");
            value = value.Replace("ğ", "g");
            value = value.Replace("Þ", "S");
            value = value.Replace("Ü", "U");
            value = value.Replace("İ", "i");
            value = value.Replace("?", "");
            value = value.Replace("...", "");
            value = value.Replace(" ", "-");
            value = value.Replace(",", "");
            value = value.Replace(".", "");
            value = value.Replace(";", "");
            value = value.Replace(":", "");
            value = value.Replace("/", "");
            value = value.Replace(@"\", "");
            value = value.Replace("(", "");
            value = value.Replace(")", "");
            value = value.Replace('"', '-');
            value = value.Replace("%", "");
            value = value.Replace("&", "");
            value = value.Replace("#", "");
            value = value.Replace("__", "");
            value = value.Replace("'", "");
            value = value.Replace("+", "");
            value = value.Replace("“", "");
            value = value.Replace("”", "");
            value = value.Replace("’", "");
            value = value.Replace("´", "");
            value = value.Replace("!", "");
            value = value.Replace(".", "");
            value = value.Replace(">", "");
            value = value.Replace("<", "");
            value = value.Replace("‘", "");
            value = value.Replace("’", "");
            value = value.Replace("â", "a");
            value = value.Replace("é", "e");
            value = value.Replace("|", "-");
            value = value.Replace("$", "dolar");
        }

        return value;
    }

    public static string ClearTextFilterDefault(this string value)
    {

        if (value != null)
        {
            value = value.Replace("  ", "-");
            value = value.Replace(" ", "-");
            value = value.Replace("---", "-");
            value = value.Replace("--", "-");
            value = value.Replace("----", "-");
            value = value.Replace("ç", "c");
            value = value.Replace("ý", "i");
            value = value.Replace("ð", "g");
            value = value.Replace("ö", "o");
            value = value.Replace("þ", "s");
            value = value.Replace("ü", "u");
            value = value.Replace("Ç", "C");
            value = value.Replace("Ş", "s");
            value = value.Replace("ş", "s");
            value = value.Replace("I", "i");
            value = value.Replace("ı", "i");
            value = value.Replace("Ð", "G");
            value = value.Replace("Ö", "O");
            value = value.Replace("Ğ", "G");
            value = value.Replace("ğ", "g");
            value = value.Replace("Þ", "S");
            value = value.Replace("Ü", "U");
            value = value.Replace("İ", "i");
            value = value.Replace("?", "");
            value = value.Replace("...", "");
            value = value.Replace(" ", "-");
            value = value.Replace(",", "");
            value = value.Replace(".", "");
            value = value.Replace(";", "");
            value = value.Replace(":", "");
            value = value.Replace("/", "");
            value = value.Replace(@"\", "");
            value = value.Replace("(", "");
            value = value.Replace(")", "");
            value = value.Replace('"', '-');
            value = value.Replace("%", "");
            value = value.Replace("&", "");
            value = value.Replace("#", "");
            value = value.Replace("__", "");
            value = value.Replace("'", "");
            value = value.Replace("+", "");
            value = value.Replace("“", "");
            value = value.Replace("”", "");
            value = value.Replace("’", "");
            value = value.Replace("´", "");
            value = value.Replace("!", "");
            value = value.Replace(".", "");
            value = value.Replace(">", "");
            value = value.Replace("<", "");
            value = value.Replace("‘", "");
            value = value.Replace("’", "");
            value = value.Replace("â", "a");
            value = value.Replace("é", "e");
            value = value.Replace("|", "-");
            value = value.Replace("$", "dolar");
        }

        return value;
    }


    public static string ClearTextFilterForJson(this string value)
    {

        if (value != null)
        {
            value = value.Trim().ToLowerInvariant();
            value = value.Replace("  ", "_");
            value = value.Replace(" ", "_");
            value = value.Replace("---", "_");
            value = value.Replace("--", "_");
            value = value.Replace("----", "_");
            value = value.Replace("ç", "c");
            value = value.Replace("ý", "i");
            value = value.Replace("ð", "g");
            value = value.Replace("ö", "o");
            value = value.Replace("þ", "s");
            value = value.Replace("ü", "u");
            value = value.Replace("Ç", "C");
            value = value.Replace("Ş", "s");
            value = value.Replace("ş", "s");
            value = value.Replace("I", "i");
            value = value.Replace("ı", "i");
            value = value.Replace("Ð", "G");
            value = value.Replace("Ö", "O");
            value = value.Replace("Ğ", "G");
            value = value.Replace("ğ", "g");
            value = value.Replace("Þ", "S");
            value = value.Replace("Ü", "U");
            value = value.Replace("İ", "i");
            value = value.Replace("?", "");
            value = value.Replace("...", "_");
            value = value.Replace(" ", "_");
            value = value.Replace(",", "_");
            value = value.Replace(".", "_");
            value = value.Replace(";", "_");
            value = value.Replace(":", "_");
            value = value.Replace("/", "_");
            value = value.Replace(@"\", "_");
            value = value.Replace("(", "_");
            value = value.Replace(")", "_");
            value = value.Replace('"', '_');
            value = value.Replace("%", "");
            value = value.Replace("&", "");
            value = value.Replace("#", "");
            value = value.Replace("__", "_");
            value = value.Replace("'", "");
            value = value.Replace("+", "");
            value = value.Replace("“", "");
            value = value.Replace("”", "");
            value = value.Replace("’", "");
            value = value.Replace("´", "");
            value = value.Replace("!", "");
            value = value.Replace(".", "_");
            value = value.Replace(">", "");
            value = value.Replace("<", "");
            value = value.Replace("‘", "");
            value = value.Replace("’", "");
            value = value.Replace("â", "a");
            value = value.Replace("é", "e");
            value = value.Replace("|", "-");
        }

        return value;
    }
    public static string SubString(this string value, int start, int end)
    {
        var resultText = value;
        try
        {


            if (value.Length > 300)
            {
                resultText = value.Substring(start, value.Length - end);
            }
            else
            {
                resultText = value;
            }


        }
        catch (Exception)
        {

            return resultText;
        }


        return resultText;

    }

}






