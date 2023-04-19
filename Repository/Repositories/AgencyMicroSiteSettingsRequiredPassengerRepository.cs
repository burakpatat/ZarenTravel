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
    public class AgencyMicroSiteSettingsRequiredPassengerRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsRequiredPassengerRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsRequiredPassenger AgencyMicroSiteSettingsRequiredPassenger)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsRequiredPassenger);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsRequiredPassenger AgencyMicroSiteSettingsRequiredPassenger)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsRequiredPassenger);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsRequiredPassenger AgencyMicroSiteSettingsRequiredPassenger)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsRequiredPassenger>(AgencyMicroSiteSettingsRequiredPassenger);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsRequiredPassenger> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsRequiredPassenger>("AgencyMicroSiteSettingsRequiredPassengerGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsRequiredPassenger GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsRequiredPassenger>("AgencyMicroSiteSettingsRequiredPassengerGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsRequiredPassenger> GetByIsActive(bool IsActive){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsRequiredPassenger>("AgencyMicroSiteSettingsRequiredPassengerGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsRequiredPassenger> GetByName(string Name){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsRequiredPassenger>("AgencyMicroSiteSettingsRequiredPassengerGetByName", new
                {
Name = Name
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
