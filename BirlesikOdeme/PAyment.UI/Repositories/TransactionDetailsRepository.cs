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
    public class TransactionDetailsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public TransactionDetailsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(TransactionDetails TransactionDetails)
    {
        try
        {
            return connection.Insert(TransactionDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(TransactionDetails TransactionDetails)
    {
        try
        {
       return  connection.Update(TransactionDetails);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(TransactionDetails TransactionDetails)
        {
            try
            {
            return  connection.Delete<TransactionDetails>(TransactionDetails);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<TransactionDetails> GetAll(){
            try
            {
                return connection.Query<TransactionDetails>("TransactionDetailsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TransactionDetails> GetByCardHolderNameSurname(string CardHolderNameSurname){
            try
            {
                return connection.Query<TransactionDetails>("TransactionDetailsGetByCardHolderNameSurname", new
                {
CardHolderNameSurname = CardHolderNameSurname
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TransactionDetails> GetByCardNumber(string CardNumber){
            try
            {
                return connection.Query<TransactionDetails>("TransactionDetailsGetByCardNumber", new
                {
CardNumber = CardNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public TransactionDetails GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<TransactionDetails>("TransactionDetailsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TransactionDetails> GetByIP(string IP){
            try
            {
                return connection.Query<TransactionDetails>("TransactionDetailsGetByIP", new
                {
IP = IP
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TransactionDetails> GetByTransactionId(int TransactionId){
            try
            {
                return connection.Query<TransactionDetails>("TransactionDetailsGetByTransactionId", new
                {
TransactionId = TransactionId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TransactionDetails> GetByUserAgent(string UserAgent){
            try
            {
                return connection.Query<TransactionDetails>("TransactionDetailsGetByUserAgent", new
                {
UserAgent = UserAgent
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
