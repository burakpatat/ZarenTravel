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
    public class CurrencyRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CurrencyRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Currency Currency)
    {
        try
        {
            return connection.Insert(Currency);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Currency Currency)
    {
        try
        {
       return  connection.Update(Currency);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Currency Currency)
        {
            try
            {
            return  connection.Delete<Currency>(Currency);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Currency> GetAll(){
            try
            {
                return connection.Query<Currency>("CurrencyGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetByActive(bool CurrencyActive){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCurrencyActive", new
                {
CurrencyActive = CurrencyActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetByCode(string CurrencyCode){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCurrencyCode", new
                {
CurrencyCode = CurrencyCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetByCodeIata(string CurrencyCodeIata){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCurrencyCodeIata", new
                {
CurrencyCodeIata = CurrencyCodeIata
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetByName(string CurrencyName){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCurrencyName", new
                {
CurrencyName = CurrencyName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetByTimestamp(DateTime CurrencyTimestamp){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCurrencyTimestamp", new
                {
CurrencyTimestamp = CurrencyTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Currency GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Currency>("CurrencyGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetTimestampBetween(DateTime CurrencyTimestampStart,DateTime CurrencyTimestampEnd){
            try
            {
                return connection.Query<Currency>("CurrencyGetCurrencyTimestampBetween", new
                {
CurrencyTimestampStart = CurrencyTimestampStart
,CurrencyTimestampEnd = CurrencyTimestampEnd
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
