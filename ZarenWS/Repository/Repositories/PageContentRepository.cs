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
    public class PageContentRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PageContentRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PageContent PageContent)
    {
        try
        {
            return connection.Insert(PageContent);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PageContent PageContent)
    {
        try
        {
       return  connection.Update(PageContent);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PageContent PageContent)
        {
            try
            {
            return  connection.Delete<PageContent>(PageContent);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PageContent> GetAll(){
            try
            {
                return connection.Query<PageContent>("PageContentGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetByContents(string Contents){
            try
            {
                return connection.Query<PageContent>("PageContentGetByContents", new
                {
Contents = Contents
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetByCreateDate(DateTime CreateDate){
            try
            {
                return connection.Query<PageContent>("PageContentGetByCreateDate", new
                {
CreateDate = CreateDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PageContent GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<PageContent>("PageContentGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetByImage(string Image){
            try
            {
                return connection.Query<PageContent>("PageContentGetByImage", new
                {
Image = Image
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetByLanguageID(int LanguageID){
            try
            {
                return connection.Query<PageContent>("PageContentGetByLanguageID", new
                {
LanguageID = LanguageID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetByPageUrl(string PageUrl){
            try
            {
                return connection.Query<PageContent>("PageContentGetByPageUrl", new
                {
PageUrl = PageUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetBySubTitle(string SubTitle){
            try
            {
                return connection.Query<PageContent>("PageContentGetBySubTitle", new
                {
SubTitle = SubTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<PageContent>("PageContentGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetByTitle(string Title){
            try
            {
                return connection.Query<PageContent>("PageContentGetByTitle", new
                {
Title = Title
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContent> GetCreateDateBetween(DateTime CreateDateStart,DateTime CreateDateEnd){
            try
            {
                return connection.Query<PageContent>("PageContentGetCreateDateBetween", new
                {
CreateDateStart = CreateDateStart
,CreateDateEnd = CreateDateEnd
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
