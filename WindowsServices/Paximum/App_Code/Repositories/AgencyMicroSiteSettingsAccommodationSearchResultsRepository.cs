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
    public class AgencyMicroSiteSettingsAccommodationSearchResultsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsAccommodationSearchResultsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsAccommodationSearchResults AgencyMicroSiteSettingsAccommodationSearchResults)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsAccommodationSearchResults);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsAccommodationSearchResults AgencyMicroSiteSettingsAccommodationSearchResults)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsAccommodationSearchResults);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsAccommodationSearchResults AgencyMicroSiteSettingsAccommodationSearchResults)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsAccommodationSearchResults>(AgencyMicroSiteSettingsAccommodationSearchResults);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsAccommodationSearchResults> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsAccommodationSearchResults>("AgencyMicroSiteSettingsAccommodationSearchResultsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsAccommodationSearchResults GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsAccommodationSearchResults>("AgencyMicroSiteSettingsAccommodationSearchResultsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsAccommodationSearchResults> GetByName(string Name){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsAccommodationSearchResults>("AgencyMicroSiteSettingsAccommodationSearchResultsGetByName", new
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
