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
    public class PaymentLogsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PaymentLogsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PaymentLogs PaymentLogs)
    {
        try
        {
            return connection.Insert(PaymentLogs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PaymentLogs PaymentLogs)
    {
        try
        {
       return  connection.Update(PaymentLogs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PaymentLogs PaymentLogs)
        {
            try
            {
            return  connection.Delete<PaymentLogs>(PaymentLogs);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PaymentLogs> GetAll(){
            try
            {
                return connection.Query<PaymentLogs>("PaymentLogsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PaymentLogs GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PaymentLogs>("PaymentLogsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentLogs> GetByRequest(string Request){
            try
            {
                return connection.Query<PaymentLogs>("PaymentLogsGetByRequest", new
                {
Request = Request
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentLogs> GetByRequestDate(DateTime RequestDate){
            try
            {
                return connection.Query<PaymentLogs>("PaymentLogsGetByRequestDate", new
                {
RequestDate = RequestDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentLogs> GetByResponse(string Response){
            try
            {
                return connection.Query<PaymentLogs>("PaymentLogsGetByResponse", new
                {
Response = Response
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentLogs> GetByResponseDate(DateTime ResponseDate){
            try
            {
                return connection.Query<PaymentLogs>("PaymentLogsGetByResponseDate", new
                {
ResponseDate = ResponseDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentLogs> GetByTransactionId(int TransactionId){
            try
            {
                return connection.Query<PaymentLogs>("PaymentLogsGetByTransactionId", new
                {
TransactionId = TransactionId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentLogs> GetRequestDateBetween(DateTime RequestDateStart,DateTime RequestDateEnd){
            try
            {
                return connection.Query<PaymentLogs>("PaymentLogsGetRequestDateBetween", new
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
public List<PaymentLogs> GetResponseDateBetween(DateTime ResponseDateStart,DateTime ResponseDateEnd){
            try
            {
                return connection.Query<PaymentLogs>("PaymentLogsGetResponseDateBetween", new
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
