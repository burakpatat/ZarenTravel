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
    public class ApiResultsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ApiResultsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ApiResults ApiResults)
    {
        try
        {
            return connection.Insert(ApiResults);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ApiResults ApiResults)
    {
        try
        {
       return  connection.Update(ApiResults);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ApiResults ApiResults)
        {
            try
            {
            return  connection.Delete<ApiResults>(ApiResults);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ApiResults> GetAll(){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByApiId(int ApiId){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByCheckIn(string CheckIn){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByCheckIn", new
                {
CheckIn = CheckIn
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByCurrency(string Currency){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByCurrency", new
                {
Currency = Currency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ApiResults GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<ApiResults>("ApiResultsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByIsSuccessfull(bool IsSuccessfull){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByIsSuccessfull", new
                {
IsSuccessfull = IsSuccessfull
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByLocationId(int LocationId){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByLocationId", new
                {
LocationId = LocationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByNationality(string Nationality){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByNationality", new
                {
Nationality = Nationality
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByProductType(int ProductType){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByProductType", new
                {
ProductType = ProductType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByQuery(string Query){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByQuery", new
                {
Query = Query
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByRequestData(string RequestData){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByRequestData", new
                {
RequestData = RequestData
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByRequestDate(DateTime RequestDate){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByRequestDate", new
                {
RequestDate = RequestDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByResponseData(string ResponseData){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByResponseData", new
                {
ResponseData = ResponseData
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetByResponseDate(DateTime ResponseDate){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetByResponseDate", new
                {
ResponseDate = ResponseDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetRequestDateBetween(DateTime RequestDateStart,DateTime RequestDateEnd){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetRequestDateBetween", new
                {
RequestDateStart = RequestDateStart
,RequestDateEnd = RequestDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ApiResults> GetResponseDateBetween(DateTime ResponseDateStart,DateTime ResponseDateEnd){
            try
            {
                return connection.Query<ApiResults>("ApiResultsGetResponseDateBetween", new
                {
ResponseDateStart = ResponseDateStart
,ResponseDateEnd = ResponseDateEnd
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
