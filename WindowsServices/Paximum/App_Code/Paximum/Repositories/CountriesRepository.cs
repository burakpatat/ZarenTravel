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
    public class CountriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CountriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Countries Countries)
    {
        try
        {
            return connection.Insert(Countries);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Countries Countries)
    {
        try
        {
       return  connection.Update(Countries);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Countries Countries)
        {
            try
            {
            return  connection.Delete<Countries>(Countries);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Countries> GetAll(){
            try
            {
                return connection.Query<Countries>("CountriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Countries>("CountriesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Countries>("CountriesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByCountryId(string CountryId){
            try
            {
                return connection.Query<Countries>("CountriesGetByCountryId", new
                {
CountryId = CountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Countries>("CountriesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Countries>("CountriesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Countries GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Countries>("CountriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Countries>("CountriesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Countries>("CountriesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetByName(string Name){
            try
            {
                return connection.Query<Countries>("CountriesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Countries>("CountriesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Countries> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Countries>("CountriesGetCreatedDateBetween", new
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
