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
    public class CompaniesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CompaniesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Companies Companies)
    {
        try
        {
            return connection.Insert(Companies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Companies Companies)
    {
        try
        {
       return  connection.Update(Companies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Companies Companies)
        {
            try
            {
            return  connection.Delete<Companies>(Companies);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Companies> GetAll(){
            try
            {
                return connection.Query<Companies>("CompaniesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Companies>("CompaniesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByCoDiId(int CoDiId){
            try
            {
                return connection.Query<Companies>("CompaniesGetByCoDiId", new
                {
CoDiId = CoDiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByCoGrId(int CoGrId){
            try
            {
                return connection.Query<Companies>("CompaniesGetByCoGrId", new
                {
CoGrId = CoGrId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByCompanyActive(bool CompanyActive){
            try
            {
                return connection.Query<Companies>("CompaniesGetByCompanyActive", new
                {
CompanyActive = CompanyActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByCompanyCode(string CompanyCode){
            try
            {
                return connection.Query<Companies>("CompaniesGetByCompanyCode", new
                {
CompanyCode = CompanyCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByCompanyRepresentative(string CompanyRepresentative){
            try
            {
                return connection.Query<Companies>("CompaniesGetByCompanyRepresentative", new
                {
CompanyRepresentative = CompanyRepresentative
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByCompanyTimestamp(DateTime CompanyTimestamp){
            try
            {
                return connection.Query<Companies>("CompaniesGetByCompanyTimestamp", new
                {
CompanyTimestamp = CompanyTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByCountryId(int CountryId){
            try
            {
                return connection.Query<Companies>("CompaniesGetByCountryId", new
                {
CountryId = CountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<Companies>("CompaniesGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Companies GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Companies>("CompaniesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByInSeId(int InSeId){
            try
            {
                return connection.Query<Companies>("CompaniesGetByInSeId", new
                {
InSeId = InSeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetByLanguagesId(int LanguagesId){
            try
            {
                return connection.Query<Companies>("CompaniesGetByLanguagesId", new
                {
LanguagesId = LanguagesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Companies> GetCompanyTimestampBetween(DateTime CompanyTimestampStart,DateTime CompanyTimestampEnd){
            try
            {
                return connection.Query<Companies>("CompaniesGetCompanyTimestampBetween", new
                {
CompanyTimestampStart = CompanyTimestampStart
,CompanyTimestampEnd = CompanyTimestampEnd
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
