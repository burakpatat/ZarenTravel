using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
public class DatabaseStoredProceduresRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public DatabaseStoredProceduresRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(Method DatabaseStoredProcedures)
    {
        try
        {
            return connection.Insert(DatabaseStoredProcedures);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(Method DatabaseStoredProcedures)
    {
        try
        {
            return connection.Update(DatabaseStoredProcedures);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(Method DatabaseStoredProcedures)
    {
        try
        {
            return connection.Delete<Method>(DatabaseStoredProcedures);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public Method GetByID(int ID)
    {
        try
        {
            return connection.QueryFirstOrDefault<Method>("DatabaseStoredProceduresGetByID", new
            {
                ID = ID
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Method> GetAll()
    {
        try
        {
            return connection.Query<Method>("DatabaseStoredProceduresGetAll", commandType: CommandType.StoredProcedure).ToList();

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
