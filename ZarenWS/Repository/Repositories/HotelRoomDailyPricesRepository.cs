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
    public class HotelRoomDailyPricesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelRoomDailyPricesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelRoomDailyPrices HotelRoomDailyPrices)
    {
        try
        {
            return connection.Insert(HotelRoomDailyPrices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelRoomDailyPrices HotelRoomDailyPrices)
    {
        try
        {
       return  connection.Update(HotelRoomDailyPrices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelRoomDailyPrices HotelRoomDailyPrices)
        {
            try
            {
            return  connection.Delete<HotelRoomDailyPrices>(HotelRoomDailyPrices);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelRoomDailyPrices> GetAll(){
            try
            {
                return connection.Query<HotelRoomDailyPrices>("HotelRoomDailyPricesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomDailyPrices> GetByBoardTypeId(int BoardTypeId){
            try
            {
                return connection.Query<HotelRoomDailyPrices>("HotelRoomDailyPricesGetByBoardTypeId", new
                {
BoardTypeId = BoardTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomDailyPrices> GetByCost(int Cost){
            try
            {
                return connection.Query<HotelRoomDailyPrices>("HotelRoomDailyPricesGetByCost", new
                {
Cost = Cost
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomDailyPrices> GetByDay(DateTime Day){
            try
            {
                return connection.Query<HotelRoomDailyPrices>("HotelRoomDailyPricesGetByDay", new
                {
Day = Day
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomDailyPrices> GetByHotelRoomId(int HotelRoomId){
            try
            {
                return connection.Query<HotelRoomDailyPrices>("HotelRoomDailyPricesGetByHotelRoomId", new
                {
HotelRoomId = HotelRoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelRoomDailyPrices GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelRoomDailyPrices>("HotelRoomDailyPricesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomDailyPrices> GetByStopSale(int StopSale){
            try
            {
                return connection.Query<HotelRoomDailyPrices>("HotelRoomDailyPricesGetByStopSale", new
                {
StopSale = StopSale
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomDailyPrices> GetDayBetween(DateTime DayStart,DateTime DayEnd){
            try
            {
                return connection.Query<HotelRoomDailyPrices>("HotelRoomDailyPricesGetDayBetween", new
                {
DayStart = DayStart
,DayEnd = DayEnd
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
