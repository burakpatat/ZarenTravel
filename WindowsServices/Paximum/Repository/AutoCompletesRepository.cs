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
public class AutoCompletesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public AutoCompletesRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(AutoCompletes AutoCompletes)
    {
        try
        {
            return connection.Insert(AutoCompletes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(AutoCompletes AutoCompletes)
    {
        try
        {
            return connection.Update(AutoCompletes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(AutoCompletes AutoCompletes)
    {
        try
        {
            return connection.Delete<AutoCompletes>(AutoCompletes);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<AutoCompletes> GetAll()
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByApiId(int ApiId)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByApiId", new
            {
                ApiId = ApiId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByApiSystemId(string ApiSystemId)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByApiSystemId", new
            {
                ApiSystemId = ApiSystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public AutoCompletes GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<AutoCompletes>("AutoCompletesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByName(string Name)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByName", new
            {
                Name = Name
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompletes> GetByType(int Type)
    {
        try
        {
            return connection.Query<AutoCompletes>("AutoCompletesGetByType", new
            {
                Type = Type
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
