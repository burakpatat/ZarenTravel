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
    public class AgencyMicroSiteSettingsSearchEngineRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsSearchEngineRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsSearchEngine AgencyMicroSiteSettingsSearchEngine)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsSearchEngine);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsSearchEngine AgencyMicroSiteSettingsSearchEngine)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsSearchEngine);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsSearchEngine AgencyMicroSiteSettingsSearchEngine)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsSearchEngine>(AgencyMicroSiteSettingsSearchEngine);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsSearchEngine> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchEngine> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchEngine> GetByDefaultAvailabilityTimeoutDuration(int DefaultAvailabilityTimeoutDuration){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetByDefaultAvailabilityTimeoutDuration", new
                {
DefaultAvailabilityTimeoutDuration = DefaultAvailabilityTimeoutDuration
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchEngine> GetByDefaultReleaseDaysB2BUsers(int DefaultReleaseDaysB2BUsers){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetByDefaultReleaseDaysB2BUsers", new
                {
DefaultReleaseDaysB2BUsers = DefaultReleaseDaysB2BUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchEngine> GetByDefaultReleaseDaysForEarlyBooking(int DefaultReleaseDaysForEarlyBooking){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetByDefaultReleaseDaysForEarlyBooking", new
                {
DefaultReleaseDaysForEarlyBooking = DefaultReleaseDaysForEarlyBooking
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchEngine> GetByDefaultReleaseDaysOtherUsers(int DefaultReleaseDaysOtherUsers){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetByDefaultReleaseDaysOtherUsers", new
                {
DefaultReleaseDaysOtherUsers = DefaultReleaseDaysOtherUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsSearchEngine GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchEngine> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchEngine> GetByMinimumNightAllowed(int MinimumNightAllowed){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchEngine>("AgencyMicroSiteSettingsSearchEngineGetByMinimumNightAllowed", new
                {
MinimumNightAllowed = MinimumNightAllowed
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
