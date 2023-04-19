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
    public class YesNoRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public YesNoRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(YesNo YesNo)
    {
        try
        {
            return connection.Insert(YesNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(YesNo YesNo)
    {
        try
        {
       return  connection.Update(YesNo);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(YesNo YesNo)
        {
            try
            {
            return  connection.Delete<YesNo>(YesNo);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<YesNo> GetAll(){
            try
            {
                return connection.Query<YesNo>("YesNoGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public YesNo GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<YesNo>("YesNoGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<YesNo> GetByName(string Name){
            try
            {
                return connection.Query<YesNo>("YesNoGetByName", new
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
