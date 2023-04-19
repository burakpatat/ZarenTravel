using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Web;
using System.Web.Security;
using Model.Concrete;

/// <summary>
/// Summary description for SiteBasePage
/// </summary>
public class SiteBasePage : System.Web.UI.Page
{
    private HttpContext _httpContext = HttpContext.Current;

    public SiteBasePage()
    {
        _httpContext = HttpContext.Current;
    }

    protected override void OnInit(EventArgs e)
    {
       
        _httpContext.Response.AppendHeader("X-XSS-Protection", "0; mode=block");
        _httpContext.Response.AppendHeader("Strict-Transport-Security", "max-age=16070400; includeSubDomains");
        _httpContext.Response.AppendHeader("X-Content-Type-Options", "nosniff");
        _httpContext.Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
        _httpContext.Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
        _httpContext.Response.AppendHeader("Expires", "0");
        if (Request.Cookies.Count > 0)
        {
            foreach (string s in Request.Cookies.AllKeys)
            {
                if (s == FormsAuthentication.FormsCookieName || s == "ASP.NET_SessionId")
                {
                    Response.Cookies[s].Secure = true;
                }
            }
        }
        Form.Action = Request.RawUrl.InjectionFilter();
        Response.TrySkipIisCustomErrors = true;
        //if (!Request.Url.Host.StartsWith("www") && !Request.Url.IsLoopback)
        //{
        //    UriBuilder builder = new UriBuilder(Request.Url.ToString().Replace("default.aspx", "anasayfa"));
        //    builder.Host = "www." + Request.Url.Host;
        //    Response.StatusCode = 301;
        //    Response.AddHeader("Location", builder.ToString());
        //    Response.End();
        //}
       
        base.OnInit(e);
    }
    
    public static int DefaultLanguage()
    {
        if (HttpContext.Current.Request.QueryString["l"] == null)
        {
            return 1;
        }
        else
        {
            return HttpContext.Current.Request.QueryString["l"].ToInt32();
        }

    }
     

    //public static string Resources(int ID)
    //{
    //    var lang = DefaultLanguage();
    //    var resources = new ResourcesRepository();
    //    var value = resources.GetByIDByLanguage(ID, lang).FirstOrDefault();
    //    if (value != null)
    //    {
    //        return value.text;
    //    }
    //    else
    //    {
    //        return "";
    //    }



    //}
    //public static string R(int ID)
    //{
    //    var lang = DefaultLanguage();
    //    var resources = new ResourcesRepository();
    //    var value = resources.GetByIDByLanguage(ID, lang).FirstOrDefault();
    //    if (value != null)
    //    {
    //        return value.text;
    //    }
    //    else
    //    {
    //        return "";
    //    }



    //}
    //public static string Resources(int ID, int langID)
    //{

    //    var resources = new ResourcesRepository();
    //    var value = resources.GetByIDByLanguage(ID, langID).FirstOrDefault();
    //    if (value != null)
    //    {
    //        return value.text;
    //    }
    //    else
    //    {
    //        return "";
    //    }



    //}

}