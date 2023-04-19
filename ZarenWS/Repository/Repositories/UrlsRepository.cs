using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
    public class UrlsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public UrlsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Urls Urls)
    {
        try
        {
            return connection.Insert(Urls);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Urls Urls)
    {
        try
        {
       return  connection.Update(Urls);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Urls Urls)
        {
            try
            {
            return  connection.Delete<Urls>(Urls);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Urls> GetAll(){
            try
            {
                return connection.Query<Urls>("UrlsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Urls> GetByFriendlyUrl(string FriendlyUrl){
            try
            {
                return connection.Query<Urls>("UrlsGetByFriendlyUrl", new
                {
FriendlyUrl = FriendlyUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Urls GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Urls>("UrlsGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Urls> GetByIsDefault(int IsDefault){
            try
            {
                return connection.Query<Urls>("UrlsGetByIsDefault", new
                {
IsDefault = IsDefault
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Urls> GetByLanguageID(int LanguageID){
            try
            {
                return connection.Query<Urls>("UrlsGetByLanguageID", new
                {
LanguageID = LanguageID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Urls> GetByPageID(int PageID){
            try
            {
                return connection.Query<Urls>("UrlsGetByPageID", new
                {
PageID = PageID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Urls> GetByPageName(string PageName){
            try
            {
                return connection.Query<Urls>("UrlsGetByPageName", new
                {
PageName = PageName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Urls> GetByPageView(int PageView){
            try
            {
                return connection.Query<Urls>("UrlsGetByPageView", new
                {
PageView = PageView
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
    }
