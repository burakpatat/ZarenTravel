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
    public class AgencyMicroSiteSettingsSearchSettingsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsSearchSettingsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsSearchSettings AgencyMicroSiteSettingsSearchSettings)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsSearchSettings);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsSearchSettings AgencyMicroSiteSettingsSearchSettings)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsSearchSettings);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsSearchSettings AgencyMicroSiteSettingsSearchSettings)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsSearchSettings>(AgencyMicroSiteSettingsSearchSettings);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByAccommodationSearchResults(int AccommodationSearchResults){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByAccommodationSearchResults", new
                {
AccommodationSearchResults = AccommodationSearchResults
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByAgencyMicroSiteSettingEnableMultiDay(int AgencyMicroSiteSettingEnableMultiDay){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByAgencyMicroSiteSettingEnableMultiDay", new
                {
AgencyMicroSiteSettingEnableMultiDay = AgencyMicroSiteSettingEnableMultiDay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByAgencyMicroSiteSettingsAccommodationSortType(int AgencyMicroSiteSettingsAccommodationSortType){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByAgencyMicroSiteSettingsAccommodationSortType", new
                {
AgencyMicroSiteSettingsAccommodationSortType = AgencyMicroSiteSettingsAccommodationSortType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByAgencyMicroSiteSettingsTicketSortType(int AgencyMicroSiteSettingsTicketSortType){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByAgencyMicroSiteSettingsTicketSortType", new
                {
AgencyMicroSiteSettingsTicketSortType = AgencyMicroSiteSettingsTicketSortType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByAskForDepartureLocationHolidayPackage(bool AskForDepartureLocationHolidayPackage){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByAskForDepartureLocationHolidayPackage", new
                {
AskForDepartureLocationHolidayPackage = AskForDepartureLocationHolidayPackage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByB2BUsersSeeProvidersQuotingService(bool B2BUsersSeeProvidersQuotingService){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByB2BUsersSeeProvidersQuotingService", new
                {
B2BUsersSeeProvidersQuotingService = B2BUsersSeeProvidersQuotingService
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByDonotShowTourProviderB2BUsers(bool DonotShowTourProviderB2BUsers){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByDonotShowTourProviderB2BUsers", new
                {
DonotShowTourProviderB2BUsers = DonotShowTourProviderB2BUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByDonotShowTourProviderB2CUsers(bool DonotShowTourProviderB2CUsers){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByDonotShowTourProviderB2CUsers", new
                {
DonotShowTourProviderB2CUsers = DonotShowTourProviderB2CUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByEnableRequestActivities(bool EnableRequestActivities){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByEnableRequestActivities", new
                {
EnableRequestActivities = EnableRequestActivities
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsSearchSettings GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByInAccommodationSearchEngineAllowSearchHotelName(bool InAccommodationSearchEngineAllowSearchHotelName){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByInAccommodationSearchEngineAllowSearchHotelName", new
                {
InAccommodationSearchEngineAllowSearchHotelName = InAccommodationSearchEngineAllowSearchHotelName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByInAccommodationSearchEngineAllowSearchInterestPoint(bool InAccommodationSearchEngineAllowSearchInterestPoint){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByInAccommodationSearchEngineAllowSearchInterestPoint", new
                {
InAccommodationSearchEngineAllowSearchInterestPoint = InAccommodationSearchEngineAllowSearchInterestPoint
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetBySameListOriginsListDestinations(bool SameListOriginsListDestinations){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetBySameListOriginsListDestinations", new
                {
SameListOriginsListDestinations = SameListOriginsListDestinations
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetBySearchBoxDropdownMenuFormatAutoComplete(bool SearchBoxDropdownMenuFormatAutoComplete){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetBySearchBoxDropdownMenuFormatAutoComplete", new
                {
SearchBoxDropdownMenuFormatAutoComplete = SearchBoxDropdownMenuFormatAutoComplete
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetBySelectHolidayPackageSortType(int SelectHolidayPackageSortType){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetBySelectHolidayPackageSortType", new
                {
SelectHolidayPackageSortType = SelectHolidayPackageSortType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetBySelectTransportSortType(int SelectTransportSortType){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetBySelectTransportSortType", new
                {
SelectTransportSortType = SelectTransportSortType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByShowLocationSearchbox(bool ShowLocationSearchbox){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByShowLocationSearchbox", new
                {
ShowLocationSearchbox = ShowLocationSearchbox
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByShowThemesHomePageSlidingFormat(bool ShowThemesHomePageSlidingFormat){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByShowThemesHomePageSlidingFormat", new
                {
ShowThemesHomePageSlidingFormat = ShowThemesHomePageSlidingFormat
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsSearchSettings> GetByTicketSearchResultsUseThisViewResult(int TicketSearchResultsUseThisViewResult){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsSearchSettings>("AgencyMicroSiteSettingsSearchSettingsGetByTicketSearchResultsUseThisViewResult", new
                {
TicketSearchResultsUseThisViewResult = TicketSearchResultsUseThisViewResult
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
