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
using Microsoft.Extensions.Hosting;

public class ResourcesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;

    public ResourcesRepository()
    {
        connection = new SqlConnection("Server=mssql02.trwww.com;Connection Timeout=30;Persist Security Info=False;TrustServerCertificate=True;User ID=zaren;Password=#Id7y82x6;Initial Catalog=zaren_test");
    }
    public ResourcesRepository(IConfiguration configuration)
    {

        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }
    public long Insert(Resources Resources)
    {
        try
        {
            return connection.Insert(Resources);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(Resources Resources)
    {
        try
        {
            return connection.Update(Resources);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(Resources Resources)
    {
        try
        {
            return connection.Delete<Resources>(Resources);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<Resources> GetAll()
    {
        try
        {
            return connection.Query<Resources>("ResourcesGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public Resources GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<Resources>("ResourcesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Resources> GetByLanguageCode(string LanguageCode)
    {
        try
        {
            return connection.Query<Resources>("ResourcesGetByLanguageCode", new
            {
                LanguageCode = LanguageCode
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Resources> GetByResourceKey(string ResourceKey)
    {
        try
        {
            return connection.Query<Resources>("ResourcesGetByResourceKey", new
            {
                ResourceKey = ResourceKey
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Resources> GetByResourceValue(string ResourceValue)
    {
        try
        {
            return connection.Query<Resources>("ResourcesGetByResourceValue", new
            {
                ResourceValue = ResourceValue
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
