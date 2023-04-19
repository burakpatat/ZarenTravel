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
    public class AgencyMicroSiteSettingsEnableMultiDayRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsEnableMultiDayRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsEnableMultiDay AgencyMicroSiteSettingsEnableMultiDay)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsEnableMultiDay);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsEnableMultiDay AgencyMicroSiteSettingsEnableMultiDay)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsEnableMultiDay);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsEnableMultiDay AgencyMicroSiteSettingsEnableMultiDay)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsEnableMultiDay>(AgencyMicroSiteSettingsEnableMultiDay);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsEnableMultiDay> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEnableMultiDay>("AgencyMicroSiteSettingsEnableMultiDayGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsEnableMultiDay GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsEnableMultiDay>("AgencyMicroSiteSettingsEnableMultiDayGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEnableMultiDay> GetByName(string Name){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEnableMultiDay>("AgencyMicroSiteSettingsEnableMultiDayGetByName", new
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
