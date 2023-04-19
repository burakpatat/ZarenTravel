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
    public class StatuRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public StatuRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Statu Statu)
    {
        try
        {
            return connection.Insert(Statu);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Statu Statu)
    {
        try
        {
       return  connection.Update(Statu);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Statu Statu)
        {
            try
            {
            return  connection.Delete<Statu>(Statu);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Statu> GetAll(){
            try
            {
                return connection.Query<Statu>("StatuGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Statu GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Statu>("StatuGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Statu> GetByName(string Name){
            try
            {
                return connection.Query<Statu>("StatuGetByName", new
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
