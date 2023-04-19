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
    public class InsuranceSelectedLangRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public InsuranceSelectedLangRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(InsuranceSelectedLang InsuranceSelectedLang)
    {
        try
        {
            return connection.Insert(InsuranceSelectedLang);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(InsuranceSelectedLang InsuranceSelectedLang)
    {
        try
        {
       return  connection.Update(InsuranceSelectedLang);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(InsuranceSelectedLang InsuranceSelectedLang)
        {
            try
            {
            return  connection.Delete<InsuranceSelectedLang>(InsuranceSelectedLang);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<InsuranceSelectedLang> GetAll(){
            try
            {
                return connection.Query<InsuranceSelectedLang>("InsuranceSelectedLangGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public InsuranceSelectedLang GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<InsuranceSelectedLang>("InsuranceSelectedLangGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<InsuranceSelectedLang> GetByInsurancesId(int InsurancesId){
            try
            {
                return connection.Query<InsuranceSelectedLang>("InsuranceSelectedLangGetByInsurancesId", new
                {
InsurancesId = InsurancesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<InsuranceSelectedLang> GetByLangId(int LangId){
            try
            {
                return connection.Query<InsuranceSelectedLang>("InsuranceSelectedLangGetByLangId", new
                {
LangId = LangId
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
