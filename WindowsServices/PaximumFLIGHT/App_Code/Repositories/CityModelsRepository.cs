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
    public class CityModelsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CityModelsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CityModels CityModels)
    {
        try
        {
            return connection.Insert(CityModels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CityModels CityModels)
    {
        try
        {
       return  connection.Update(CityModels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CityModels CityModels)
        {
            try
            {
            return  connection.Delete<CityModels>(CityModels);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CityModels> GetAll(){
            try
            {
                return connection.Query<CityModels>("CityModelsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CityModels> GetByCityName(string CityName){
            try
            {
                return connection.Query<CityModels>("CityModelsGetByCityName", new
                {
CityName = CityName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CityModels GetByID(int CityId){
            try
            {
                return connection.QueryFirstOrDefault<CityModels>("CityModelsGetByID", new
                {
CityId = CityId
                }, commandType: CommandType.StoredProcedure);

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
