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
public class PossibleQueryRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public PossibleQueryRepository()
    {
        strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(PossibleQuery PossibleQuery)
    {
        try
        {
            return connection.Insert(PossibleQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(PossibleQuery PossibleQuery)
    {
        try
        {
            return connection.Update(PossibleQuery);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(PossibleQuery PossibleQuery)
    {
        try
        {
            return connection.Delete<PossibleQuery>(PossibleQuery);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<PossibleQuery> GetAll()
    {
        try
        {
            return connection.Query<PossibleQuery>("PossibleQueryGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public PossibleQuery GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<PossibleQuery>("PossibleQueryGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<PossibleQuery> GetByQuery(string Query)
    {
        try
        {
            return connection.Query<PossibleQuery>("PossibleQueryGetByQuery", new
            {
                Query = Query
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
