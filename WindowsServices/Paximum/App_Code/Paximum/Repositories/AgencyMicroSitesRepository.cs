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
    public class AgencyMicroSitesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSitesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSites AgencyMicroSites)
    {
        try
        {
            return connection.Insert(AgencyMicroSites);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSites AgencyMicroSites)
    {
        try
        {
       return  connection.Update(AgencyMicroSites);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSites AgencyMicroSites)
        {
            try
            {
            return  connection.Delete<AgencyMicroSites>(AgencyMicroSites);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSites> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> GetByCollectivePassword(string CollectivePassword){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetByCollectivePassword", new
                {
CollectivePassword = CollectivePassword
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> GetByDomain(string Domain){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetByDomain", new
                {
Domain = Domain
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSites GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSites>("AgencyMicroSitesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> GetByRedirectUrl(string RedirectUrl){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetByRedirectUrl", new
                {
RedirectUrl = RedirectUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> GetBySubDomain(string SubDomain){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetBySubDomain", new
                {
SubDomain = SubDomain
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesGetCreatedDateBetween", new
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
public List<AgencyMicroSites> SettingsEmailConfigurationGetAll(){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesSettingsEmailConfigurationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> SettingsEmailConfigurationGetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesSettingsEmailConfigurationGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> SettingsEmailConfigurationGetByEmail(string Email){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesSettingsEmailConfigurationGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSites SettingsEmailConfigurationGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSites>("AgencyMicroSitesSettingsEmailConfigurationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> SettingsEmailConfigurationGetByIsValid(bool IsValid){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesSettingsEmailConfigurationGetByIsValid", new
                {
IsValid = IsValid
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSites> SettingsEmailConfigurationGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSites>("AgencyMicroSitesSettingsEmailConfigurationGetByMicroSiteId", new
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
