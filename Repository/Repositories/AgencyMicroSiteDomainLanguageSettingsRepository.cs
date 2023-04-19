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
    public class AgencyMicroSiteDomainLanguageSettingsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteDomainLanguageSettingsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteDomainLanguageSettings AgencyMicroSiteDomainLanguageSettings)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteDomainLanguageSettings);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteDomainLanguageSettings AgencyMicroSiteDomainLanguageSettings)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteDomainLanguageSettings);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteDomainLanguageSettings AgencyMicroSiteDomainLanguageSettings)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteDomainLanguageSettings>(AgencyMicroSiteDomainLanguageSettings);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteDomainLanguageSettings> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteDomainLanguageSettings>("AgencyMicroSiteDomainLanguageSettingsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomainLanguageSettings> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteDomainLanguageSettings>("AgencyMicroSiteDomainLanguageSettingsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomainLanguageSettings> GetByDomainId(int DomainId){
            try
            {
                return connection.Query<AgencyMicroSiteDomainLanguageSettings>("AgencyMicroSiteDomainLanguageSettingsGetByDomainId", new
                {
DomainId = DomainId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteDomainLanguageSettings GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteDomainLanguageSettings>("AgencyMicroSiteDomainLanguageSettingsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomainLanguageSettings> GetByIsDefault(bool IsDefault){
            try
            {
                return connection.Query<AgencyMicroSiteDomainLanguageSettings>("AgencyMicroSiteDomainLanguageSettingsGetByIsDefault", new
                {
IsDefault = IsDefault
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomainLanguageSettings> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<AgencyMicroSiteDomainLanguageSettings>("AgencyMicroSiteDomainLanguageSettingsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomainLanguageSettings> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteDomainLanguageSettings>("AgencyMicroSiteDomainLanguageSettingsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomainLanguageSettings> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<AgencyMicroSiteDomainLanguageSettings>("AgencyMicroSiteDomainLanguageSettingsGetByTableOrder", new
                {
TableOrder = TableOrder
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
