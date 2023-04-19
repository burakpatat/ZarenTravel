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
    public class AgencyContractsInsuranceSelectedLanguageRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsInsuranceSelectedLanguageRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsInsuranceSelectedLanguage AgencyContractsInsuranceSelectedLanguage)
    {
        try
        {
            return connection.Insert(AgencyContractsInsuranceSelectedLanguage);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsInsuranceSelectedLanguage AgencyContractsInsuranceSelectedLanguage)
    {
        try
        {
       return  connection.Update(AgencyContractsInsuranceSelectedLanguage);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsInsuranceSelectedLanguage AgencyContractsInsuranceSelectedLanguage)
        {
            try
            {
            return  connection.Delete<AgencyContractsInsuranceSelectedLanguage>(AgencyContractsInsuranceSelectedLanguage);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsInsuranceSelectedLanguage> GetAll(){
            try
            {
                return connection.Query<AgencyContractsInsuranceSelectedLanguage>("AgencyContractsInsuranceSelectedLanguageGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsInsuranceSelectedLanguage GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsInsuranceSelectedLanguage>("AgencyContractsInsuranceSelectedLanguageGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceSelectedLanguage> GetByInsuranceDescription(string InsuranceDescription){
            try
            {
                return connection.Query<AgencyContractsInsuranceSelectedLanguage>("AgencyContractsInsuranceSelectedLanguageGetByInsuranceDescription", new
                {
InsuranceDescription = InsuranceDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceSelectedLanguage> GetByInsurancesId(int InsurancesId){
            try
            {
                return connection.Query<AgencyContractsInsuranceSelectedLanguage>("AgencyContractsInsuranceSelectedLanguageGetByInsurancesId", new
                {
InsurancesId = InsurancesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceSelectedLanguage> GetByLangId(int LangId){
            try
            {
                return connection.Query<AgencyContractsInsuranceSelectedLanguage>("AgencyContractsInsuranceSelectedLanguageGetByLangId", new
                {
LangId = LangId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceSelectedLanguage> GetByVoucherRemarks(string VoucherRemarks){
            try
            {
                return connection.Query<AgencyContractsInsuranceSelectedLanguage>("AgencyContractsInsuranceSelectedLanguageGetByVoucherRemarks", new
                {
VoucherRemarks = VoucherRemarks
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
