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
public List<Currency> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Currency>("CurrencyGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetByCreateBy(int CreateBy){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCreateBy", new
                {
CreateBy = CreateBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetByCreated(DateTime Created){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCreated", new
                {
Created = Created
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetByActşve(bool CurrencyActşve){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCurrencyActşve", new
                {
CurrencyActşve = CurrencyActşve
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
public List<Currency> GetByTimeStamp(DateTime CurrencyTimeStamp){
            try
            {
                return connection.Query<Currency>("CurrencyGetByCurrencyTimeStamp", new
                {
CurrencyTimeStamp = CurrencyTimeStamp
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
public List<Currency> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Currency>("CurrencyGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetCreatedBetween(DateTime CreatedStart,DateTime CreatedEnd){
            try
            {
                return connection.Query<Currency>("CurrencyGetCreatedBetween", new
                {
CreatedStart = CreatedStart
,CreatedEnd = CreatedEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Currency> GetTimeStampBetween(DateTime CurrencyTimeStampStart,DateTime CurrencyTimeStampEnd){
            try
            {
                return connection.Query<Currency>("CurrencyGetCurrencyTimeStampBetween", new
                {
CurrencyTimeStampStart = CurrencyTimeStampStart
,CurrencyTimeStampEnd = CurrencyTimeStampEnd
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
