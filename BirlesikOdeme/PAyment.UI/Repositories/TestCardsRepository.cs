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
    public class TestCardsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public TestCardsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(TestCards TestCards)
    {
        try
        {
            return connection.Insert(TestCards);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(TestCards TestCards)
    {
        try
        {
       return  connection.Update(TestCards);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(TestCards TestCards)
        {
            try
            {
            return  connection.Delete<TestCards>(TestCards);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<TestCards> GetAll(){
            try
            {
                return connection.Query<TestCards>("TestCardsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByBankName(string BankName){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByBankName", new
                {
BankName = BankName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByCardNo(string CardNo){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByCardNo", new
                {
CardNo = CardNo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByCardScheme(string CardScheme){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByCardScheme", new
                {
CardScheme = CardScheme
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByCardType(string CardType){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByCardType", new
                {
CardType = CardType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByCVV(string CVV){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByCVV", new
                {
CVV = CVV
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public TestCards GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<TestCards>("TestCardsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByPaymentConfigurationId(int PaymentConfigurationId){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByPaymentConfigurationId", new
                {
PaymentConfigurationId = PaymentConfigurationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByResponseType(string ResponseType){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByResponseType", new
                {
ResponseType = ResponseType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByThreeDPassword(string ThreeDPassword){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByThreeDPassword", new
                {
ThreeDPassword = ThreeDPassword
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TestCards> GetByValidDate(string ValidDate){
            try
            {
                return connection.Query<TestCards>("TestCardsGetByValidDate", new
                {
ValidDate = ValidDate
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
