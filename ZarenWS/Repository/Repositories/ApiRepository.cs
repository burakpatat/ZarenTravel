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
    public class ApiRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ApiRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Api Api)
    {
        try
        {
            return connection.Insert(Api);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Api Api)
    {
        try
        {
       return  connection.Update(Api);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Api Api)
        {
            try
            {
            return  connection.Delete<Api>(Api);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Api> GetAll(){
            try
            {
                return connection.Query<Api>("ApiGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Api> GetByName(string ApiName){
            try
            {
                return connection.Query<Api>("ApiGetByApiName", new
                {
ApiName = ApiName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Api GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Api>("ApiGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Api> GetByPassword(string Password){
            try
            {
                return connection.Query<Api>("ApiGetByPassword", new
                {
Password = Password
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Api> GetByUserKey(string UserKey){
            try
            {
                return connection.Query<Api>("ApiGetByUserKey", new
                {
UserKey = UserKey
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
