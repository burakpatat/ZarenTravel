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
    public class DatabaseValueTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DatabaseValueTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(DatabaseValueTypes DatabaseValueTypes)
    {
        try
        {
            return connection.Insert(DatabaseValueTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(DatabaseValueTypes DatabaseValueTypes)
    {
        try
        {
       return  connection.Update(DatabaseValueTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(DatabaseValueTypes DatabaseValueTypes)
        {
            try
            {
            return  connection.Delete<DatabaseValueTypes>(DatabaseValueTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<DatabaseValueTypes> GetAll(){
            try
            {
                return connection.Query<DatabaseValueTypes>("DatabaseValueTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseValueTypes> GetByFrontEndName(string FrontEndName){
            try
            {
                return connection.Query<DatabaseValueTypes>("DatabaseValueTypesGetByFrontEndName", new
                {
FrontEndName = FrontEndName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public DatabaseValueTypes GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<DatabaseValueTypes>("DatabaseValueTypesGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseValueTypes> GetBySqlName(string SqlName){
            try
            {
                return connection.Query<DatabaseValueTypes>("DatabaseValueTypesGetBySqlName", new
                {
SqlName = SqlName
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
