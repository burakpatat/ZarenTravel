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
public class AspNetUserLoginsRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public AspNetUserLoginsRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetSection("ConnectionString").Value;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(AspNetUserLogins AspNetUserLogins)
    {
        try
        {
            return connection.Insert(AspNetUserLogins);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(AspNetUserLogins AspNetUserLogins)
    {
        try
        {
            return connection.Update(AspNetUserLogins);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(AspNetUserLogins AspNetUserLogins)
    {
        try
        {
            return connection.Delete<AspNetUserLogins>(AspNetUserLogins);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<AspNetUserLogins> GetAll()
    {
        try
        {
            return connection.Query<AspNetUserLogins>("AspNetUserLoginsGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public AspNetUserLogins GetByID(string LoginProvider)
    {
        try
        {
            return connection.QueryFirstOrDefault<AspNetUserLogins>("AspNetUserLoginsGetByID", new
            {
                LoginProvider = LoginProvider
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUserLogins> GetByProviderDisplayName(string ProviderDisplayName)
    {
        try
        {
            return connection.Query<AspNetUserLogins>("AspNetUserLoginsGetByProviderDisplayName", new
            {
                ProviderDisplayName = ProviderDisplayName
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUserLogins> GetByUserId(string UserId)
    {
        try
        {
            return connection.Query<AspNetUserLogins>("AspNetUserLoginsGetByUserId", new
            {
                UserId = UserId
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
