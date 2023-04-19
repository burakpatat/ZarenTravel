using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SqlInjectionControl
/// </summary>
public static class SqlInjectionControl
{

    /// <summary>
    /// Sql ınjection saldırılarına karşı yazılmıs metot.deger içerisinde ki güvenli olmayan ifadeleri temizler
    /// </summary>
    /// <param name="val"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string InjectionFilter(this string value)
    {
        string result = null;
        if (value != null)
        {
            result = value.Replace("delete", " ");
            result = value.Replace("update", " ");
            result = value.Replace("from", " ");
            result = value.Replace("where", " ");
            result = value.Replace("drop", " ");
            result = value.Replace("truncate", " ");
            result = value.Replace("insert", " ");
            result = value.Replace("create", " ");
            result = value.Replace("select", " ");
            result = value.Replace("javascript", " ");
            result = value.Replace("alert", " ");
            result = value.Replace("acustart", " ");
            result = value.Replace("acuend", " ");
            result = value.Replace("create", " ");
            result = value.Replace(";", " ");
            result = value.Replace("'", " ");
            result = value.Replace("--", " ");
            result = value.Replace("*", " ");
            result = value.Replace("/", " ");
            result = value.Replace("(", " ");
            result = value.Replace(")", " ");
            result = value.Replace("script", " ");
            result = value.Replace("<", " ");
            result = value.Replace(">", " ");
            result = value.Replace("?", " ");
            result = value.Replace("true", " ");
            result = value.Replace("false", " ");
            result = value.Replace("into", " ");
            result = value.Replace(" in ", " ");
            result = value.Replace("table", " ");
            result = value.Replace("union", " ");
        }
        return result;
    }

}