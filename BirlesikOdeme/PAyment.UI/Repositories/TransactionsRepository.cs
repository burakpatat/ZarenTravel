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
    public class TransactionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public TransactionsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Transactions Transactions)
    {
        try
        {
            return connection.Insert(Transactions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Transactions Transactions)
    {
        try
        {
       return  connection.Update(Transactions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Transactions Transactions)
        {
            try
            {
            return  connection.Delete<Transactions>(Transactions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Transactions> GetAll(){
            try
            {
                return connection.Query<Transactions>("TransactionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByCurrency(int Currency){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByCurrency", new
                {
Currency = Currency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Transactions GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Transactions>("TransactionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByIdGuid(string IdGuid){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByIdGuid", new
                {
IdGuid = IdGuid
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByIs3D(bool Is3D){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByIs3D", new
                {
Is3D = Is3D
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByIsSuccess(bool IsSuccess){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByIsSuccess", new
                {
IsSuccess = IsSuccess
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByLanguage(string Language){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByLanguage", new
                {
Language = Language
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByNameSurname(string NameSurname){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByNameSurname", new
                {
NameSurname = NameSurname
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByTotalAmount(decimal TotalAmount){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByTotalAmount", new
                {
TotalAmount = TotalAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetByUserId(string UserId){
            try
            {
                return connection.Query<Transactions>("TransactionsGetByUserId", new
                {
UserId = UserId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Transactions> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Transactions>("TransactionsGetCreatedDateBetween", new
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
