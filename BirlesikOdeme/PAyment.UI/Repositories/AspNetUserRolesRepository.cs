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
    public class AspNetUserRolesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AspNetUserRolesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AspNetUserRoles AspNetUserRoles)
    {
        try
        {
            return connection.Insert(AspNetUserRoles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AspNetUserRoles AspNetUserRoles)
    {
        try
        {
       return  connection.Update(AspNetUserRoles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AspNetUserRoles AspNetUserRoles)
        {
            try
            {
            return  connection.Delete<AspNetUserRoles>(AspNetUserRoles);
            }
            catch (Exception)
            {
                return false;
            }
        }
 public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
    }
