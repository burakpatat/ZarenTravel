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
public class AutoCompleteTypesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public AutoCompleteTypesRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(AutoCompleteTypesRepository AutoCompleteTypes)
    {
        try
        {
            return connection.Insert(AutoCompleteTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(AutoCompleteTypesRepository AutoCompleteTypes)
    {
        try
        {
            return connection.Update(AutoCompleteTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(AutoCompleteTypesRepository AutoCompleteTypes)
    {
        try
        {
            return connection.Delete<AutoCompleteTypesRepository>(AutoCompleteTypes);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<AutoCompleteTypesRepository> GetAll()
    {
        try
        {
            return connection.Query<AutoCompleteTypesRepository>("AutoCompleteTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public AutoCompleteTypesRepository GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<AutoCompleteTypesRepository>("AutoCompleteTypesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AutoCompleteTypesRepository> GetByName(string Name)
    {
        try
        {
            return connection.Query<AutoCompleteTypesRepository>("AutoCompleteTypesGetByName", new
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
