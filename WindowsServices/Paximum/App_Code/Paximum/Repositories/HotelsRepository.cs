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
    public class HotelsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Hotels Hotels)
    {
        try
        {
            return connection.Insert(Hotels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Hotels Hotels)
    {
        try
        {
       return  connection.Update(Hotels);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Hotels Hotels)
        {
            try
            {
            return  connection.Delete<Hotels>(Hotels);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Hotels> GetAll(){
            try
            {
                return connection.Query<Hotels>("HotelsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByAddress(string Address){
            try
            {
                return connection.Query<Hotels>("HotelsGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByCityId(int CityId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByCityId", new
                {
CityId = CityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByCountryId(int CountryId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByCountryId", new
                {
CountryId = CountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Hotels>("HotelsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Hotels>("HotelsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByDescription(string Description){
            try
            {
                return connection.Query<Hotels>("HotelsGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByFaxNumber(string FaxNumber){
            try
            {
                return connection.Query<Hotels>("HotelsGetByFaxNumber", new
                {
FaxNumber = FaxNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByGeolocationId(int GeolocationId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByGeolocationId", new
                {
GeolocationId = GeolocationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByGiataInfoId(int GiataInfoId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByGiataInfoId", new
                {
GiataInfoId = GiataInfoId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHomePage(string HomePage){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHomePage", new
                {
HomePage = HomePage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHotelBoardsId(int HotelBoardsId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHotelBoardsId", new
                {
HotelBoardsId = HotelBoardsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHotelCategoryId(int HotelCategoryId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHotelCategoryId", new
                {
HotelCategoryId = HotelCategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHotelOffersId(int HotelOffersId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHotelOffersId", new
                {
HotelOffersId = HotelOffersId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHotelPaymentPlansId(int HotelPaymentPlansId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHotelPaymentPlansId", new
                {
HotelPaymentPlansId = HotelPaymentPlansId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHotelSeasonId(int HotelSeasonId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHotelSeasonId", new
                {
HotelSeasonId = HotelSeasonId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByHotelThemesId(int HotelThemesId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByHotelThemesId", new
                {
HotelThemesId = HotelThemesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Hotels GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Hotels>("HotelsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByName(string Name){
            try
            {
                return connection.Query<Hotels>("HotelsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByPhoneNumber(string PhoneNumber){
            try
            {
                return connection.Query<Hotels>("HotelsGetByPhoneNumber", new
                {
PhoneNumber = PhoneNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByProvider(int Provider){
            try
            {
                return connection.Query<Hotels>("HotelsGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Hotels>("HotelsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByThumbnail(string Thumbnail){
            try
            {
                return connection.Query<Hotels>("HotelsGetByThumbnail", new
                {
Thumbnail = Thumbnail
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByThumbnailFull(string ThumbnailFull){
            try
            {
                return connection.Query<Hotels>("HotelsGetByThumbnailFull", new
                {
ThumbnailFull = ThumbnailFull
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByTownId(int TownId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByTownId", new
                {
TownId = TownId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetByVillageId(int VillageId){
            try
            {
                return connection.Query<Hotels>("HotelsGetByVillageId", new
                {
VillageId = VillageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Hotels> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Hotels>("HotelsGetCreatedDateBetween", new
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
