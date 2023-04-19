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
    public class AirsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AirsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Airs Airs)
    {
        try
        {
            return connection.Insert(Airs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Airs Airs)
    {
        try
        {
       return  connection.Update(Airs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Airs Airs)
        {
            try
            {
            return  connection.Delete<Airs>(Airs);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Airs> GetAirBookedDateBetween(DateTime AirBookedDateStart,DateTime AirBookedDateEnd){
            try
            {
                return connection.Query<Airs>("AirsGetAirBookedDateBetween", new
                {
AirBookedDateStart = AirBookedDateStart
,AirBookedDateEnd = AirBookedDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetAirIssueddateBetween(DateTime AirIssueddateStart,DateTime AirIssueddateEnd){
            try
            {
                return connection.Query<Airs>("AirsGetAirIssueddateBetween", new
                {
AirIssueddateStart = AirIssueddateStart
,AirIssueddateEnd = AirIssueddateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetAirTimestampBetween(DateTime AirTimestampStart,DateTime AirTimestampEnd){
            try
            {
                return connection.Query<Airs>("AirsGetAirTimestampBetween", new
                {
AirTimestampStart = AirTimestampStart
,AirTimestampEnd = AirTimestampEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetAll(){
            try
            {
                return connection.Query<Airs>("AirsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirActive(bool AirActive){
            try
            {
                return connection.Query<Airs>("AirsGetByAirActive", new
                {
AirActive = AirActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirBookedDate(DateTime AirBookedDate){
            try
            {
                return connection.Query<Airs>("AirsGetByAirBookedDate", new
                {
AirBookedDate = AirBookedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirFare(decimal AirFare){
            try
            {
                return connection.Query<Airs>("AirsGetByAirFare", new
                {
AirFare = AirFare
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirFareBases(string AirFareBases){
            try
            {
                return connection.Query<Airs>("AirsGetByAirFareBases", new
                {
AirFareBases = AirFareBases
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirHighestFare(decimal AirHighestFare){
            try
            {
                return connection.Query<Airs>("AirsGetByAirHighestFare", new
                {
AirHighestFare = AirHighestFare
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirIncludeBags(bool AirIncludeBags){
            try
            {
                return connection.Query<Airs>("AirsGetByAirIncludeBags", new
                {
AirIncludeBags = AirIncludeBags
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirIssueddate(DateTime AirIssueddate){
            try
            {
                return connection.Query<Airs>("AirsGetByAirIssueddate", new
                {
AirIssueddate = AirIssueddate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirlineId(int AirlineId){
            try
            {
                return connection.Query<Airs>("AirsGetByAirlineId", new
                {
AirlineId = AirlineId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirLowestFare(decimal AirLowestFare){
            try
            {
                return connection.Query<Airs>("AirsGetByAirLowestFare", new
                {
AirLowestFare = AirLowestFare
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirOriginalTicket(string AirOriginalTicket){
            try
            {
                return connection.Query<Airs>("AirsGetByAirOriginalTicket", new
                {
AirOriginalTicket = AirOriginalTicket
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirRecordAirline(string AirRecordAirline){
            try
            {
                return connection.Query<Airs>("AirsGetByAirRecordAirline", new
                {
AirRecordAirline = AirRecordAirline
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirReIssued(bool AirReIssued){
            try
            {
                return connection.Query<Airs>("AirsGetByAirReIssued", new
                {
AirReIssued = AirReIssued
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirTax(decimal AirTax){
            try
            {
                return connection.Query<Airs>("AirsGetByAirTax", new
                {
AirTax = AirTax
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirTicket(string AirTicket){
            try
            {
                return connection.Query<Airs>("AirsGetByAirTicket", new
                {
AirTicket = AirTicket
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByAirTimestamp(DateTime AirTimestamp){
            try
            {
                return connection.Query<Airs>("AirsGetByAirTimestamp", new
                {
AirTimestamp = AirTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByBrokerId(int BrokerId){
            try
            {
                return connection.Query<Airs>("AirsGetByBrokerId", new
                {
BrokerId = BrokerId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<Airs>("AirsGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Airs GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Airs>("AirsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airs> GetByPNRId(int PNRId){
            try
            {
                return connection.Query<Airs>("AirsGetByPNRId", new
                {
PNRId = PNRId
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
