using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


public static class StringExtentions
{
    public static string ToStr(this object obj)
    {
        if (obj != null)
            return obj.ToString();
        else
            return "";
    }

    public static int ToInt(this object obj)
    {
        try
        {
            if (obj != null)
                return Convert.ToInt32(obj);
            else
                return 0;
        }
        catch
        {
            return 0;
        }
    }

    public static int? ToNullbleInt(this object obj)
    {
        try
        {
            if (obj != null)
                return Convert.ToInt32(obj);
            else
                return null;
        }
        catch
        {
            return null;
        }
    }

    public static long? ToNullbleInt64(this object obj)
    {
        try
        {
            if (obj != null)
                return Convert.ToInt64(obj);
            else
                return null;
        }
        catch
        {
            return null;
        }
    }



    public static Guid? ToGuid(this string obj)
    {
        try
        {
            if (obj != null)
                return Guid.Parse(obj);
            else
                return null;
        }
        catch
        {
            return null;
        }
    }


    public static string ReplaceDecimalChar(this object obj)
    {
        try
        {
            if (obj != null)
                return obj.ToString().Replace(".", ",");
            else
                return null;
        }
        catch
        {
            return null;
        }
    }

    #region IsNotNull

    /// <summary>
    ///     Determines if the object is not null
    /// </summary>
    /// <param name="objectToCall">The object to check</param>
    /// <returns>False if it is null, true otherwise</returns>
    public static bool IsNotNull(this object objectToCall)
    {
        return !objectToCall.IsNull();
    }

    #endregion IsNotNull

    #region IsNull

    /// <summary>
    ///     Determines if the object is null
    /// </summary>
    /// <param name="objectToCall">The object to check</param>
    /// <returns>True if it is null, false otherwise</returns>
    public static bool IsNull(this object objectToCall)
    {
        return objectToCall == null || Convert.IsDBNull(objectToCall);
    }

    #endregion IsNull

    #region IsNotDefault

    public static bool IsNotNullAndNotDefault(this object objectToCall)
    {
        return !objectToCall.IsNull() && !EqualityComparer<object>.Default.Equals(objectToCall.ToInt64(), default(long));
    }

    #endregion IsNotDefault

    #region IsNotNullOrEmpty

    /// <summary>
    ///     Determines if a list is not null or empty
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    /// <param name="value">List to check</param>
    /// <returns>True if it is not null or empty, false otherwise</returns>
    public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> value)
    {
        return !value.IsNullOrEmpty();
    }

    #endregion IsNotNullOrEmpty

    #region IsNullOrEmpty

    /// <summary>
    ///     Determines if a list is null or empty
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    /// <param name="value">List to check</param>
    /// <returns>True if it is null or empty, false otherwise</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
    {
        return value.IsNull() || !value.Any();
    }

    #endregion IsNullOrEmpty

    #region IsNullOrWhiteSpace

    /// <summary>
    ///     Checks if it is null or whitespace
    /// </summary>
    /// <param name="str1"></param>
    /// <returns></returns>
    public static bool IsNullOrWhiteSpace(this string str1)
    {
        var temp1 = !string.IsNullOrWhiteSpace(str1) ? str1.Trim() : null;
        return string.IsNullOrWhiteSpace(temp1);
    }

    #endregion IsNullOrWhiteSpace

    #region IsNotNullOrNotWhiteSpace

    /// <summary>
    ///     Checks if it is not null or not whitespace
    /// </summary>
    /// <param name="str1"></param>
    /// <returns></returns>
    public static bool IsNotNullOrNotWhiteSpace(this string str1)
    {
        var temp1 = !string.IsNullOrWhiteSpace(str1) ? str1.Trim() : null;
        return !string.IsNullOrWhiteSpace(temp1);
    }

    #endregion IsNotNullOrNotWhiteSpace
}
