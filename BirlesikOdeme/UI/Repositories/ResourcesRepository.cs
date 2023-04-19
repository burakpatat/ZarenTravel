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
using Microsoft.Extensions.Configuration;
public class ResourcesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    private IConfiguration configuration;

    public ResourcesRepository()
    {
        strConnString = configuration.GetSection("ConnectionString").Value;
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
    public List<Resources> GetByLanguageId(int LanguageId)
    {
        try
        {
            return connection.Query<Resources>("ResourcesGetByLanguageId", new
            {
                LanguageId = LanguageId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Resources> GetBySourceKey(string SourceKey)
    {
        try
        {
            return connection.Query<Resources>("ResourcesGetBySourceKey", new
            {
                SourceKey = SourceKey
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Resources> GetBySourceValue(string SourceValue)
    {
        try
        {
            return connection.Query<Resources>("ResourcesGetBySourceValue", new
            {
                SourceValue = SourceValue
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
