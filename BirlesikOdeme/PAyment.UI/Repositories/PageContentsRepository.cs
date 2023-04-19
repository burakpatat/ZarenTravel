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
    public class PageContentsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PageContentsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PageContents PageContents)
    {
        try
        {
            return connection.Insert(PageContents);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PageContents PageContents)
    {
        try
        {
       return  connection.Update(PageContents);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PageContents PageContents)
        {
            try
            {
            return  connection.Delete<PageContents>(PageContents);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PageContents> GetAll(){
            try
            {
                return connection.Query<PageContents>("PageContentsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContents> GetByContents(string Contents){
            try
            {
                return connection.Query<PageContents>("PageContentsGetByContents", new
                {
Contents = Contents
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PageContents> GetByContentTitle(string ContentTitle){
            try
            {
                return connection.Query<PageContents>("PageContentsGetByContentTitle", new
                {
ContentTitle = ContentTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PageContents GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PageContents>("PageContentsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

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
