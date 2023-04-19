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
    public class AgencyMicroSiteSettingsHelpSupportRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsHelpSupportRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsHelpSupport AgencyMicroSiteSettingsHelpSupport)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsHelpSupport);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsHelpSupport AgencyMicroSiteSettingsHelpSupport)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsHelpSupport);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsHelpSupport AgencyMicroSiteSettingsHelpSupport)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsHelpSupport>(AgencyMicroSiteSettingsHelpSupport);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsHelpSupport> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsHelpSupport>("AgencyMicroSiteSettingsHelpSupportGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsHelpSupport> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsHelpSupport>("AgencyMicroSiteSettingsHelpSupportGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsHelpSupport> GetByHideFeedback(bool HideFeedback){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsHelpSupport>("AgencyMicroSiteSettingsHelpSupportGetByHideFeedback", new
                {
HideFeedback = HideFeedback
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsHelpSupport GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsHelpSupport>("AgencyMicroSiteSettingsHelpSupportGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsHelpSupport> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsHelpSupport>("AgencyMicroSiteSettingsHelpSupportGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsHelpSupport> GetByOpenHelpVideosModalNewTab(bool OpenHelpVideosModalNewTab){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsHelpSupport>("AgencyMicroSiteSettingsHelpSupportGetByOpenHelpVideosModalNewTab", new
                {
OpenHelpVideosModalNewTab = OpenHelpVideosModalNewTab
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
