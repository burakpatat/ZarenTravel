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
    public class PaymentConfigurationRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PaymentConfigurationRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PaymentConfiguration PaymentConfiguration)
    {
        try
        {
            return connection.Insert(PaymentConfiguration);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PaymentConfiguration PaymentConfiguration)
    {
        try
        {
       return  connection.Update(PaymentConfiguration);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PaymentConfiguration PaymentConfiguration)
        {
            try
            {
            return  connection.Delete<PaymentConfiguration>(PaymentConfiguration);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PaymentConfiguration> GetAll(){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentConfiguration> GetByEmail(string Email){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PaymentConfiguration GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PaymentConfiguration>("PaymentConfigurationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentConfiguration> GetByLanguage(string Language){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetByLanguage", new
                {
Language = Language
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentConfiguration> GetByNoLimitTestCardNumber(string NoLimitTestCardNumber){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetByNoLimitTestCardNumber", new
                {
NoLimitTestCardNumber = NoLimitTestCardNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentConfiguration> GetByPassword(string Password){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetByPassword", new
                {
Password = Password
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentConfiguration> GetByPaymentCompany(string PaymentCompany){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetByPaymentCompany", new
                {
PaymentCompany = PaymentCompany
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentConfiguration> GetByProdUrl(string ProdUrl){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetByProdUrl", new
                {
ProdUrl = ProdUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentConfiguration> GetBySuccessTestCardNumber(string SuccessTestCardNumber){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetBySuccessTestCardNumber", new
                {
SuccessTestCardNumber = SuccessTestCardNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentConfiguration> GetByTestUrl(string TestUrl){
            try
            {
                return connection.Query<PaymentConfiguration>("PaymentConfigurationGetByTestUrl", new
                {
TestUrl = TestUrl
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
