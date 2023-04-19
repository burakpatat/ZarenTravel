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
    public class AspNetUserClaimsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AspNetUserClaimsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AspNetUserClaims AspNetUserClaims)
    {
        try
        {
            return connection.Insert(AspNetUserClaims);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AspNetUserClaims AspNetUserClaims)
    {
        try
        {
       return  connection.Update(AspNetUserClaims);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AspNetUserClaims AspNetUserClaims)
        {
            try
            {
            return  connection.Delete<AspNetUserClaims>(AspNetUserClaims);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AspNetUserClaims> GetAll(){
            try
            {
                return connection.Query<AspNetUserClaims>("AspNetUserClaimsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetUserClaims> GetByClaimType(string ClaimType){
            try
            {
                return connection.Query<AspNetUserClaims>("AspNetUserClaimsGetByClaimType", new
                {
ClaimType = ClaimType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetUserClaims> GetByClaimValue(string ClaimValue){
            try
            {
                return connection.Query<AspNetUserClaims>("AspNetUserClaimsGetByClaimValue", new
                {
ClaimValue = ClaimValue
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AspNetUserClaims GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AspNetUserClaims>("AspNetUserClaimsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetUserClaims> GetByUserId(string UserId){
            try
            {
                return connection.Query<AspNetUserClaims>("AspNetUserClaimsGetByUserId", new
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
