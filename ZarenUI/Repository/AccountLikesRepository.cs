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
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using ZarenUI.Models;

public class AccountLikesRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public AccountLikesRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetConnectionString("ZarenTravel");
        connection = new SqlConnection(strConnString);
    }
    public long Insert(AccountLikes AccountLikes)
    {
        try
        {
            return connection.Insert(AccountLikes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(AccountLikes AccountLikes)
    {
        try
        {
            return connection.Update(AccountLikes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(AccountLikes AccountLikes)
    {
        try
        {
            return connection.Delete<AccountLikes>(AccountLikes);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<AccountLikes> GetAll()
    {
        try
        {
            return connection.Query<AccountLikes>("AccountLikesGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AccountLikes> GetByCookieId(string CookieId)
    {
        try
        {
            return connection.Query<AccountLikes>("AccountLikesGetByCookieId", new
            {
                CookieId = CookieId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AccountLikes> GetByCreatedDate(DateTime CreatedDate)
    {
        try
        {
            return connection.Query<AccountLikes>("AccountLikesGetByCreatedDate", new
            {
                CreatedDate = CreatedDate
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public AccountLikes GetByID(int Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<AccountLikes>("AccountLikesGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AccountLikes> GetByIsActive(bool IsActive)
    {
        try
        {
            return connection.Query<AccountLikes>("AccountLikesGetByIsActive", new
            {
                IsActive = IsActive
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AccountLikes> GetByProductId(string ProductId)
    {
        try
        {
            return connection.Query<AccountLikes>("AccountLikesGetByProductId", new
            {
                ProductId = ProductId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AccountLikes> GetByProductType(int ProductType)
    {
        try
        {
            return connection.Query<AccountLikes>("AccountLikesGetByProductType", new
            {
                ProductType = ProductType
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AccountLikes> GetByUserId(string UserId)
    {
        try
        {
            return connection.Query<AccountLikes>("AccountLikesGetByUserId", new
            {
                UserId = UserId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AccountLikes> GetCreatedDateBetween(DateTime CreatedDateStart, DateTime CreatedDateEnd)
    {
        try
        {
            return connection.Query<AccountLikes>("AccountLikesGetCreatedDateBetween", new
            {
                CreatedDateStart = CreatedDateStart
,
                CreatedDateEnd = CreatedDateEnd
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
