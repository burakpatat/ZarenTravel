using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

/// <summary>
/// MoneyFormatter için özet açıklama
/// </summary>

public static class MoneyFormatters {

public static string GetStrMoney(this string digit)
{
   
    string afterPoint = string.Empty;
    string strDigit = digit;
    int pos = digit.IndexOf('.');
    if (digit.IndexOf('.') != -1)
    {
        strDigit = digit.Substring(0, pos);
        afterPoint = digit.Substring(pos, digit.Length - pos);
    }
 
    int len = strDigit.Length;
    if (len <= 3)
        return digit;
 
    strDigit = strDigit.ReverseString();
    string result = string.Empty;
    for (int i = 0; i < len; i++)
    {
        result += strDigit[i];
        if ((i + 1) % 3 == 0 && i != len - 1)
            result += ',';
    }
 
    if (string.IsNullOrEmpty(afterPoint))
        result = result.ReverseString();
    else result = result.ReverseString() + afterPoint;
    return result;
}
 
public static string ReverseString(this string s)
{
    char[] c = s.ToCharArray();
    string ts = string.Empty;
 
    for (int i = c.Length - 1; i >= 0; i--)
        ts += c[i].ToString();
 
    return ts;
}

    public static string ToTuskishDecimal(this string value)
    {
        value = value.Replace(".", "");
        if (null == value)
            return null; // or throw exception, or return "0,00" or return "?"

        try
        {
            return Convert
             .ToDecimal(value, CultureInfo.InvariantCulture)
             .ToString("N", CultureInfo.GetCultureInfo("tr-TR"));
        }
        catch (FormatException)
        {
            return "0,00"; // or "?"
        }
    }
}

