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
    public class OneRoundMultiWaysRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public OneRoundMultiWaysRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(OneRoundMultiWays OneRoundMultiWays)
    {
        try
        {
            return connection.Insert(OneRoundMultiWays);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(OneRoundMultiWays OneRoundMultiWays)
    {
        try
        {
       return  connection.Update(OneRoundMultiWays);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(OneRoundMultiWays OneRoundMultiWays)
        {
            try
            {
            return  connection.Delete<OneRoundMultiWays>(OneRoundMultiWays);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<OneRoundMultiWays> GetAll(){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByAmount(double Amount){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByApiId(int ApiId){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public OneRoundMultiWays GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<OneRoundMultiWays>("OneRoundMultiWaysGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByPassengerTypesId(int PassengerTypesId){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByPassengerTypesId", new
                {
PassengerTypesId = PassengerTypesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByPrice(double Price){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByPrice", new
                {
Price = Price
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByQuantity(int Quantity){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByQuantity", new
                {
Quantity = Quantity
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetByTotalPrice(int TotalPrice){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetByTotalPrice", new
                {
TotalPrice = TotalPrice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OneRoundMultiWays> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<OneRoundMultiWays>("OneRoundMultiWaysGetCreatedDateBetween", new
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
