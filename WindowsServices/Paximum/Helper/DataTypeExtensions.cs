using System;
using System.Threading;

public static class DataTypeExtensions2
{
    public static bool ToBool(this object value)
    {
        try
        {
            if (value != null)
                return Boolean.Parse(value.ToString());
            else
                return new Boolean();

        }
        catch (Exception)
        {
            return new Boolean();
        }
    }

    public static byte ToByte(this string value)
    {
        try
        {
            return Byte.Parse(value);
        }
        catch (Exception)
        {
            return new Byte();
        }
    }



    public static Char ToChar(this string value)
    {
        try
        {
            return Convert.ToChar(value);
        }
        catch (Exception)
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
        catch (Exception)
        {
            return new Decimal();
        }
    }
    public static Decimal ToDecimal(this int value)
    {
        return value.ToString().ToDecimal();
    }

    public static Double ToDouble(this string value)
    {
        try
        {
            return Double.Parse(value);
        }
        catch (Exception)
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
        catch (Exception)
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
        catch (Exception)
        {
            return new Int16();
        }
    }

    public static Int32 ToInt32(this object value)
    {
        try
        {
            if (value==null) 
                return 0; 
            return Int32.Parse(value.ToString());
        }
        catch (Exception)
        {
            return new Int32();
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
    public static Int64 ToInt64(this object value)
    {
        try
        {
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
}
