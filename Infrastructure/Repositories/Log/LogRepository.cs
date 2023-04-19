using Model.Concrete;
using System;
using System.Data.SqlClient;
using System.Web;

/// <summary>
/// Summary description for LogRepository
/// </summary>
public class LogRepository : IDisposable
{
    private SqlConnection con;
    private readonly string strConnString;

    public static readonly string IMAGE_RESIZE_MESSAGE = "Görsel Ölçülendir";

    public static readonly string INSERT_SUCCESS = "ERROR ON INSERT";
    public static readonly string ERROR_HEADER_MESSAGE = "ERROR ON UPDATE";
    public static readonly string SUCCESS_HEADER_MESSAGE = "UPDATE SUCCESSFULL";
    public static readonly string UPDATE_BUTTON_TEXT = "UPDATE";
    public static readonly string DELETE_BUTTON_TEXT = "DELETE";
    public static readonly string SAVE_BUTTON_TEXT = "SAVE";
    public static readonly string SAVE_NEW = "CREATE ROW";
    public static readonly string MODAL_DELETE_MESSAGE = "Silinen veriler geri getirilemez.<br />Seçili içeriği silmek istediğinize emin misiniz?";
    public static readonly string MODAL_DELETE_HEADER_MESSAGE = "DELETE INFO";
    public static readonly string MODAL_YES_TEXT = "YES";
    public static readonly string MODAL_CANCEL_TEXT = "CANCEL";

    public static readonly string IMAGE_DELETE_ERROR = "Silerken sorun oluştu";
    public static readonly string UPDATE_SUCCESS = "İçerik başarıyla güncellendi!";
    public static readonly string UPDATE_ERROR = " numaralı içerik güncellenirken hata oluştu: ";
    public static readonly string INSERTSUCCESS = "İçerik başarıyla eklendi.";
    public static readonly string CLICK_TO_SEE = "Yüklü Dosyayı Görüntülemek için tıklayın";
    public static readonly string NO_FILE = "Yüklü Bir Dosya Bulunmuyor";

    public static readonly string EXCEL_BUTTON_TEXT = "Yüklü Bir Dosya Bulunmuyor";
    public static readonly string EVENTS = "FUNCTIONS";
    public static readonly string SELECT_TEXT = "Seçiniz";
    public static readonly string SELECT_VALUE = "0";
    public static readonly string DELETE_SUCCESS = "İçerik başarılı bir şekilde silindi";
    public static readonly string DELETE_SUCCESS_HEADER = "İşlem Başarılı";
    public static readonly string DELETE_ERROR_HEADER = "İşlem Hatalı";
    public static readonly string NO_FILE7 = "Yüklü Bir Dosya Bulunmuyor";
    public static readonly string NO_FILE8 = "Yüklü Bir Dosya Bulunmuyor";
    public static readonly string NO_FILE9 = "Yüklü Bir Dosya Bulunmuyor";

    protected string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        if (context != null)
        {
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipAddress != null)
            {


                if (!string.IsNullOrEmpty(ipAddress))
                {
                    string[] addresses = ipAddress.Split(',');
                    if (addresses.Length != 0)
                    {
                        return addresses[0];
                    }
                }

                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            { return ""; }
        }
        else
        { return ""; }

    }
    public void Insert(LogTable LogTable, bool ToJSONPath = true)
    {
        try
        {
            // con = new SqlConnection(strConnString);
            try
            {
                LogTable.UserID = 0;
                //var user = new LoginRepository().GetLoginUser();
                //if (user != null)
                //    LogTable.UserID = user.ID;
                //else
                //    LogTable.UserID = 0;
            }
            catch
            {
                LogTable.UserID = 0;
            }
            LogTable.Date = DateTime.Now;

            if (HttpContext.Current != null)
            {
                LogTable.UserAgent = "IP: " + GetIPAddress() + " " + HttpContext.Current.Request.UserAgent;
                LogTable.UserHostAddress = HttpContext.Current.Request.UserHostAddress;
                LogTable.UrlOriginalString = HttpContext.Current.Request.Url.OriginalString;
            }
            //if (ToJSONPath)
            new GenerateHelper().ExecuteLogging(LogTable.Serialize(), LogTable.LogMethod);
            //else
            //    con.Insert(LogTable);
        }
        catch (Exception ex)
        {
            new GenerateHelper().ExecuteLogging(ex.Serialize() + LogTable.Serialize(), LogTable.LogMethod);
        }

    }

    public bool Insert(string tableName, int? ID = 0)
    {
        Insert(new LogTable { Description = tableName + "detail.aspx sayfası görüntülendi. ID=" + ID.ToString() + "  ", LogMethod = tableName + "GetByID ", LogPath = tableName + "detail.aspx ", Type = (short)LogType.View, UserAgent = " " });
        return true;
    }

    public bool InsertParam(string tableName, int? ID = 0)
    {
        Insert(new LogTable { Description = "  " + ID.ToInt32() + "Inserted ID:" + ID, LogMethod = tableName + "Insert ", LogPath = tableName + "detail.aspx ", Type = (short)LogType.Insert, UserAgent = " " });
        return true;
    }

    public bool DetailInsertSuccess(string tableName, int? ID)
    {
        Insert(new LogTable { Description = "  " + ID + " ID'li içerik eklendi", LogMethod = tableName + "Insert ", LogPath = tableName + "detail.aspx ", Type = (short)LogType.Insert, UserAgent = " " });
        return true;
    }

    public bool DetailInsertException(Exception ex, string tableName)
    {
        Insert(new LogTable { Description = "insert Exception: " + ex.Message, LogMethod = tableName + "Insert ", LogPath = tableName + "detail.aspx ", Type = (short)LogType.Error, UserAgent = " " });

        return true;
    }

    public bool DeleteSuccess(string tableName, int? ID = 0)
    {
        Insert(new LogTable { Description = tableName + "deleted: " + ID, LogMethod = tableName + "Delete", LogPath = tableName + "listV2.aspx", Type = (short)LogType.Delete, UserAgent = " " });
        return true;
    }

    public bool DeleteException(Exception ex, string tableName, int? id)
    {
        Insert(new LogTable { Description = id + " delete Exception: " + ex.Message, LogMethod = tableName + "Delete", LogPath = tableName + "listV2.aspx", Type = (short)LogType.Error, UserAgent = " " });
        return true;
    }


    public bool UpdateSuccess(string tableName, int? ID = 0)
    {
        Insert(new LogTable { Description = ID + " update", LogMethod = tableName + "Update", LogPath = tableName + "detailV2.aspx", Type = (short)LogType.Update, UserAgent = " " });
        return true;
    }
    public bool UpdateDetailError(string tableName, int? ID = 0)
    {
        Insert(new LogTable { Description = ID + " update error", LogMethod = tableName + "Update", LogPath = tableName + "detailV2.aspx", Type = (short)LogType.Update, UserAgent = " " });
        return true;
    }
    public bool UpdateException(Exception ex, string tableName, int? ID)
    {
        Insert(new LogTable { Description = ID + " update Exception: " + ex.Message, LogMethod = tableName + "Update", LogPath = tableName + "detailV2.aspx ", Type = (short)LogType.Error, UserAgent = " " });
        return true;
    }
    public bool ListPageLoad(string tableName)
    {
        Insert(new LogTable { Description = tableName + "listV2.aspx", LogMethod = tableName + "GetAll", LogPath = tableName + "listV2.aspx ", Type = (short)LogType.GetList, UserAgent = " " });

        return true;
    }
    public bool DetailPageLoad(string tableName, int? ID = 0)
    {
        Insert(new LogTable { Description = tableName + "detailV2.aspx ID:" + ID, LogMethod = tableName + "GetByID", LogPath = tableName + "detailV2.aspx ", Type = (short)LogType.View, UserAgent = " " });
        return true;
    }
    public bool DetailPageLoadError(Exception ex, string tableName, int? ID)
    {
        Insert(new LogTable { Description = ID + " detail error: " + ex.Message, LogMethod = tableName + "GetByID", LogPath = tableName + "detailV2.aspx ", Type = (short)LogType.Error, UserAgent = " " });
        return true;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
