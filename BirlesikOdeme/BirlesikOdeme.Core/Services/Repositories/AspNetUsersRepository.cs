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
public class AspNetUsersRepository : IDisposable
{
    private SqlConnection connection;
    private readonly string strConnString;
    public AspNetUsersRepository(IConfiguration configuration)
    {
        strConnString = configuration.GetSection("ConnectionString").Value;
        connection = new SqlConnection(strConnString);
    }
    public long Insert(AspNetUsers AspNetUsers)
    {
        try
        {
            return connection.Insert(AspNetUsers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Update(AspNetUsers AspNetUsers)
    {
        try
        {
            return connection.Update(AspNetUsers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public bool Delete(AspNetUsers AspNetUsers)
    {
        try
        {
            return connection.Delete<AspNetUsers>(AspNetUsers);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public List<AspNetUsers> GetAll()
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetAll", commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByAccessFailedCount(int AccessFailedCount)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByAccessFailedCount", new
            {
                AccessFailedCount = AccessFailedCount
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByConcurrencyStamp(string ConcurrencyStamp)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByConcurrencyStamp", new
            {
                ConcurrencyStamp = ConcurrencyStamp
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByEmail(string Email)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByEmail", new
            {
                Email = Email
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByEmailConfirmed(bool EmailConfirmed)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByEmailConfirmed", new
            {
                EmailConfirmed = EmailConfirmed
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public AspNetUsers GetByID(string Id)
    {
        try
        {
            return connection.QueryFirstOrDefault<AspNetUsers>("AspNetUsersGetByID", new
            {
                Id = Id
            }, commandType: CommandType.StoredProcedure);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByLockoutEnabled(bool LockoutEnabled)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByLockoutEnabled", new
            {
                LockoutEnabled = LockoutEnabled
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByLockoutEnd(DateTimeOffset LockoutEnd)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByLockoutEnd", new
            {
                LockoutEnd = LockoutEnd
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByNormalizedEmail(string NormalizedEmail)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByNormalizedEmail", new
            {
                NormalizedEmail = NormalizedEmail
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByNormalizedUserName(string NormalizedUserName)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByNormalizedUserName", new
            {
                NormalizedUserName = NormalizedUserName
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByPasswordHash(string PasswordHash)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByPasswordHash", new
            {
                PasswordHash = PasswordHash
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByPhoneNumber(string PhoneNumber)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByPhoneNumber", new
            {
                PhoneNumber = PhoneNumber
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByPhoneNumberConfirmed(bool PhoneNumberConfirmed)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByPhoneNumberConfirmed", new
            {
                PhoneNumberConfirmed = PhoneNumberConfirmed
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetBySecurityStamp(string SecurityStamp)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetBySecurityStamp", new
            {
                SecurityStamp = SecurityStamp
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByTwoFactorEnabled(bool TwoFactorEnabled)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByTwoFactorEnabled", new
            {
                TwoFactorEnabled = TwoFactorEnabled
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetByUserName(string UserName)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetByUserName", new
            {
                UserName = UserName
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<AspNetUsers> GetLockoutEndBetween(DateTimeOffset LockoutEndStart, DateTimeOffset LockoutEndEnd)
    {
        try
        {
            return connection.Query<AspNetUsers>("AspNetUsersGetLockoutEndBetween", new
            {
                LockoutEndStart = LockoutEndStart
,
                LockoutEndEnd = LockoutEndEnd
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
