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
    public class AgencyCreditDepositRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyCreditDepositRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyCreditDeposit AgencyCreditDeposit)
    {
        try
        {
            return connection.Insert(AgencyCreditDeposit);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyCreditDeposit AgencyCreditDeposit)
    {
        try
        {
       return  connection.Update(AgencyCreditDeposit);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyCreditDeposit AgencyCreditDeposit)
        {
            try
            {
            return  connection.Delete<AgencyCreditDeposit>(AgencyCreditDeposit);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyCreditDeposit> GetAll(){
            try
            {
                return connection.Query<AgencyCreditDeposit>("AgencyCreditDepositGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCreditDeposit> GetByAgencyBalanceWarningAmount(decimal AgencyBalanceWarningAmount){
            try
            {
                return connection.Query<AgencyCreditDeposit>("AgencyCreditDepositGetByAgencyBalanceWarningAmount", new
                {
AgencyBalanceWarningAmount = AgencyBalanceWarningAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCreditDeposit> GetByAgencyBalanceWarningCurrencyId(int AgencyBalanceWarningCurrencyId){
            try
            {
                return connection.Query<AgencyCreditDeposit>("AgencyCreditDepositGetByAgencyBalanceWarningCurrencyId", new
                {
AgencyBalanceWarningCurrencyId = AgencyBalanceWarningCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCreditDeposit> GetByAgencyBalanceWarningIsByPercentage(int AgencyBalanceWarningIsByPercentage){
            try
            {
                return connection.Query<AgencyCreditDeposit>("AgencyCreditDepositGetByAgencyBalanceWarningIsByPercentage", new
                {
AgencyBalanceWarningIsByPercentage = AgencyBalanceWarningIsByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCreditDeposit> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyCreditDeposit>("AgencyCreditDepositGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCreditDeposit> GetByBalanceAmount(decimal BalanceAmount){
            try
            {
                return connection.Query<AgencyCreditDeposit>("AgencyCreditDepositGetByBalanceAmount", new
                {
BalanceAmount = BalanceAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCreditDeposit> GetByBalanceCurrencyId(int BalanceCurrencyId){
            try
            {
                return connection.Query<AgencyCreditDeposit>("AgencyCreditDepositGetByBalanceCurrencyId", new
                {
BalanceCurrencyId = BalanceCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyCreditDeposit GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyCreditDeposit>("AgencyCreditDepositGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCreditDeposit> GetBySendBalanceWarning(bool SendBalanceWarning){
            try
            {
                return connection.Query<AgencyCreditDeposit>("AgencyCreditDepositGetBySendBalanceWarning", new
                {
SendBalanceWarning = SendBalanceWarning
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
