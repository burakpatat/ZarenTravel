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
    public class GenderRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public GenderRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Gender Gender)
    {
        try
        {
            return connection.Insert(Gender);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Gender Gender)
    {
        try
        {
       return  connection.Update(Gender);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Gender Gender)
        {
            try
            {
            return  connection.Delete<Gender>(Gender);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Gender> GetAll(){
            try
            {
                return connection.Query<Gender>("GenderGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Gender GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Gender>("GenderGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Gender> GetByName(string Name){
            try
            {
                return connection.Query<Gender>("GenderGetByName", new
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
