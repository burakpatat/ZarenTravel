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
    public class AspNetRolesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AspNetRolesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AspNetRoles AspNetRoles)
    {
        try
        {
            return connection.Insert(AspNetRoles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AspNetRoles AspNetRoles)
    {
        try
        {
       return  connection.Update(AspNetRoles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AspNetRoles AspNetRoles)
        {
            try
            {
            return  connection.Delete<AspNetRoles>(AspNetRoles);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AspNetRoles> GetAll(){
            try
            {
                return connection.Query<AspNetRoles>("AspNetRolesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetRoles> GetByConcurrencyStamp(string ConcurrencyStamp){
            try
            {
                return connection.Query<AspNetRoles>("AspNetRolesGetByConcurrencyStamp", new
                {
ConcurrencyStamp = ConcurrencyStamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AspNetRoles GetByID(string Id){
            try
            {
                return connection.QueryFirstOrDefault<AspNetRoles>("AspNetRolesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetRoles> GetByName(string Name){
            try
            {
                return connection.Query<AspNetRoles>("AspNetRolesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AspNetRoles> GetByNormalizedName(string NormalizedName){
            try
            {
                return connection.Query<AspNetRoles>("AspNetRolesGetByNormalizedName", new
                {
NormalizedName = NormalizedName
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
