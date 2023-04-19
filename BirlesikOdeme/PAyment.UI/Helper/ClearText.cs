using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClearText
/// </summary>
public static class ClearText
{

    /// <summary>
    /// Url Rewriting için türkçe krakterleri temızler
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
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
            value = value.Replace("@", "");
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
            value = value.Replace("@", "");
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
            value = value.Replace("_", "-");
        }
        if (value.Length>50)
        {
          return  value.SubString(0,50);
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
            value = value.Replace("@", "");
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


            if (value.Length > end)
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