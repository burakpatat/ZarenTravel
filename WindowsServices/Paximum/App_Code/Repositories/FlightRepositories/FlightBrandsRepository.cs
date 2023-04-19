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
    public class FlightBrandsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FlightBrandsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FlightBrands FlightBrands)
    {
        try
        {
            return connection.Insert(FlightBrands);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FlightBrands FlightBrands)
    {
        try
        {
       return  connection.Update(FlightBrands);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FlightBrands FlightBrands)
        {
            try
            {
            return  connection.Delete<FlightBrands>(FlightBrands);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FlightBrands> GetAll(){
            try
            {
                return connection.Query<FlightBrands>("FlightBrandsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightBrands> GetByApiId(int ApiId){
            try
            {
                return connection.Query<FlightBrands>("FlightBrandsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightBrands> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<FlightBrands>("FlightBrandsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightBrands> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<FlightBrands>("FlightBrandsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FlightBrands GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FlightBrands>("FlightBrandsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightBrands> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<FlightBrands>("FlightBrandsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightBrands> GetByName(string Name){
            try
            {
                return connection.Query<FlightBrands>("FlightBrandsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightBrands> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<FlightBrands>("FlightBrandsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightBrands> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<FlightBrands>("FlightBrandsGetCreatedDateBetween", new
                {
CreatedDateStart = CreatedDateStart
,CreatedDateEnd = CreatedDateEnd
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
