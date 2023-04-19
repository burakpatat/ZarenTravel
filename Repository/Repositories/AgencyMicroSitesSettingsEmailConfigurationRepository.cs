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
    public class AgencyMicroSitesSettingsEmailConfigurationRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSitesSettingsEmailConfigurationRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSitesSettingsEmailConfiguration AgencyMicroSitesSettingsEmailConfiguration)
    {
        try
        {
            return connection.Insert(AgencyMicroSitesSettingsEmailConfiguration);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSitesSettingsEmailConfiguration AgencyMicroSitesSettingsEmailConfiguration)
    {
        try
        {
       return  connection.Update(AgencyMicroSitesSettingsEmailConfiguration);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSitesSettingsEmailConfiguration AgencyMicroSitesSettingsEmailConfiguration)
        {
            try
            {
            return  connection.Delete<AgencyMicroSitesSettingsEmailConfiguration>(AgencyMicroSitesSettingsEmailConfiguration);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSitesSettingsEmailConfiguration> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSitesSettingsEmailConfiguration>("AgencyMicroSitesSettingsEmailConfigurationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitesSettingsEmailConfiguration> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSitesSettingsEmailConfiguration>("AgencyMicroSitesSettingsEmailConfigurationGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitesSettingsEmailConfiguration> GetByEmail(string Email){
            try
            {
                return connection.Query<AgencyMicroSitesSettingsEmailConfiguration>("AgencyMicroSitesSettingsEmailConfigurationGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSitesSettingsEmailConfiguration GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSitesSettingsEmailConfiguration>("AgencyMicroSitesSettingsEmailConfigurationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitesSettingsEmailConfiguration> GetByIsValid(bool IsValid){
            try
            {
                return connection.Query<AgencyMicroSitesSettingsEmailConfiguration>("AgencyMicroSitesSettingsEmailConfigurationGetByIsValid", new
                {
IsValid = IsValid
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitesSettingsEmailConfiguration> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSitesSettingsEmailConfiguration>("AgencyMicroSitesSettingsEmailConfigurationGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
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
