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
    public class AirPortTaxsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AirPortTaxsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AirPortTaxs AirPortTaxs)
    {
        try
        {
            return connection.Insert(AirPortTaxs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AirPortTaxs AirPortTaxs)
    {
        try
        {
       return  connection.Update(AirPortTaxs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AirPortTaxs AirPortTaxs)
        {
            try
            {
            return  connection.Delete<AirPortTaxs>(AirPortTaxs);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AirPortTaxs> GetAll(){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPortTaxs> GetByAmount(double Amount){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPortTaxs> GetByApiId(int ApiId){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPortTaxs> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPortTaxs> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPortTaxs> GetByCurrenciesId(int CurrenciesId){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetByCurrenciesId", new
                {
CurrenciesId = CurrenciesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AirPortTaxs GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AirPortTaxs>("AirPortTaxsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPortTaxs> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPortTaxs> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPortTaxs> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AirPortTaxs>("AirPortTaxsGetCreatedDateBetween", new
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
