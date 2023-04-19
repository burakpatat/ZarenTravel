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
    public class AgencyMicroSiteSettingsBookingReplicatorModeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsBookingReplicatorModeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsBookingReplicatorMode AgencyMicroSiteSettingsBookingReplicatorMode)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsBookingReplicatorMode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsBookingReplicatorMode AgencyMicroSiteSettingsBookingReplicatorMode)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsBookingReplicatorMode);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsBookingReplicatorMode AgencyMicroSiteSettingsBookingReplicatorMode)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsBookingReplicatorMode>(AgencyMicroSiteSettingsBookingReplicatorMode);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsBookingReplicatorMode> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingReplicatorMode>("AgencyMicroSiteSettingsBookingReplicatorModeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingReplicatorMode> GetByCustomizeIt(bool CustomizeIt){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingReplicatorMode>("AgencyMicroSiteSettingsBookingReplicatorModeGetByCustomizeIt", new
                {
CustomizeIt = CustomizeIt
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingReplicatorMode> GetByDirectBookingWithoutChanges(bool DirectBookingWithoutChanges){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingReplicatorMode>("AgencyMicroSiteSettingsBookingReplicatorModeGetByDirectBookingWithoutChanges", new
                {
DirectBookingWithoutChanges = DirectBookingWithoutChanges
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsBookingReplicatorMode GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsBookingReplicatorMode>("AgencyMicroSiteSettingsBookingReplicatorModeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingReplicatorMode> GetByIWantIt(bool IWantIt){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingReplicatorMode>("AgencyMicroSiteSettingsBookingReplicatorModeGetByIWantIt", new
                {
IWantIt = IWantIt
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
