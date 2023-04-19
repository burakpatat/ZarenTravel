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
    public class AgencyRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Agency Agency)
    {
        try
        {
            return connection.Insert(Agency);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Agency Agency)
    {
        try
        {
       return  connection.Update(Agency);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Agency Agency)
        {
            try
            {
            return  connection.Delete<Agency>(Agency);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Agency> CmsDevicesGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyCmsDevicesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency CmsDevicesGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyCmsDevicesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsDevicesGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyCmsDevicesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSectionTypesGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyCmsSectionTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSectionTypesGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyCmsSectionTypesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSectionTypesGetByCreated(DateTime Created){
            try
            {
                return connection.Query<Agency>("AgencyCmsSectionTypesGetByCreated", new
                {
Created = Created
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSectionTypesGetByCreatedBy(DateTime CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencyCmsSectionTypesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency CmsSectionTypesGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyCmsSectionTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSectionTypesGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyCmsSectionTypesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSectionTypesGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyCmsSectionTypesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSectionTypesGetCreatedBetween(DateTime CreatedStart,DateTime CreatedEnd){
            try
            {
                return connection.Query<Agency>("AgencyCmsSectionTypesGetCreatedBetween", new
                {
CreatedStart = CreatedStart
,CreatedEnd = CreatedEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSectionTypesGetCreatedByBetween(DateTime CreatedByStart,DateTime CreatedByEnd){
            try
            {
                return connection.Query<Agency>("AgencyCmsSectionTypesGetCreatedByBetween", new
                {
CreatedByStart = CreatedByStart
,CreatedByEnd = CreatedByEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByFacebookUrl(string FacebookUrl){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByFacebookUrl", new
                {
FacebookUrl = FacebookUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByHomeUrl(string HomeUrl){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByHomeUrl", new
                {
HomeUrl = HomeUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency CmsSocialMediaUrlsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyCmsSocialMediaUrlsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByInstagramUrl(string InstagramUrl){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByInstagramUrl", new
                {
InstagramUrl = InstagramUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByLinkedInUrl(string LinkedInUrl){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByLinkedInUrl", new
                {
LinkedInUrl = LinkedInUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByPinterestUrl(string PinterestUrl){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByPinterestUrl", new
                {
PinterestUrl = PinterestUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByTwitterUrl(string TwitterUrl){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByTwitterUrl", new
                {
TwitterUrl = TwitterUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByViemoUrl(string ViemoUrl){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByViemoUrl", new
                {
ViemoUrl = ViemoUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsSocialMediaUrlsGetByYoutubeUrl(string YoutubeUrl){
            try
            {
                return connection.Query<Agency>("AgencyCmsSocialMediaUrlsGetByYoutubeUrl", new
                {
YoutubeUrl = YoutubeUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetByIcon(string Icon){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetByIcon", new
                {
Icon = Icon
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency CmsThemesGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyCmsThemesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetByImageLink(string ImageLink){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetByImageLink", new
                {
ImageLink = ImageLink
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetByImagePath(string ImagePath){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetByImagePath", new
                {
ImagePath = ImagePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetByIsMainTheme(bool IsMainTheme){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetByIsMainTheme", new
                {
IsMainTheme = IsMainTheme
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CmsThemesGetByOrders(int Orders){
            try
            {
                return connection.Query<Agency>("AgencyCmsThemesGetByOrders", new
                {
Orders = Orders
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetByAmount(decimal Amount){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetByApiId(int ApiId){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetByCurrency(string Currency){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetByCurrency", new
                {
Currency = Currency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency CommisionsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyCommisionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetByPercents(int Percents){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetByPercents", new
                {
Percents = Percents
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetBySystemId(int SystemId){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CommisionsGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyCommisionsGetCreatedDateBetween", new
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
public List<Agency> ContractsClosedToursGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByCode(string Code){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByCode", new
                {
Code = Code
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByContractaFrom(string ContractaFrom){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByContractaFrom", new
                {
ContractaFrom = ContractaFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByContractTo(string ContractTo){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByContractTo", new
                {
ContractTo = ContractTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByCreator(string Creator){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByCreator", new
                {
Creator = Creator
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByDateCreation(DateTime DateCreation){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByDateCreation", new
                {
DateCreation = DateCreation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByDestinations(string Destinations){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByDestinations", new
                {
Destinations = Destinations
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByExtension(bool Extension){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByExtension", new
                {
Extension = Extension
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsClosedToursGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsClosedToursGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByIsActive(bool IsActive){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByIsSelect(bool IsSelect){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByIsSelect", new
                {
IsSelect = IsSelect
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByMarketPlace(bool MarketPlace){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByMarketPlace", new
                {
MarketPlace = MarketPlace
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByNights(int Nights){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByNights", new
                {
Nights = Nights
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByPro(bool Pro){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByPro", new
                {
Pro = Pro
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetBySupplier(string Supplier){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetBySupplier", new
                {
Supplier = Supplier
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetByTourSupplierName(string TourSupplierName){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetByTourSupplierName", new
                {
TourSupplierName = TourSupplierName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsClosedToursGetDateCreationBetween(DateTime DateCreationStart,DateTime DateCreationEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsClosedToursGetDateCreationBetween", new
                {
DateCreationStart = DateCreationStart
,DateCreationEnd = DateCreationEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsConfigurationByHotelGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsConfigurationByHotelGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsConfigurationByHotelGetByHotelConfigurationId(int HotelConfigurationId){
            try
            {
                return connection.Query<Agency>("AgencyContractsConfigurationByHotelGetByHotelConfigurationId", new
                {
HotelConfigurationId = HotelConfigurationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsConfigurationByHotelGetByID(int MicroSiteId){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsConfigurationByHotelGetByID", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsConfigurationByHotelGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyContractsConfigurationByHotelGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelCategoriesGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsHotelCategoriesGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsHotelCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelCategoriesGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelCategoriesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByAddress(string Address){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByıd(int Agencyıd){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByAgencyıd", new
                {
Agencyıd = Agencyıd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByCountryId(int CountryId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByCountryId", new
                {
CountryId = CountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByCreatedByUser(int CreatedByUser){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByCreatedByUser", new
                {
CreatedByUser = CreatedByUser
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByDescription(string Description){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByEmail(string Email){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByFax(string Fax){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByFax", new
                {
Fax = Fax
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByHotelCategoryId(int HotelCategoryId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByHotelCategoryId", new
                {
HotelCategoryId = HotelCategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByHotelChainId(int HotelChainId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByHotelChainId", new
                {
HotelChainId = HotelChainId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByHotelCode(string HotelCode){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByHotelCode", new
                {
HotelCode = HotelCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByHotelFacilityId(int HotelFacilityId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByHotelFacilityId", new
                {
HotelFacilityId = HotelFacilityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByHotelImageId(int HotelImageId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByHotelImageId", new
                {
HotelImageId = HotelImageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsHotelInformationGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsHotelInformationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByIsActive(bool IsActive){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByLangId(int LangId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByLangId", new
                {
LangId = LangId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByLatitude(decimal Latitude){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByLatitude", new
                {
Latitude = Latitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByLocationName(string LocationName){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByLocationName", new
                {
LocationName = LocationName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByLongitude(decimal Longitude){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByLongitude", new
                {
Longitude = Longitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByOnlyHolidayPackage(bool OnlyHolidayPackage){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByOnlyHolidayPackage", new
                {
OnlyHolidayPackage = OnlyHolidayPackage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByPhone(string Phone){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByPhone", new
                {
Phone = Phone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByPossibleDestinations(string PossibleDestinations){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByPossibleDestinations", new
                {
PossibleDestinations = PossibleDestinations
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByPostalCode(string PostalCode){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByPostalCode", new
                {
PostalCode = PostalCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetByRemark(string Remark){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetByRemark", new
                {
Remark = Remark
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationGetBySupplierBy(int SupplierBy){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationGetBySupplierBy", new
                {
SupplierBy = SupplierBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationImageGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationImageGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsHotelInformationImageGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsHotelInformationImageGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationImageGetByImagePath(string ImagePath){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationImageGetByImagePath", new
                {
ImagePath = ImagePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelInformationImageGetByImageUrl(string ImageUrl){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelInformationImageGetByImageUrl", new
                {
ImageUrl = ImageUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationDaysGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationDaysGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationDaysGetByFriday(bool Friday){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationDaysGetByFriday", new
                {
Friday = Friday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsHotelsConfigurationDaysGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsHotelsConfigurationDaysGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationDaysGetByMonday(bool Monday){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationDaysGetByMonday", new
                {
Monday = Monday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationDaysGetBySaturday(bool Saturday){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationDaysGetBySaturday", new
                {
Saturday = Saturday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationDaysGetBySunday(bool Sunday){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationDaysGetBySunday", new
                {
Sunday = Sunday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationDaysGetByThursday(bool Thursday){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationDaysGetByThursday", new
                {
Thursday = Thursday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationDaysGetByTuesday(bool Tuesday){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationDaysGetByTuesday", new
                {
Tuesday = Tuesday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationDaysGetByWednesday(bool Wednesday){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationDaysGetByWednesday", new
                {
Wednesday = Wednesday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByCheckInDateFrom(DateTime CheckInDateFrom){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByCheckInDateFrom", new
                {
CheckInDateFrom = CheckInDateFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByCheckInDateTo(DateTime CheckInDateTo){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByCheckInDateTo", new
                {
CheckInDateTo = CheckInDateTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByCheckInDayId(int CheckInDayId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByCheckInDayId", new
                {
CheckInDayId = CheckInDayId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByCheckOutDayId(int CheckOutDayId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByCheckOutDayId", new
                {
CheckOutDayId = CheckOutDayId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByCheckOutUntil(DateTime CheckOutUntil){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByCheckOutUntil", new
                {
CheckOutUntil = CheckOutUntil
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByEarlyDepartureCostAmount(decimal EarlyDepartureCostAmount){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByEarlyDepartureCostAmount", new
                {
EarlyDepartureCostAmount = EarlyDepartureCostAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByEarlyDepartureCostCurrencyId(int EarlyDepartureCostCurrencyId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByEarlyDepartureCostCurrencyId", new
                {
EarlyDepartureCostCurrencyId = EarlyDepartureCostCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByEarlyDepartureFrom(DateTime EarlyDepartureFrom){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByEarlyDepartureFrom", new
                {
EarlyDepartureFrom = EarlyDepartureFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByEarlyDepartureTo(DateTime EarlyDepartureTo){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByEarlyDepartureTo", new
                {
EarlyDepartureTo = EarlyDepartureTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsHotelsConfigurationGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsHotelsConfigurationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByLateArrivalAmount(int LateArrivalAmount){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByLateArrivalAmount", new
                {
LateArrivalAmount = LateArrivalAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByLateArrivalCurrencyId(int LateArrivalCurrencyId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByLateArrivalCurrencyId", new
                {
LateArrivalCurrencyId = LateArrivalCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByLateArrivalFrom(DateTime LateArrivalFrom){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByLateArrivalFrom", new
                {
LateArrivalFrom = LateArrivalFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByLateArrivalTo(DateTime LateArrivalTo){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByLateArrivalTo", new
                {
LateArrivalTo = LateArrivalTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByMaximumStay(int MaximumStay){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByMaximumStay", new
                {
MaximumStay = MaximumStay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByMinAgeStay(int MinAgeStay){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByMinAgeStay", new
                {
MinAgeStay = MinAgeStay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByMinimumStay(byte MinimumStay){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByMinimumStay", new
                {
MinimumStay = MinimumStay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetByReleaseDay(int ReleaseDay){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetByReleaseDay", new
                {
ReleaseDay = ReleaseDay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetBySecurityDepositAmount(int SecurityDepositAmount){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetBySecurityDepositAmount", new
                {
SecurityDepositAmount = SecurityDepositAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetBySecurityDepositCurrencyId(int SecurityDepositCurrencyId){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetBySecurityDepositCurrencyId", new
                {
SecurityDepositCurrencyId = SecurityDepositCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetCheckInDateFromBetween(DateTime CheckInDateFromStart,DateTime CheckInDateFromEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetCheckInDateFromBetween", new
                {
CheckInDateFromStart = CheckInDateFromStart
,CheckInDateFromEnd = CheckInDateFromEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetCheckInDateToBetween(DateTime CheckInDateToStart,DateTime CheckInDateToEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetCheckInDateToBetween", new
                {
CheckInDateToStart = CheckInDateToStart
,CheckInDateToEnd = CheckInDateToEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetCheckOutUntilBetween(DateTime CheckOutUntilStart,DateTime CheckOutUntilEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetCheckOutUntilBetween", new
                {
CheckOutUntilStart = CheckOutUntilStart
,CheckOutUntilEnd = CheckOutUntilEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetEarlyDepartureFromBetween(DateTime EarlyDepartureFromStart,DateTime EarlyDepartureFromEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetEarlyDepartureFromBetween", new
                {
EarlyDepartureFromStart = EarlyDepartureFromStart
,EarlyDepartureFromEnd = EarlyDepartureFromEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetEarlyDepartureToBetween(DateTime EarlyDepartureToStart,DateTime EarlyDepartureToEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetEarlyDepartureToBetween", new
                {
EarlyDepartureToStart = EarlyDepartureToStart
,EarlyDepartureToEnd = EarlyDepartureToEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetLateArrivalFromBetween(DateTime LateArrivalFromStart,DateTime LateArrivalFromEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetLateArrivalFromBetween", new
                {
LateArrivalFromStart = LateArrivalFromStart
,LateArrivalFromEnd = LateArrivalFromEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsConfigurationGetLateArrivalToBetween(DateTime LateArrivalToStart,DateTime LateArrivalToEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsConfigurationGetLateArrivalToBetween", new
                {
LateArrivalToStart = LateArrivalToStart
,LateArrivalToEnd = LateArrivalToEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsMenuGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsMenuGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsHotelsMenuGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsHotelsMenuGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsHotelsMenuGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyContractsHotelsMenuGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByCreateBy(int CreateBy){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByCreateBy", new
                {
CreateBy = CreateBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByCreateDate(DateTime CreateDate){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByCreateDate", new
                {
CreateDate = CreateDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsInsuranceBasicDataGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsInsuranceBasicDataGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByImagePath(string ImagePath){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByImagePath", new
                {
ImagePath = ImagePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByImageUrl(string ImageUrl){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByImageUrl", new
                {
ImageUrl = ImageUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByInsuranceSelectedProductTypeId(int InsuranceSelectedProductTypeId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByInsuranceSelectedProductTypeId", new
                {
InsuranceSelectedProductTypeId = InsuranceSelectedProductTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByInsuranceTypeId(int InsuranceTypeId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByInsuranceTypeId", new
                {
InsuranceTypeId = InsuranceTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByIsActive(bool IsActive){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByPolicyName(string PolicyName){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByPolicyName", new
                {
PolicyName = PolicyName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByPolicyNumber(string PolicyNumber){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByPolicyNumber", new
                {
PolicyNumber = PolicyNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetBySelectByDefault(bool SelectByDefault){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetBySelectByDefault", new
                {
SelectByDefault = SelectByDefault
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetBySelectedInsuranceLanguageId(int SelectedInsuranceLanguageId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetBySelectedInsuranceLanguageId", new
                {
SelectedInsuranceLanguageId = SelectedInsuranceLanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetByServiceProviderId(int ServiceProviderId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetByServiceProviderId", new
                {
ServiceProviderId = ServiceProviderId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetBySupplierId(int SupplierId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetBySupplierId", new
                {
SupplierId = SupplierId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceBasicDataGetCreateDateBetween(DateTime CreateDateStart,DateTime CreateDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceBasicDataGetCreateDateBetween", new
                {
CreateDateStart = CreateDateStart
,CreateDateEnd = CreateDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceSelectedLanguageGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceSelectedLanguageGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsInsuranceSelectedLanguageGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsInsuranceSelectedLanguageGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceSelectedLanguageGetByInsuranceDescription(string InsuranceDescription){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceSelectedLanguageGetByInsuranceDescription", new
                {
InsuranceDescription = InsuranceDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceSelectedLanguageGetByInsurancesId(int InsurancesId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceSelectedLanguageGetByInsurancesId", new
                {
InsurancesId = InsurancesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceSelectedLanguageGetByLangId(int LangId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceSelectedLanguageGetByLangId", new
                {
LangId = LangId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceSelectedLanguageGetByVoucherRemarks(string VoucherRemarks){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceSelectedLanguageGetByVoucherRemarks", new
                {
VoucherRemarks = VoucherRemarks
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceSelectedProductTypeGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceSelectedProductTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsInsuranceSelectedProductTypeGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsInsuranceSelectedProductTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceSelectedProductTypeGetByInsuranceId(int InsuranceId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceSelectedProductTypeGetByInsuranceId", new
                {
InsuranceId = InsuranceId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceSelectedProductTypeGetByProductTypeId(int ProductTypeId){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceSelectedProductTypeGetByProductTypeId", new
                {
ProductTypeId = ProductTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceTypeGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ContractsInsuranceTypeGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyContractsInsuranceTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ContractsInsuranceTypeGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyContractsInsuranceTypeGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CreditDepositGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyCreditDepositGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CreditDepositGetByBalanceWarningAmount(decimal AgencyBalanceWarningAmount){
            try
            {
                return connection.Query<Agency>("AgencyCreditDepositGetByAgencyBalanceWarningAmount", new
                {
AgencyBalanceWarningAmount = AgencyBalanceWarningAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CreditDepositGetByBalanceWarningCurrencyId(int AgencyBalanceWarningCurrencyId){
            try
            {
                return connection.Query<Agency>("AgencyCreditDepositGetByAgencyBalanceWarningCurrencyId", new
                {
AgencyBalanceWarningCurrencyId = AgencyBalanceWarningCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CreditDepositGetByBalanceWarningIsByPercentage(int AgencyBalanceWarningIsByPercentage){
            try
            {
                return connection.Query<Agency>("AgencyCreditDepositGetByAgencyBalanceWarningIsByPercentage", new
                {
AgencyBalanceWarningIsByPercentage = AgencyBalanceWarningIsByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CreditDepositGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyCreditDepositGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CreditDepositGetByBalanceAmount(decimal BalanceAmount){
            try
            {
                return connection.Query<Agency>("AgencyCreditDepositGetByBalanceAmount", new
                {
BalanceAmount = BalanceAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CreditDepositGetByBalanceCurrencyId(int BalanceCurrencyId){
            try
            {
                return connection.Query<Agency>("AgencyCreditDepositGetByBalanceCurrencyId", new
                {
BalanceCurrencyId = BalanceCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency CreditDepositGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyCreditDepositGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> CreditDepositGetBySendBalanceWarning(bool SendBalanceWarning){
            try
            {
                return connection.Query<Agency>("AgencyCreditDepositGetBySendBalanceWarning", new
                {
SendBalanceWarning = SendBalanceWarning
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetAll(){
            try
            {
                return connection.Query<Agency>("AgencyGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByAddress(string Address){
            try
            {
                return connection.Query<Agency>("AgencyGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByManager(int AgencyManager){
            try
            {
                return connection.Query<Agency>("AgencyGetByAgencyManager", new
                {
AgencyManager = AgencyManager
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByBillingEmails(string BillingEmails){
            try
            {
                return connection.Query<Agency>("AgencyGetByBillingEmails", new
                {
BillingEmails = BillingEmails
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByBusinessName(string BusinessName){
            try
            {
                return connection.Query<Agency>("AgencyGetByBusinessName", new
                {
BusinessName = BusinessName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByCity(string City){
            try
            {
                return connection.Query<Agency>("AgencyGetByCity", new
                {
City = City
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByContactPersonLastName(string ContactPersonLastName){
            try
            {
                return connection.Query<Agency>("AgencyGetByContactPersonLastName", new
                {
ContactPersonLastName = ContactPersonLastName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByContactPersonName(string ContactPersonName){
            try
            {
                return connection.Query<Agency>("AgencyGetByContactPersonName", new
                {
ContactPersonName = ContactPersonName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByCountry(int Country){
            try
            {
                return connection.Query<Agency>("AgencyGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDeferredPaymentAllowed(bool DeferredPaymentAllowed){
            try
            {
                return connection.Query<Agency>("AgencyGetByDeferredPaymentAllowed", new
                {
DeferredPaymentAllowed = DeferredPaymentAllowed
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDeferredPaymentDays(int DeferredPaymentDays){
            try
            {
                return connection.Query<Agency>("AgencyGetByDeferredPaymentDays", new
                {
DeferredPaymentDays = DeferredPaymentDays
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDeferredPaymentLimit(decimal DeferredPaymentLimit){
            try
            {
                return connection.Query<Agency>("AgencyGetByDeferredPaymentLimit", new
                {
DeferredPaymentLimit = DeferredPaymentLimit
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDeferredPaymentLimitCurrency(int DeferredPaymentLimitCurrency){
            try
            {
                return connection.Query<Agency>("AgencyGetByDeferredPaymentLimitCurrency", new
                {
DeferredPaymentLimitCurrency = DeferredPaymentLimitCurrency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDocumentNumber(string DocumentNumber){
            try
            {
                return connection.Query<Agency>("AgencyGetByDocumentNumber", new
                {
DocumentNumber = DocumentNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByEmail(string Email){
            try
            {
                return connection.Query<Agency>("AgencyGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByExternalId(int ExternalId){
            try
            {
                return connection.Query<Agency>("AgencyGetByExternalId", new
                {
ExternalId = ExternalId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByGDSIdentifierForGalileo(string GDSIdentifierForGalileo){
            try
            {
                return connection.Query<Agency>("AgencyGetByGDSIdentifierForGalileo", new
                {
GDSIdentifierForGalileo = GDSIdentifierForGalileo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByHasCreditOrDepositPaymentAllowed(bool HasCreditOrDepositPaymentAllowed){
            try
            {
                return connection.Query<Agency>("AgencyGetByHasCreditOrDepositPaymentAllowed", new
                {
HasCreditOrDepositPaymentAllowed = HasCreditOrDepositPaymentAllowed
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByInvoiceName(string InvoiceName){
            try
            {
                return connection.Query<Agency>("AgencyGetByInvoiceName", new
                {
InvoiceName = InvoiceName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByInvoiceTypeId(int InvoiceTypeId){
            try
            {
                return connection.Query<Agency>("AgencyGetByInvoiceTypeId", new
                {
InvoiceTypeId = InvoiceTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByManagementGroup(string ManagementGroup){
            try
            {
                return connection.Query<Agency>("AgencyGetByManagementGroup", new
                {
ManagementGroup = ManagementGroup
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByMinimumFirstPaymentAmount(int MinimumFirstPaymentAmount){
            try
            {
                return connection.Query<Agency>("AgencyGetByMinimumFirstPaymentAmount", new
                {
MinimumFirstPaymentAmount = MinimumFirstPaymentAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByMinimumFirstPaymentIsByPercentage(bool MinimumFirstPaymentIsByPercentage){
            try
            {
                return connection.Query<Agency>("AgencyGetByMinimumFirstPaymentIsByPercentage", new
                {
MinimumFirstPaymentIsByPercentage = MinimumFirstPaymentIsByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByPhoneNo(string PhoneNo){
            try
            {
                return connection.Query<Agency>("AgencyGetByPhoneNo", new
                {
PhoneNo = PhoneNo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByPostalCode(string PostalCode){
            try
            {
                return connection.Query<Agency>("AgencyGetByPostalCode", new
                {
PostalCode = PostalCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByProvience(string Provience){
            try
            {
                return connection.Query<Agency>("AgencyGetByProvience", new
                {
Provience = Provience
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByRegion(string Region){
            try
            {
                return connection.Query<Agency>("AgencyGetByRegion", new
                {
Region = Region
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByRemarks(string Remarks){
            try
            {
                return connection.Query<Agency>("AgencyGetByRemarks", new
                {
Remarks = Remarks
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByStatu(int Statu){
            try
            {
                return connection.Query<Agency>("AgencyGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetBySummerHours(string SummerHours){
            try
            {
                return connection.Query<Agency>("AgencyGetBySummerHours", new
                {
SummerHours = SummerHours
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByTaxes(double Taxes){
            try
            {
                return connection.Query<Agency>("AgencyGetByTaxes", new
                {
Taxes = Taxes
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByWhatsAppNo(string WhatsAppNo){
            try
            {
                return connection.Query<Agency>("AgencyGetByWhatsAppNo", new
                {
WhatsAppNo = WhatsAppNo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByWinterHours(string WinterHours){
            try
            {
                return connection.Query<Agency>("AgencyGetByWinterHours", new
                {
WinterHours = WinterHours
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ManagerGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyManagerGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ManagerGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyManagerGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ManagerGetByUserId(int AgencyUserId){
            try
            {
                return connection.Query<Agency>("AgencyManagerGetByAgencyUserId", new
                {
AgencyUserId = AgencyUserId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency ManagerGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyManagerGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ManagerGetByMicrositeId(int MicrositeId){
            try
            {
                return connection.Query<Agency>("AgencyManagerGetByMicrositeId", new
                {
MicrositeId = MicrositeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> ManagerGetByStatu(int Statu){
            try
            {
                return connection.Query<Agency>("AgencyManagerGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetByApiId(int ApiId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetByApiProductId(int ApiProductId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetByApiProductId", new
                {
ApiProductId = ApiProductId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetByHasConsolidate(bool HasConsolidate){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetByHasConsolidate", new
                {
HasConsolidate = HasConsolidate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteApiProductProvidersGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteApiProductProvidersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetByPriority(int Priority){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetByPriority", new
                {
Priority = Priority
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteApiProductProvidersGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteApiProductProvidersGetCreatedDateBetween", new
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
public List<Agency> MicroSiteDesignGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDesignGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDesignGetByMicroSiteId(int AgencyMicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDesignGetByAgencyMicroSiteId", new
                {
AgencyMicroSiteId = AgencyMicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDesignGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDesignGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDesignGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDesignGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteDesignGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteDesignGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDesignGetByProductType(int ProductType){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDesignGetByProductType", new
                {
ProductType = ProductType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDesignGetByStatu(int Statu){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDesignGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDesignGetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDesignGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDesignGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDesignGetCreatedDateBetween", new
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
public List<Agency> MicroSiteDomainLanguageSettingsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainLanguageSettingsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainLanguageSettingsGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainLanguageSettingsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainLanguageSettingsGetByDomainId(int DomainId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainLanguageSettingsGetByDomainId", new
                {
DomainId = DomainId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteDomainLanguageSettingsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteDomainLanguageSettingsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainLanguageSettingsGetByIsDefault(bool IsDefault){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainLanguageSettingsGetByIsDefault", new
                {
IsDefault = IsDefault
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainLanguageSettingsGetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainLanguageSettingsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainLanguageSettingsGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainLanguageSettingsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainLanguageSettingsGetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainLanguageSettingsGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByAdwordsId(string AdwordsId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByAdwordsId", new
                {
AdwordsId = AdwordsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByAdwordsLabel(string AdwordsLabel){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByAdwordsLabel", new
                {
AdwordsLabel = AdwordsLabel
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByBingAds(string BingAds){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByBingAds", new
                {
BingAds = BingAds
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByDefaultLanguageId(int DefaultLanguageId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByDefaultLanguageId", new
                {
DefaultLanguageId = DefaultLanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByDomainHostIP(string DomainHostIP){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByDomainHostIP", new
                {
DomainHostIP = DomainHostIP
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByDomainUrl(string DomainUrl){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByDomainUrl", new
                {
DomainUrl = DomainUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByFacebookDomainVerification(string FacebookDomainVerification){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByFacebookDomainVerification", new
                {
FacebookDomainVerification = FacebookDomainVerification
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByFacebookPixelId(string FacebookPixelId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByFacebookPixelId", new
                {
FacebookPixelId = FacebookPixelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByGoogleSiteVerification(string GoogleSiteVerification){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByGoogleSiteVerification", new
                {
GoogleSiteVerification = GoogleSiteVerification
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByGoogleTagManagerId(string GoogleTagManagerId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByGoogleTagManagerId", new
                {
GoogleTagManagerId = GoogleTagManagerId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByGtagId(string GtagId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByGtagId", new
                {
GtagId = GtagId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteDomainsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteDomainsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByKayakPartnerCode(string KayakPartnerCode){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByKayakPartnerCode", new
                {
KayakPartnerCode = KayakPartnerCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetBySiteMapJson(string SiteMapJson){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetBySiteMapJson", new
                {
SiteMapJson = SiteMapJson
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByTradeTrackerClientId(string TradeTrackerClientId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByTradeTrackerClientId", new
                {
TradeTrackerClientId = TradeTrackerClientId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByTradeTrackerPidOthers(string TradeTrackerPidOthers){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByTradeTrackerPidOthers", new
                {
TradeTrackerPidOthers = TradeTrackerPidOthers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByTradeTrackerProductOnlyAccommodation(string TradeTrackerProductOnlyAccommodation){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByTradeTrackerProductOnlyAccommodation", new
                {
TradeTrackerProductOnlyAccommodation = TradeTrackerProductOnlyAccommodation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteDomainsGetByVePixelId(string VePixelId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteDomainsGetByVePixelId", new
                {
VePixelId = VePixelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePaymentProvidersGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePaymentProvidersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePaymentProvidersGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePaymentProvidersGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePaymentProvidersGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePaymentProvidersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePaymentProvidersGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePaymentProvidersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSitePaymentProvidersGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSitePaymentProvidersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePaymentProvidersGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePaymentProvidersGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePaymentProvidersGetByPaymentTypeId(int PaymentTypeId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePaymentProvidersGetByPaymentTypeId", new
                {
PaymentTypeId = PaymentTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePaymentProvidersGetByStatu(int Statu){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePaymentProvidersGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePaymentProvidersGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePaymentProvidersGetCreatedDateBetween", new
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
public List<Agency> MicroSitePropertiesGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByMicroSiteId(int AgencyMicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByAgencyMicroSiteId", new
                {
AgencyMicroSiteId = AgencyMicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByDefaultLogo(string DefaultLogo){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByDefaultLogo", new
                {
DefaultLogo = DefaultLogo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByFavicon(string Favicon){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByFavicon", new
                {
Favicon = Favicon
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByHasLogoOnHeader(bool HasLogoOnHeader){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByHasLogoOnHeader", new
                {
HasLogoOnHeader = HasLogoOnHeader
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSitePropertiesGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSitePropertiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByMetaDescription(string MetaDescription){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByMetaDescription", new
                {
MetaDescription = MetaDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByMetaTitle(string MetaTitle){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByMetaTitle", new
                {
MetaTitle = MetaTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByMobileLogo(string MobileLogo){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByMobileLogo", new
                {
MobileLogo = MobileLogo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByOgDescription(string OgDescription){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByOgDescription", new
                {
OgDescription = OgDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByOgImage(string OgImage){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByOgImage", new
                {
OgImage = OgImage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByOgTitle(string OgTitle){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByOgTitle", new
                {
OgTitle = OgTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitePropertiesGetByWhiteLogo(string WhiteLogo){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitePropertiesGetByWhiteLogo", new
                {
WhiteLogo = WhiteLogo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingPassengerDataGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingPassengerDataGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingPassengerDataGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingPassengerDataGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingPassengerDataGetByExcludeMiss(bool ExcludeMiss){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingPassengerDataGetByExcludeMiss", new
                {
ExcludeMiss = ExcludeMiss
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingPassengerDataGetByExcludeMrs(bool ExcludeMrs){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingPassengerDataGetByExcludeMrs", new
                {
ExcludeMrs = ExcludeMrs
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingPassengerDataGetByExcludeNie(bool ExcludeNie){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingPassengerDataGetByExcludeNie", new
                {
ExcludeNie = ExcludeNie
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingPassengerDataGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingPassengerDataGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingPassengerDataGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingPassengerDataGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingPassengerDataGetByRequiredPassengerData(int RequiredPassengerData){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingPassengerDataGetByRequiredPassengerData", new
                {
RequiredPassengerData = RequiredPassengerData
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingPassengerDataGetBySearchCustomer(bool SearchCustomer){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingPassengerDataGetBySearchCustomer", new
                {
SearchCustomer = SearchCustomer
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsAccommodationSearchResultsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsAccommodationSearchResultsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsAccommodationSearchResultsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsAccommodationSearchResultsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsAccommodationSearchResultsGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsAccommodationSearchResultsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByAllowB2CUserInvoice(int AllowB2CUserInvoice){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByAllowB2CUserInvoice", new
                {
AllowB2CUserInvoice = AllowB2CUserInvoice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByB2BUsersManuelServicesEnable(bool B2BUsersManuelServicesEnable){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByB2BUsersManuelServicesEnable", new
                {
B2BUsersManuelServicesEnable = B2BUsersManuelServicesEnable
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByDefaultReplicatorbookingmodeForB2B(int DefaultReplicatorbookingmodeForB2B){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByDefaultReplicatorbookingmodeForB2B", new
                {
DefaultReplicatorbookingmodeForB2B = DefaultReplicatorbookingmodeForB2B
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByDefaultReplicatorbookingmodeForB2C(int DefaultReplicatorbookingmodeForB2C){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByDefaultReplicatorbookingmodeForB2C", new
                {
DefaultReplicatorbookingmodeForB2C = DefaultReplicatorbookingmodeForB2C
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByEnableCrossSellCrossSelling(bool EnableCrossSellCrossSelling){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellCrossSelling", new
                {
EnableCrossSellCrossSelling = EnableCrossSellCrossSelling
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByEnableCrossSellRentalCars(bool EnableCrossSellRentalCars){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellRentalCars", new
                {
EnableCrossSellRentalCars = EnableCrossSellRentalCars
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByEnableCrossSellTicket(bool EnableCrossSellTicket){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellTicket", new
                {
EnableCrossSellTicket = EnableCrossSellTicket
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByEnableCrossSellTransfers(bool EnableCrossSellTransfers){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellTransfers", new
                {
EnableCrossSellTransfers = EnableCrossSellTransfers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByEnableCrossSellTransports(bool EnableCrossSellTransports){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellTransports", new
                {
EnableCrossSellTransports = EnableCrossSellTransports
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByForOnRequestContracts(bool ForOnRequestContracts){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByForOnRequestContracts", new
                {
ForOnRequestContracts = ForOnRequestContracts
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsBookingProcessGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsBookingProcessGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByMaxToleranceAmountId(int MaxToleranceAmountId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByMaxToleranceAmountId", new
                {
MaxToleranceAmountId = MaxToleranceAmountId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByMaxToleranceCurrencyId(int MaxToleranceCurrencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByMaxToleranceCurrencyId", new
                {
MaxToleranceCurrencyId = MaxToleranceCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByMaxTolerancePrice(decimal MaxTolerancePrice){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByMaxTolerancePrice", new
                {
MaxTolerancePrice = MaxTolerancePrice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByNotifyChangesRequotingSavedIdea(bool NotifyChangesRequotingSavedIdea){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByNotifyChangesRequotingSavedIdea", new
                {
NotifyChangesRequotingSavedIdea = NotifyChangesRequotingSavedIdea
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByPaymentOption(int PaymentOption){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByPaymentOption", new
                {
PaymentOption = PaymentOption
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByRequireBookingProcess(bool RequireAgencyBookingProcess){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByRequireAgencyBookingProcess", new
                {
RequireAgencyBookingProcess = RequireAgencyBookingProcess
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetBySelectAppearDigitalBrochuresForB2BUsers(int SelectAppearDigitalBrochuresForB2BUsers){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetBySelectAppearDigitalBrochuresForB2BUsers", new
                {
SelectAppearDigitalBrochuresForB2BUsers = SelectAppearDigitalBrochuresForB2BUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetBySelectAppearDigitalBrochuresForB2CUsers(int SelectAppearDigitalBrochuresForB2CUsers){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetBySelectAppearDigitalBrochuresForB2CUsers", new
                {
SelectAppearDigitalBrochuresForB2CUsers = SelectAppearDigitalBrochuresForB2CUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetBySetFlightTaxesAsNonCommissionAble(bool SetFlightTaxesAsNonCommissionAble){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetBySetFlightTaxesAsNonCommissionAble", new
                {
SetFlightTaxesAsNonCommissionAble = SetFlightTaxesAsNonCommissionAble
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingProcessGetByShowFareBreakdownOnTransports(bool ShowFareBreakdownOnTransports){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingProcessGetByShowFareBreakdownOnTransports", new
                {
ShowFareBreakdownOnTransports = ShowFareBreakdownOnTransports
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingReplicatorModeGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingReplicatorModeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingReplicatorModeGetByCustomizeIt(bool CustomizeIt){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingReplicatorModeGetByCustomizeIt", new
                {
CustomizeIt = CustomizeIt
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingReplicatorModeGetByDirectBookingWithoutChanges(bool DirectBookingWithoutChanges){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingReplicatorModeGetByDirectBookingWithoutChanges", new
                {
DirectBookingWithoutChanges = DirectBookingWithoutChanges
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsBookingReplicatorModeGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsBookingReplicatorModeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsBookingReplicatorModeGetByIWantIt(bool IWantIt){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsBookingReplicatorModeGetByIWantIt", new
                {
IWantIt = IWantIt
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetByAvoidSendBookingMailToOperator(bool AvoidSendBookingMailToOperator){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetByAvoidSendBookingMailToOperator", new
                {
AvoidSendBookingMailToOperator = AvoidSendBookingMailToOperator
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetByExcludePricesBookingsOnlinePDFVoucher(bool ExcludePricesBookingsOnlinePDFVoucher){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetByExcludePricesBookingsOnlinePDFVoucher", new
                {
ExcludePricesBookingsOnlinePDFVoucher = ExcludePricesBookingsOnlinePDFVoucher
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetByFromEmail(bool FromEmailAgency){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetByFromEmailAgency", new
                {
FromEmailAgency = FromEmailAgency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetByHideCoverPageAndDayByDayPdf(bool HideCoverPageAndDayByDayPdf){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetByHideCoverPageAndDayByDayPdf", new
                {
HideCoverPageAndDayByDayPdf = HideCoverPageAndDayByDayPdf
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsEmailVoucherGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsEmailVoucherGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetByPrintPDFVoucherOneService(bool PrintPDFVoucherOneService){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetByPrintPDFVoucherOneService", new
                {
PrintPDFVoucherOneService = PrintPDFVoucherOneService
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetBySendBookingEmailFrom(bool SendBookingEmailFromAgency){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetBySendBookingEmailFromAgency", new
                {
SendBookingEmailFromAgency = SendBookingEmailFromAgency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEmailVoucherGetBySendMoAppEmailReminder(bool SendMoAppEmailReminder){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEmailVoucherGetBySendMoAppEmailReminder", new
                {
SendMoAppEmailReminder = SendMoAppEmailReminder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEnableMultiDayGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEnableMultiDayGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsEnableMultiDayGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsEnableMultiDayGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsEnableMultiDayGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsEnableMultiDayGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsGeneralGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsGeneralGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsGeneralGetByContractFile(string AgencyContractFile){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsGeneralGetByAgencyContractFile", new
                {
AgencyContractFile = AgencyContractFile
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsGeneralGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsGeneralGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsGeneralGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsGeneralGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsGeneralGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsGeneralGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsGeneralGetByHasManagementFee(bool HasAgencyManagementFee){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsGeneralGetByHasAgencyManagementFee", new
                {
HasAgencyManagementFee = HasAgencyManagementFee
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsGeneralGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsGeneralGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsGeneralGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsGeneralGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsGeneralGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsGeneralGetCreatedDateBetween", new
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
public List<Agency> MicroSiteSettingsHelpSupportGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsHelpSupportGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsHelpSupportGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsHelpSupportGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsHelpSupportGetByHideFeedback(bool HideFeedback){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsHelpSupportGetByHideFeedback", new
                {
HideFeedback = HideFeedback
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsHelpSupportGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsHelpSupportGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsHelpSupportGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsHelpSupportGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsHelpSupportGetByOpenHelpVideosModalNewTab(bool OpenHelpVideosModalNewTab){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsHelpSupportGetByOpenHelpVideosModalNewTab", new
                {
OpenHelpVideosModalNewTab = OpenHelpVideosModalNewTab
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByAddress(string Address){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByBankDetails(string BankDetails){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByBankDetails", new
                {
BankDetails = BankDetails
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByBillingDetails(string BillingDetails){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByBillingDetails", new
                {
BillingDetails = BillingDetails
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByCity(string City){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByCity", new
                {
City = City
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByCountry(int Country){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByDirectOperatorToBilling(bool DirectOperatorToAgencyBilling){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByDirectOperatorToAgencyBilling", new
                {
DirectOperatorToAgencyBilling = DirectOperatorToAgencyBilling
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByEmail(string Email){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsInvoiceGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsInvoiceGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByLegalFooter(string LegalFooter){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByLegalFooter", new
                {
LegalFooter = LegalFooter
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByMailBody(string MailBody){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByMailBody", new
                {
MailBody = MailBody
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByNumberPrefix(string NumberPrefix){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByNumberPrefix", new
                {
NumberPrefix = NumberPrefix
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByTaxesByPercentage(decimal TaxesByPercentage){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByTaxesByPercentage", new
                {
TaxesByPercentage = TaxesByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByTaxesDetails(string TaxesDetails){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByTaxesDetails", new
                {
TaxesDetails = TaxesDetails
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsInvoiceGetByVAT(string VAT){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsInvoiceGetByVAT", new
                {
VAT = VAT
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByAskForIdAndBirthdate(bool AskForIdAndBirthdate){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByAskForIdAndBirthdate", new
                {
AskForIdAndBirthdate = AskForIdAndBirthdate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsOtherGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsOtherGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByIdeaBrochureIndexing(bool IdeaBrochureIndexing){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByIdeaBrochureIndexing", new
                {
IdeaBrochureIndexing = IdeaBrochureIndexing
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByPendingPaymentAutoCancellation(bool PendingPaymentAutoCancellation){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByPendingPaymentAutoCancellation", new
                {
PendingPaymentAutoCancellation = PendingPaymentAutoCancellation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByShowIdInDropdownInsteadOfName(bool ShowAgencyIdInDropdownInsteadOfAgencyName){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByShowAgencyIdInDropdownInsteadOfAgencyName", new
                {
ShowAgencyIdInDropdownInsteadOfAgencyName = ShowAgencyIdInDropdownInsteadOfAgencyName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByShowImagePaymentMethodInFooter(bool ShowImagePaymentMethodInFooter){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByShowImagePaymentMethodInFooter", new
                {
ShowImagePaymentMethodInFooter = ShowImagePaymentMethodInFooter
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByShowTotalPriceInBrochure(bool ShowTotalPriceInBrochure){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByShowTotalPriceInBrochure", new
                {
ShowTotalPriceInBrochure = ShowTotalPriceInBrochure
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByShowWhatsAppGetButton(bool ShowWhatsAppGetButton){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByShowWhatsAppGetButton", new
                {
ShowWhatsAppGetButton = ShowWhatsAppGetButton
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsOtherGetByWhatsAppNumber(string WhatsAppNumber){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsOtherGetByWhatsAppNumber", new
                {
WhatsAppNumber = WhatsAppNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsPaymetOptionsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsPaymetOptionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsPaymetOptionsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsPaymetOptionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsPaymetOptionsGetByOptionsName(string OptionsName){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsPaymetOptionsGetByOptionsName", new
                {
OptionsName = OptionsName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsRequestInvoicesGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsRequestInvoicesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsRequestInvoicesGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsRequestInvoicesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsRequestInvoicesGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsRequestInvoicesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsRequiredPassengerGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsRequiredPassengerGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsRequiredPassengerGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsRequiredPassengerGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsRequiredPassengerGetByIsActive(bool IsActive){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsRequiredPassengerGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsRequiredPassengerGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsRequiredPassengerGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchEngineGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchEngineGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchEngineGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchEngineGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchEngineGetByDefaultAvailabilityTimeoutDuration(int DefaultAvailabilityTimeoutDuration){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchEngineGetByDefaultAvailabilityTimeoutDuration", new
                {
DefaultAvailabilityTimeoutDuration = DefaultAvailabilityTimeoutDuration
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchEngineGetByDefaultReleaseDaysB2BUsers(int DefaultReleaseDaysB2BUsers){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchEngineGetByDefaultReleaseDaysB2BUsers", new
                {
DefaultReleaseDaysB2BUsers = DefaultReleaseDaysB2BUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchEngineGetByDefaultReleaseDaysForEarlyBooking(int DefaultReleaseDaysForEarlyBooking){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchEngineGetByDefaultReleaseDaysForEarlyBooking", new
                {
DefaultReleaseDaysForEarlyBooking = DefaultReleaseDaysForEarlyBooking
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchEngineGetByDefaultReleaseDaysOtherUsers(int DefaultReleaseDaysOtherUsers){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchEngineGetByDefaultReleaseDaysOtherUsers", new
                {
DefaultReleaseDaysOtherUsers = DefaultReleaseDaysOtherUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsSearchEngineGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsSearchEngineGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchEngineGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchEngineGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchEngineGetByMinimumNightAllowed(int MinimumNightAllowed){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchEngineGetByMinimumNightAllowed", new
                {
MinimumNightAllowed = MinimumNightAllowed
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByAccommodationSearchResults(int AccommodationSearchResults){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByAccommodationSearchResults", new
                {
AccommodationSearchResults = AccommodationSearchResults
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByMicroSiteSettingEnableMultiDay(int AgencyMicroSiteSettingEnableMultiDay){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByAgencyMicroSiteSettingEnableMultiDay", new
                {
AgencyMicroSiteSettingEnableMultiDay = AgencyMicroSiteSettingEnableMultiDay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByMicroSiteSettingsAccommodationSortType(int AgencyMicroSiteSettingsAccommodationSortType){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByAgencyMicroSiteSettingsAccommodationSortType", new
                {
AgencyMicroSiteSettingsAccommodationSortType = AgencyMicroSiteSettingsAccommodationSortType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByMicroSiteSettingsTicketSortType(int AgencyMicroSiteSettingsTicketSortType){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByAgencyMicroSiteSettingsTicketSortType", new
                {
AgencyMicroSiteSettingsTicketSortType = AgencyMicroSiteSettingsTicketSortType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByAskForDepartureLocationHolidayPackage(bool AskForDepartureLocationHolidayPackage){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByAskForDepartureLocationHolidayPackage", new
                {
AskForDepartureLocationHolidayPackage = AskForDepartureLocationHolidayPackage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByB2BUsersSeeProvidersQuotingService(bool B2BUsersSeeProvidersQuotingService){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByB2BUsersSeeProvidersQuotingService", new
                {
B2BUsersSeeProvidersQuotingService = B2BUsersSeeProvidersQuotingService
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByDonotShowTourProviderB2BUsers(bool DonotShowTourProviderB2BUsers){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByDonotShowTourProviderB2BUsers", new
                {
DonotShowTourProviderB2BUsers = DonotShowTourProviderB2BUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByDonotShowTourProviderB2CUsers(bool DonotShowTourProviderB2CUsers){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByDonotShowTourProviderB2CUsers", new
                {
DonotShowTourProviderB2CUsers = DonotShowTourProviderB2CUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByEnableRequestActivities(bool EnableRequestActivities){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByEnableRequestActivities", new
                {
EnableRequestActivities = EnableRequestActivities
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsSearchSettingsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByInAccommodationSearchEngineAllowSearchHotelName(bool InAccommodationSearchEngineAllowSearchHotelName){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByInAccommodationSearchEngineAllowSearchHotelName", new
                {
InAccommodationSearchEngineAllowSearchHotelName = InAccommodationSearchEngineAllowSearchHotelName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByInAccommodationSearchEngineAllowSearchInterestPoint(bool InAccommodationSearchEngineAllowSearchInterestPoint){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByInAccommodationSearchEngineAllowSearchInterestPoint", new
                {
InAccommodationSearchEngineAllowSearchInterestPoint = InAccommodationSearchEngineAllowSearchInterestPoint
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetBySameListOriginsListDestinations(bool SameListOriginsListDestinations){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetBySameListOriginsListDestinations", new
                {
SameListOriginsListDestinations = SameListOriginsListDestinations
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetBySearchBoxDropdownMenuFormatAutoComplete(bool SearchBoxDropdownMenuFormatAutoComplete){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetBySearchBoxDropdownMenuFormatAutoComplete", new
                {
SearchBoxDropdownMenuFormatAutoComplete = SearchBoxDropdownMenuFormatAutoComplete
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetBySelectHolidayPackageSortType(int SelectHolidayPackageSortType){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetBySelectHolidayPackageSortType", new
                {
SelectHolidayPackageSortType = SelectHolidayPackageSortType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetBySelectTransportSortType(int SelectTransportSortType){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetBySelectTransportSortType", new
                {
SelectTransportSortType = SelectTransportSortType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByShowLocationSearchbox(bool ShowLocationSearchbox){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByShowLocationSearchbox", new
                {
ShowLocationSearchbox = ShowLocationSearchbox
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByShowThemesHomePageSlidingFormat(bool ShowThemesHomePageSlidingFormat){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByShowThemesHomePageSlidingFormat", new
                {
ShowThemesHomePageSlidingFormat = ShowThemesHomePageSlidingFormat
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSearchSettingsGetByTicketSearchResultsUseThisViewResult(int TicketSearchResultsUseThisViewResult){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSearchSettingsGetByTicketSearchResultsUseThisViewResult", new
                {
TicketSearchResultsUseThisViewResult = TicketSearchResultsUseThisViewResult
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSortTypeGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSortTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsSortTypeGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsSortTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsSortTypeGetBySortByName(string SortByName){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsSortTypeGetBySortByName", new
                {
SortByName = SortByName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsTermsConditionsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsTermsConditionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsTermsConditionsGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsTermsConditionsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsTermsConditionsGetByGDPRCheckBoxes(bool GDPRCheckBoxes){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsTermsConditionsGetByGDPRCheckBoxes", new
                {
GDPRCheckBoxes = GDPRCheckBoxes
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSiteSettingsTermsConditionsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSiteSettingsTermsConditionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsTermsConditionsGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsTermsConditionsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsTermsConditionsGetByPackageTerms(bool PackageTerms){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsTermsConditionsGetByPackageTerms", new
                {
PackageTerms = PackageTerms
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSiteSettingsTermsConditionsGetByVisaTerms(bool VisaTerms){
            try
            {
                return connection.Query<Agency>("AgencyMicroSiteSettingsTermsConditionsGetByVisaTerms", new
                {
VisaTerms = VisaTerms
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetByCollectivePassword(string CollectivePassword){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetByCollectivePassword", new
                {
CollectivePassword = CollectivePassword
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetByDomain(string Domain){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetByDomain", new
                {
Domain = Domain
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSitesGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSitesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetByRedirectUrl(string RedirectUrl){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetByRedirectUrl", new
                {
RedirectUrl = RedirectUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetBySubDomain(string SubDomain){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetBySubDomain", new
                {
SubDomain = SubDomain
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesGetCreatedDateBetween", new
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
public List<Agency> MicroSitesSettingsEmailConfigurationGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesSettingsEmailConfigurationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesSettingsEmailConfigurationGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesSettingsEmailConfigurationGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesSettingsEmailConfigurationGetByEmail(string Email){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesSettingsEmailConfigurationGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency MicroSitesSettingsEmailConfigurationGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyMicroSitesSettingsEmailConfigurationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesSettingsEmailConfigurationGetByIsValid(bool IsValid){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesSettingsEmailConfigurationGetByIsValid", new
                {
IsValid = IsValid
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> MicroSitesSettingsEmailConfigurationGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencyMicroSitesSettingsEmailConfigurationGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetAll(){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetByAmount(decimal Amount){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetByAmount", new
                {
Amount = Amount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetByApiId(int ApiId){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetByCurrency(string Currency){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetByCurrency", new
                {
Currency = Currency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency SupplementCommissionsGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencySupplementCommissionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetByPercents(int Percents){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetByPercents", new
                {
Percents = Percents
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetBySystemId(int SystemId){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> SupplementCommissionsGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Agency>("AgencySupplementCommissionsGetCreatedDateBetween", new
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
public List<Agency> UsersGetAll(){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetBirthDateBetween(DateTime BirthDateStart,DateTime BirthDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetBirthDateBetween", new
                {
BirthDateStart = BirthDateStart
,BirthDateEnd = BirthDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetById(int AgencyId){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByBirthDate(DateTime BirthDate){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByBirthDate", new
                {
BirthDate = BirthDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByCountry(int Country){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByDocumentNumber(string DocumentNumber){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByDocumentNumber", new
                {
DocumentNumber = DocumentNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByEmail(string Email){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByExternalCode(string ExternalCode){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByExternalCode", new
                {
ExternalCode = ExternalCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByForwardToEmail(string ForwardToEmail){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByForwardToEmail", new
                {
ForwardToEmail = ForwardToEmail
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByGender(int Gender){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByGender", new
                {
Gender = Gender
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency UsersGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyUsersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByIsB2B(bool IsB2B){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByIsB2B", new
                {
IsB2B = IsB2B
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByIsB2C(bool IsB2C){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByIsB2C", new
                {
IsB2C = IsB2C
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByManagementFeeAmount(decimal ManagementFeeAmount){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByManagementFeeAmount", new
                {
ManagementFeeAmount = ManagementFeeAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByManagementFeeByPercentage(bool ManagementFeeByPercentage){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByManagementFeeByPercentage", new
                {
ManagementFeeByPercentage = ManagementFeeByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByManagementFeeCurrencyId(int ManagementFeeCurrencyId){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByManagementFeeCurrencyId", new
                {
ManagementFeeCurrencyId = ManagementFeeCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByName(string Name){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByPassword(string Password){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByPassword", new
                {
Password = Password
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByPhone(string Phone){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByPhone", new
                {
Phone = Phone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByRemark(string Remark){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByRemark", new
                {
Remark = Remark
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByStatu(int Statu){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetBySurname(string Surname){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetBySurname", new
                {
Surname = Surname
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetByUserName(string UserName){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetByUserName", new
                {
UserName = UserName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> UsersGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Agency>("AgencyUsersGetCreatedDateBetween", new
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
 public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
    }
