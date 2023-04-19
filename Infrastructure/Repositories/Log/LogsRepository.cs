using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
public class LogsRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public LogsRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(Logs Logs)
    {
        try
        {
            return connection.Insert(Logs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(Logs Logs)
    {
        try
        {
            return connection.Update(Logs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(Logs Logs)
    {
        try
        {
            return connection.Delete<Logs>(Logs);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<Logs> GetAll()
    {
        try
        {
            return connection.Query<Logs>("LogsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Logs> GetOne(int ID)
    {
        try
        {
            return connection.Query<Logs>("LogsGetOne", new
            {
                ID = ID
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Logs GetByID(int ID)
    {
        try
        {
            return connection.QueryFirstOrDefault<Logs>("LogsGetByID", new
            {
                ID = ID
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
