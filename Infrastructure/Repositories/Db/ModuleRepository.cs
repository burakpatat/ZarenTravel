using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Model.Concrete;
using Dapper.Contrib.Extensions;
public class ModuleRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public ModuleRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(Module Module)
    {
        try
        {
            return connection.Insert(Module);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(Module Module)
    {
        try
        {
            return connection.Update(Module);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(Module Module)
    {
        try
        {
            return connection.Delete<Module>(Module);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public Module GetByID(int ID)
    {
        try
        {
            return connection.QueryFirstOrDefault<Module>("ModuleGetByID", new
            {
                ID = ID
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Module> GetOne(int ID)
    {
        try
        {
            return connection.Query<Module>("ModuleGetOne", new
            {
                ID = ID
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Module> GetAll()
    {
        try
        {
            return connection.Query<Module>("ModuleGetAll", commandType: CommandType.StoredProcedure).ToList();

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
