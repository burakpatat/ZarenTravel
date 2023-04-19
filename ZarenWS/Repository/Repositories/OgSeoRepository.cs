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
    public class OgSeoRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public OgSeoRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(OgSeo OgSeo)
    {
        try
        {
            return connection.Insert(OgSeo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(OgSeo OgSeo)
    {
        try
        {
       return  connection.Update(OgSeo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(OgSeo OgSeo)
        {
            try
            {
            return  connection.Delete<OgSeo>(OgSeo);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<OgSeo> GetAll(){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public OgSeo GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<OgSeo>("OgSeoGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OgSeo> GetByogDescription(string ogDescription){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetByogDescription", new
                {
ogDescription = ogDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OgSeo> GetByogImage(string ogImage){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetByogImage", new
                {
ogImage = ogImage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OgSeo> GetByogTitle(string ogTitle){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetByogTitle", new
                {
ogTitle = ogTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OgSeo> GetByPageID(int PageID){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetByPageID", new
                {
PageID = PageID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OgSeo> GetByPageType(int PageType){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetByPageType", new
                {
PageType = PageType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OgSeo> GetByseoDescription(string seoDescription){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetByseoDescription", new
                {
seoDescription = seoDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OgSeo> GetByseoKeyword(string seoKeyword){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetByseoKeyword", new
                {
seoKeyword = seoKeyword
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OgSeo> GetByseoTitle(string seoTitle){
            try
            {
                return connection.Query<OgSeo>("OgSeoGetByseoTitle", new
                {
seoTitle = seoTitle
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
