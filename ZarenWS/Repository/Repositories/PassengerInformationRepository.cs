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
    public class PassengerInformationRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PassengerInformationRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PassengerInformation PassengerInformation)
    {
        try
        {
            return connection.Insert(PassengerInformation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PassengerInformation PassengerInformation)
    {
        try
        {
       return  connection.Update(PassengerInformation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PassengerInformation PassengerInformation)
        {
            try
            {
            return  connection.Delete<PassengerInformation>(PassengerInformation);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PassengerInformation> GetAll(){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByAdultId(int AdultId){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByAdultId", new
                {
AdultId = AdultId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByFILE_ID(int FILE_ID){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByFILE_ID", new
                {
FILE_ID = FILE_ID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByFILE_NAME(string FILE_NAME){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByFILE_NAME", new
                {
FILE_NAME = FILE_NAME
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByFirstName(string FirstName){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByFirstName", new
                {
FirstName = FirstName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PassengerInformation GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PassengerInformation>("PassengerInformationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByLastName(string LastName){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByLastName", new
                {
LastName = LastName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByNationalityCode(int NationalityCode){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByNationalityCode", new
                {
NationalityCode = NationalityCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByPaxSequence(int PaxSequence){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByPaxSequence", new
                {
PaxSequence = PaxSequence
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByPnrpaxId(string PnrpaxId){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByPnrpaxId", new
                {
PnrpaxId = PnrpaxId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByRecordDateStamp(DateTime RecordDateStamp){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByRecordDateStamp", new
                {
RecordDateStamp = RecordDateStamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByTitle(string Title){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByTitle", new
                {
Title = Title
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByTotalFare(decimal TotalFare){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByTotalFare", new
                {
TotalFare = TotalFare
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByTotalPaid(decimal TotalPaid){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByTotalPaid", new
                {
TotalPaid = TotalPaid
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetByTotalTaxchg(decimal TotalTaxchg){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetByTotalTaxchg", new
                {
TotalTaxchg = TotalTaxchg
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerInformation> GetRecordDateStampBetween(DateTime RecordDateStampStart,DateTime RecordDateStampEnd){
            try
            {
                return connection.Query<PassengerInformation>("PassengerInformationGetRecordDateStampBetween", new
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
