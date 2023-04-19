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
public class AspNetUserTokensRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public AspNetUserTokensRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetSection("ConnectionString").Value;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(AspNetUserTokens AspNetUserTokens)
    {
        try
        {
            return connection.Insert(AspNetUserTokens);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(AspNetUserTokens AspNetUserTokens)
    {
        try
        {
            return connection.Update(AspNetUserTokens);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(AspNetUserTokens AspNetUserTokens)
    {
        try
        {
            return connection.Delete<AspNetUserTokens>(AspNetUserTokens);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<AspNetUserTokens> GetAll()
    {
        try
        {
            return connection.Query<AspNetUserTokens>("AspNetUserTokensGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public AspNetUserTokens GetByID(string UserId)
    {
        try
        {
            return connection.QueryFirstOrDefault<AspNetUserTokens>("AspNetUserTokensGetByID", new
            {
                UserId = UserId
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUserTokens> GetByValue(string Value)
    {
        try
        {
            return connection.Query<AspNetUserTokens>("AspNetUserTokensGetByValue", new
            {
                Value = Value
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
