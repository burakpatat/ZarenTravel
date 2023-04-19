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
    public class AspNetRoleClaimsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AspNetRoleClaimsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AspNetRoleClaims AspNetRoleClaims)
    {
        try
        {
            return connection.Insert(AspNetRoleClaims);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AspNetRoleClaims AspNetRoleClaims)
    {
        try
        {
       return  connection.Update(AspNetRoleClaims);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AspNetRoleClaims AspNetRoleClaims)
        {
            try
            {
            return  connection.Delete<AspNetRoleClaims>(AspNetRoleClaims);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AspNetRoleClaims> GetAll(){
            try
            {
                return connection.Query<AspNetRoleClaims>("AspNetRoleClaimsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetRoleClaims> GetByClaimType(string ClaimType){
            try
            {
                return connection.Query<AspNetRoleClaims>("AspNetRoleClaimsGetByClaimType", new
                {
ClaimType = ClaimType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetRoleClaims> GetByClaimValue(string ClaimValue){
            try
            {
                return connection.Query<AspNetRoleClaims>("AspNetRoleClaimsGetByClaimValue", new
                {
ClaimValue = ClaimValue
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AspNetRoleClaims GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AspNetRoleClaims>("AspNetRoleClaimsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetRoleClaims> GetByRoleId(string RoleId){
            try
            {
                return connection.Query<AspNetRoleClaims>("AspNetRoleClaimsGetByRoleId", new
                {
RoleId = RoleId
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
