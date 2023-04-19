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
    public class AgencyMicroSiteSettingsPaymetOptionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsPaymetOptionsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsPaymetOptions AgencyMicroSiteSettingsPaymetOptions)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsPaymetOptions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsPaymetOptions AgencyMicroSiteSettingsPaymetOptions)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsPaymetOptions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsPaymetOptions AgencyMicroSiteSettingsPaymetOptions)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsPaymetOptions>(AgencyMicroSiteSettingsPaymetOptions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsPaymetOptions> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsPaymetOptions>("AgencyMicroSiteSettingsPaymetOptionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsPaymetOptions GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsPaymetOptions>("AgencyMicroSiteSettingsPaymetOptionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsPaymetOptions> GetByOptionsName(string OptionsName){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsPaymetOptions>("AgencyMicroSiteSettingsPaymetOptionsGetByOptionsName", new
                {
OptionsName = OptionsName
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
