using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
public class DatabaseColumnTypesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public DatabaseColumnTypesRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(DatabaseColumnTypes DatabaseColumnTypes)
    {
        try
        {
            return connection.Insert(DatabaseColumnTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(DatabaseColumnTypes DatabaseColumnTypes)
    {
        try
        {
            return connection.Update(DatabaseColumnTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(DatabaseColumnTypes DatabaseColumnTypes)
    {
        try
        {
            return connection.Delete<DatabaseColumnTypes>(DatabaseColumnTypes);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public DatabaseColumnTypes GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<DatabaseColumnTypes>("DatabaseColumnTypesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<DatabaseColumnTypes> GetAll()
    {
        try
        {
            return connection.Query<DatabaseColumnTypes>("DatabaseColumnTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

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
