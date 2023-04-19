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
    public class CustomerInformationRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CustomerInformationRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CustomerInformation CustomerInformation)
    {
        try
        {
            return connection.Insert(CustomerInformation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CustomerInformation CustomerInformation)
    {
        try
        {
       return  connection.Update(CustomerInformation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CustomerInformation CustomerInformation)
        {
            try
            {
            return  connection.Delete<CustomerInformation>(CustomerInformation);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CustomerInformation> GetAll(){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByAgentCode(string AgentCode){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByAgentCode", new
                {
AgentCode = AgentCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByAlternativeEmailId(string AlternativeEmailId){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByAlternativeEmailId", new
                {
AlternativeEmailId = AlternativeEmailId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByBookingStatus(int BookingStatus){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByBookingStatus", new
                {
BookingStatus = BookingStatus
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByCountryCode(string CountryCode){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByCountryCode", new
                {
CountryCode = CountryCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByCustomerId_N(int CustomerId_N){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByCustomerId_N", new
                {
CustomerId_N = CustomerId_N
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByDateOfBirth(DateTime DateOfBirth){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByDateOfBirth", new
                {
DateOfBirth = DateOfBirth
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByEmailId(string EmailId){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByEmailId", new
                {
EmailId = EmailId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByFax(string Fax){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByFax", new
                {
Fax = Fax
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByFILE_ID(int FILE_ID){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByFILE_ID", new
                {
FILE_ID = FILE_ID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByFILE_NAME(string FILE_NAME){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByFILE_NAME", new
                {
FILE_NAME = FILE_NAME
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByFirstName(string FirstName){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByFirstName", new
                {
FirstName = FirstName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByGender(string Gender){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByGender", new
                {
Gender = Gender
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CustomerInformation GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CustomerInformation>("CustomerInformationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByLanguageCode(string LanguageCode){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByLanguageCode", new
                {
LanguageCode = LanguageCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByLastName(string LastName){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByLastName", new
                {
LastName = LastName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByMobile(string Mobile){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByMobile", new
                {
Mobile = Mobile
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByModificationDate(DateTime ModificationDate){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByModificationDate", new
                {
ModificationDate = ModificationDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByNationalityCode(int NationalityCode){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByNationalityCode", new
                {
NationalityCode = NationalityCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByOfficeTelephone(string OfficeTelephone){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByOfficeTelephone", new
                {
OfficeTelephone = OfficeTelephone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByRecordDateStamp(DateTime RecordDateStamp){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByRecordDateStamp", new
                {
RecordDateStamp = RecordDateStamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByTelephone(string Telephone){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByTelephone", new
                {
Telephone = Telephone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByTitle(string Title){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByTitle", new
                {
Title = Title
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByTotalFare(decimal TotalFare){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByTotalFare", new
                {
TotalFare = TotalFare
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByTotalInfantcount(decimal TotalInfantcount){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByTotalInfantcount", new
                {
TotalInfantcount = TotalInfantcount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByTotalpaxcount(decimal Totalpaxcount){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByTotalpaxcount", new
                {
Totalpaxcount = Totalpaxcount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetByTotalTaxChg(decimal TotalTaxChg){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetByTotalTaxChg", new
                {
TotalTaxChg = TotalTaxChg
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetDateOfBirthBetween(DateTime DateOfBirthStart,DateTime DateOfBirthEnd){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetDateOfBirthBetween", new
                {
DateOfBirthStart = DateOfBirthStart
,DateOfBirthEnd = DateOfBirthEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetModificationDateBetween(DateTime ModificationDateStart,DateTime ModificationDateEnd){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetModificationDateBetween", new
                {
ModificationDateStart = ModificationDateStart
,ModificationDateEnd = ModificationDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CustomerInformation> GetRecordDateStampBetween(DateTime RecordDateStampStart,DateTime RecordDateStampEnd){
            try
            {
                return connection.Query<CustomerInformation>("CustomerInformationGetRecordDateStampBetween", new
                {
RecordDateStampStart = RecordDateStampStart
,RecordDateStampEnd = RecordDateStampEnd
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
