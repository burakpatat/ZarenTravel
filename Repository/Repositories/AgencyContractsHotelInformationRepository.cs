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
    public class AgencyContractsHotelInformationRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsHotelInformationRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsHotelInformation AgencyContractsHotelInformation)
    {
        try
        {
            return connection.Insert(AgencyContractsHotelInformation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsHotelInformation AgencyContractsHotelInformation)
    {
        try
        {
       return  connection.Update(AgencyContractsHotelInformation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsHotelInformation AgencyContractsHotelInformation)
        {
            try
            {
            return  connection.Delete<AgencyContractsHotelInformation>(AgencyContractsHotelInformation);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsHotelInformation> GetAll(){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByAddress(string Address){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByAgencyıd(int Agencyıd){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByAgencyıd", new
                {
Agencyıd = Agencyıd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByCountryId(int CountryId){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByCountryId", new
                {
CountryId = CountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByCreatedByUser(int CreatedByUser){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByCreatedByUser", new
                {
CreatedByUser = CreatedByUser
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByDescription(string Description){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByEmail(string Email){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByFax(string Fax){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByFax", new
                {
Fax = Fax
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByHotelCategoryId(int HotelCategoryId){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByHotelCategoryId", new
                {
HotelCategoryId = HotelCategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByHotelChainId(int HotelChainId){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByHotelChainId", new
                {
HotelChainId = HotelChainId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByHotelCode(string HotelCode){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByHotelCode", new
                {
HotelCode = HotelCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByHotelFacilityId(int HotelFacilityId){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByHotelFacilityId", new
                {
HotelFacilityId = HotelFacilityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByHotelImageId(int HotelImageId){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByHotelImageId", new
                {
HotelImageId = HotelImageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsHotelInformation GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByIsActive(bool IsActive){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByLangId(int LangId){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByLangId", new
                {
LangId = LangId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByLatitude(decimal Latitude){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByLatitude", new
                {
Latitude = Latitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByLocationName(string LocationName){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByLocationName", new
                {
LocationName = LocationName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByLongitude(decimal Longitude){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByLongitude", new
                {
Longitude = Longitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByName(string Name){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByOnlyHolidayPackage(bool OnlyHolidayPackage){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByOnlyHolidayPackage", new
                {
OnlyHolidayPackage = OnlyHolidayPackage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByPhone(string Phone){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByPhone", new
                {
Phone = Phone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByPossibleDestinations(string PossibleDestinations){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByPossibleDestinations", new
                {
PossibleDestinations = PossibleDestinations
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByPostalCode(string PostalCode){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByPostalCode", new
                {
PostalCode = PostalCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetByRemark(string Remark){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetByRemark", new
                {
Remark = Remark
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelInformation> GetBySupplierBy(int SupplierBy){
            try
            {
                return connection.Query<AgencyContractsHotelInformation>("AgencyContractsHotelInformationGetBySupplierBy", new
                {
SupplierBy = SupplierBy
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
