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
    public class ExchangeRatesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ExchangeRatesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ExchangeRates ExchangeRates)
    {
        try
        {
            return connection.Insert(ExchangeRates);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ExchangeRates ExchangeRates)
    {
        try
        {
       return  connection.Update(ExchangeRates);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ExchangeRates ExchangeRates)
        {
            try
            {
            return  connection.Delete<ExchangeRates>(ExchangeRates);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ExchangeRates> GetAll(){
            try
            {
                return connection.Query<ExchangeRates>("ExchangeRatesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExchangeRates> GetByCurrencyIdFrom(int CurrencyIdFrom){
            try
            {
                return connection.Query<ExchangeRates>("ExchangeRatesGetByCurrencyIdFrom", new
                {
CurrencyIdFrom = CurrencyIdFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExchangeRates> GetByCurrencyIdTo(int CurrencyIdTo){
            try
            {
                return connection.Query<ExchangeRates>("ExchangeRatesGetByCurrencyIdTo", new
                {
CurrencyIdTo = CurrencyIdTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExchangeRates> GetByExRaActive(bool ExRaActive){
            try
            {
                return connection.Query<ExchangeRates>("ExchangeRatesGetByExRaActive", new
                {
ExRaActive = ExRaActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExchangeRates> GetByExRaDate(DateTime ExRaDate){
            try
            {
                return connection.Query<ExchangeRates>("ExchangeRatesGetByExRaDate", new
                {
ExRaDate = ExRaDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExchangeRates> GetByExRaTimestamp(int ExRaTimestamp){
            try
            {
                return connection.Query<ExchangeRates>("ExchangeRatesGetByExRaTimestamp", new
                {
ExRaTimestamp = ExRaTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExchangeRates> GetByExRaValue(decimal ExRaValue){
            try
            {
                return connection.Query<ExchangeRates>("ExchangeRatesGetByExRaValue", new
                {
ExRaValue = ExRaValue
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ExchangeRates GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<ExchangeRates>("ExchangeRatesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExchangeRates> GetExRaDateBetween(DateTime ExRaDateStart,DateTime ExRaDateEnd){
            try
            {
                return connection.Query<ExchangeRates>("ExchangeRatesGetExRaDateBetween", new
                {
ExRaDateStart = ExRaDateStart
,ExRaDateEnd = ExRaDateEnd
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
