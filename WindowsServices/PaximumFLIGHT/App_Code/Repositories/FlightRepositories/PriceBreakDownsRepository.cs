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
    public class PriceBreakDownsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PriceBreakDownsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PriceBreakDowns PriceBreakDowns)
    {
        try
        {
            return connection.Insert(PriceBreakDowns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PriceBreakDowns PriceBreakDowns)
    {
        try
        {
       return  connection.Update(PriceBreakDowns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PriceBreakDowns PriceBreakDowns)
        {
            try
            {
            return  connection.Delete<PriceBreakDowns>(PriceBreakDowns);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PriceBreakDowns> GetAll(){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByAirportTaxAmount(double AirportTaxAmount){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByAirportTaxAmount", new
                {
AirportTaxAmount = AirportTaxAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByAirportTaxCurrencyId(int AirportTaxCurrencyId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByAirportTaxCurrencyId", new
                {
AirportTaxCurrencyId = AirportTaxCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByAmount(double Amount){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByApiId(int ApiId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PriceBreakDowns GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PriceBreakDowns>("PriceBreakDownsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByOffersId(int OffersId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByOffersId", new
                {
OffersId = OffersId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByPassengerCount(int PassengerCount){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByPassengerCount", new
                {
PassengerCount = PassengerCount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetByPassengerTypeId(int PassengerTypeId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetByPassengerTypeId", new
                {
PassengerTypeId = PassengerTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PriceBreakDowns> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<PriceBreakDowns>("PriceBreakDownsGetCreatedDateBetween", new
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
