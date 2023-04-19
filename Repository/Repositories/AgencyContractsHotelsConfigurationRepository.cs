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
    public class AgencyContractsHotelsConfigurationRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsHotelsConfigurationRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsHotelsConfiguration AgencyContractsHotelsConfiguration)
    {
        try
        {
            return connection.Insert(AgencyContractsHotelsConfiguration);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsHotelsConfiguration AgencyContractsHotelsConfiguration)
    {
        try
        {
       return  connection.Update(AgencyContractsHotelsConfiguration);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsHotelsConfiguration AgencyContractsHotelsConfiguration)
        {
            try
            {
            return  connection.Delete<AgencyContractsHotelsConfiguration>(AgencyContractsHotelsConfiguration);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetAll(){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByCheckInDateFrom(DateTime CheckInDateFrom){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByCheckInDateFrom", new
                {
CheckInDateFrom = CheckInDateFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByCheckInDateTo(DateTime CheckInDateTo){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByCheckInDateTo", new
                {
CheckInDateTo = CheckInDateTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByCheckInDayId(int CheckInDayId){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByCheckInDayId", new
                {
CheckInDayId = CheckInDayId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByCheckOutDayId(int CheckOutDayId){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByCheckOutDayId", new
                {
CheckOutDayId = CheckOutDayId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByCheckOutUntil(DateTime CheckOutUntil){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByCheckOutUntil", new
                {
CheckOutUntil = CheckOutUntil
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByCurrencyId(int CurrencyId){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByCurrencyId", new
                {
CurrencyId = CurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByEarlyDepartureCostAmount(decimal EarlyDepartureCostAmount){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByEarlyDepartureCostAmount", new
                {
EarlyDepartureCostAmount = EarlyDepartureCostAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByEarlyDepartureCostCurrencyId(int EarlyDepartureCostCurrencyId){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByEarlyDepartureCostCurrencyId", new
                {
EarlyDepartureCostCurrencyId = EarlyDepartureCostCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByEarlyDepartureFrom(DateTime EarlyDepartureFrom){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByEarlyDepartureFrom", new
                {
EarlyDepartureFrom = EarlyDepartureFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByEarlyDepartureTo(DateTime EarlyDepartureTo){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByEarlyDepartureTo", new
                {
EarlyDepartureTo = EarlyDepartureTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsHotelsConfiguration GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByLateArrivalAmount(int LateArrivalAmount){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByLateArrivalAmount", new
                {
LateArrivalAmount = LateArrivalAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByLateArrivalCurrencyId(int LateArrivalCurrencyId){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByLateArrivalCurrencyId", new
                {
LateArrivalCurrencyId = LateArrivalCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByLateArrivalFrom(DateTime LateArrivalFrom){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByLateArrivalFrom", new
                {
LateArrivalFrom = LateArrivalFrom
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByLateArrivalTo(DateTime LateArrivalTo){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByLateArrivalTo", new
                {
LateArrivalTo = LateArrivalTo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByMaximumStay(int MaximumStay){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByMaximumStay", new
                {
MaximumStay = MaximumStay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByMinAgeStay(int MinAgeStay){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByMinAgeStay", new
                {
MinAgeStay = MinAgeStay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByMinimumStay(byte MinimumStay){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByMinimumStay", new
                {
MinimumStay = MinimumStay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetByReleaseDay(int ReleaseDay){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetByReleaseDay", new
                {
ReleaseDay = ReleaseDay
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetBySecurityDepositAmount(int SecurityDepositAmount){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetBySecurityDepositAmount", new
                {
SecurityDepositAmount = SecurityDepositAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetBySecurityDepositCurrencyId(int SecurityDepositCurrencyId){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetBySecurityDepositCurrencyId", new
                {
SecurityDepositCurrencyId = SecurityDepositCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfiguration> GetCheckInDateFromBetween(DateTime CheckInDateFromStart,DateTime CheckInDateFromEnd){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetCheckInDateFromBetween", new
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
public List<AgencyContractsHotelsConfiguration> GetCheckInDateToBetween(DateTime CheckInDateToStart,DateTime CheckInDateToEnd){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetCheckInDateToBetween", new
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
public List<AgencyContractsHotelsConfiguration> GetCheckOutUntilBetween(DateTime CheckOutUntilStart,DateTime CheckOutUntilEnd){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetCheckOutUntilBetween", new
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
public List<AgencyContractsHotelsConfiguration> GetEarlyDepartureFromBetween(DateTime EarlyDepartureFromStart,DateTime EarlyDepartureFromEnd){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetEarlyDepartureFromBetween", new
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
public List<AgencyContractsHotelsConfiguration> GetEarlyDepartureToBetween(DateTime EarlyDepartureToStart,DateTime EarlyDepartureToEnd){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetEarlyDepartureToBetween", new
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
public List<AgencyContractsHotelsConfiguration> GetLateArrivalFromBetween(DateTime LateArrivalFromStart,DateTime LateArrivalFromEnd){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetLateArrivalFromBetween", new
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
public List<AgencyContractsHotelsConfiguration> GetLateArrivalToBetween(DateTime LateArrivalToStart,DateTime LateArrivalToEnd){
            try
            {
                return connection.Query<AgencyContractsHotelsConfiguration>("AgencyContractsHotelsConfigurationGetLateArrivalToBetween", new
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
 public void Dispose()
            {
                GC.SuppressFinalize(this);
            }
    }
