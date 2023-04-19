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
    public class PricesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PricesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Prices Prices)
    {
        try
        {
            return connection.Insert(Prices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Prices Prices)
    {
        try
        {
       return  connection.Update(Prices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Prices Prices)
        {
            try
            {
            return  connection.Delete<Prices>(Prices);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Prices> GetAll(){
            try
            {
                return connection.Query<Prices>("PricesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Prices>("PricesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetByAmount(decimal Amount){
            try
            {
                return connection.Query<Prices>("PricesGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Prices>("PricesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Prices>("PricesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Prices>("PricesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<Prices>("PricesGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Prices GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Prices>("PricesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Prices>("PricesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Prices>("PricesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Prices>("PricesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Prices> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Prices>("PricesGetCreatedDateBetween", new
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
