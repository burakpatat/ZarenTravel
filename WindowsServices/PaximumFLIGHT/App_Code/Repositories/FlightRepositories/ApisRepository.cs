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
    public class ApisRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ApisRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Apis Apis)
    {
        try
        {
            return connection.Insert(Apis);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Apis Apis)
    {
        try
        {
       return  connection.Update(Apis);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Apis Apis)
        {
            try
            {
            return  connection.Delete<Apis>(Apis);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Apis> GetAll(){
            try
            {
                return connection.Query<Apis>("ApisGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Apis> GetByApiName(string ApiName){
            try
            {
                return connection.Query<Apis>("ApisGetByApiName", new
                {
ApiName = ApiName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Apis GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Apis>("ApisGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Apis> GetByPassword(string Password){
            try
            {
                return connection.Query<Apis>("ApisGetByPassword", new
                {
Password = Password
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Apis> GetByUserKey(string UserKey){
            try
            {
                return connection.Query<Apis>("ApisGetByUserKey", new
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
