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
    public class UserTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public UserTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(UserType UserType)
    {
        try
        {
            return connection.Insert(UserType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(UserType UserType)
    {
        try
        {
       return  connection.Update(UserType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(UserType UserType)
        {
            try
            {
            return  connection.Delete<UserType>(UserType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<UserType> GetAll(){
            try
            {
                return connection.Query<UserType>("UserTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public UserType GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<UserType>("UserTypeGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<UserType> GetByName(string Name){
            try
            {
                return connection.Query<UserType>("UserTypeGetByName", new
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
