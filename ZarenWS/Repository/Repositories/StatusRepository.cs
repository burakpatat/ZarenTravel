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
    public class StatusRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public StatusRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Status Status)
    {
        try
        {
            return connection.Insert(Status);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Status Status)
    {
        try
        {
       return  connection.Update(Status);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Status Status)
        {
            try
            {
            return  connection.Delete<Status>(Status);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Status> GetAll(){
            try
            {
                return connection.Query<Status>("StatusGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Status GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Status>("StatusGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Status> GetByName(string Name){
            try
            {
                return connection.Query<Status>("StatusGetByName", new
                {
Name = Name
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
