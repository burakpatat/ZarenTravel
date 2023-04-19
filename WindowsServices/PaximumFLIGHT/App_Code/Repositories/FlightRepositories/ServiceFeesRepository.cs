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
    public class ServiceFeesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ServiceFeesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ServiceFees ServiceFees)
    {
        try
        {
            return connection.Insert(ServiceFees);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ServiceFees ServiceFees)
    {
        try
        {
       return  connection.Update(ServiceFees);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ServiceFees ServiceFees)
        {
            try
            {
            return  connection.Delete<ServiceFees>(ServiceFees);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ServiceFees> GetAll(){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ServiceFees> GetByAmount(double Amount){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ServiceFees> GetByApiId(int ApiId){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ServiceFees> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ServiceFees> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ServiceFees> GetByCurrenciesId(int CurrenciesId){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetByCurrenciesId", new
                {
CurrenciesId = CurrenciesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ServiceFees GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<ServiceFees>("ServiceFeesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ServiceFees> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ServiceFees> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ServiceFees> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<ServiceFees>("ServiceFeesGetCreatedDateBetween", new
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
