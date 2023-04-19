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
    public class FlightFeesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FlightFeesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FlightFees FlightFees)
    {
        try
        {
            return connection.Insert(FlightFees);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FlightFees FlightFees)
    {
        try
        {
       return  connection.Update(FlightFees);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FlightFees FlightFees)
        {
            try
            {
            return  connection.Delete<FlightFees>(FlightFees);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FlightFees> GetAll(){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetByApiId(int ApiId){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FlightFees GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FlightFees>("FlightFeesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetByKeys(string Keys){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetByKeys", new
                {
Keys = Keys
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetByOneRoundMultiWaysId(int OneRoundMultiWaysId){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetByOneRoundMultiWaysId", new
                {
OneRoundMultiWaysId = OneRoundMultiWaysId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightFees> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<FlightFees>("FlightFeesGetCreatedDateBetween", new
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
