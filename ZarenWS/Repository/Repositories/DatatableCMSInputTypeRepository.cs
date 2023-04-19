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
    public class DatatableCMSInputTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DatatableCMSInputTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(DatatableCMSInputType DatatableCMSInputType)
    {
        try
        {
            return connection.Insert(DatatableCMSInputType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(DatatableCMSInputType DatatableCMSInputType)
    {
        try
        {
       return  connection.Update(DatatableCMSInputType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(DatatableCMSInputType DatatableCMSInputType)
        {
            try
            {
            return  connection.Delete<DatatableCMSInputType>(DatatableCMSInputType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<DatatableCMSInputType> GetAll(){
            try
            {
                return connection.Query<DatatableCMSInputType>("DatatableCMSInputTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public DatatableCMSInputType GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<DatatableCMSInputType>("DatatableCMSInputTypeGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatatableCMSInputType> GetByName(string Name){
            try
            {
                return connection.Query<DatatableCMSInputType>("DatatableCMSInputTypeGetByName", new
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
