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
using Microsoft.Extensions.Configuration;
    public class HotelBuyRoomAllotmentRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelBuyRoomAllotmentRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelBuyRoomAllotment HotelBuyRoomAllotment)
    {
        try
        {
            return connection.Insert(HotelBuyRoomAllotment);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelBuyRoomAllotment HotelBuyRoomAllotment)
    {
        try
        {
       return  connection.Update(HotelBuyRoomAllotment);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelBuyRoomAllotment HotelBuyRoomAllotment)
        {
            try
            {
            return  connection.Delete<HotelBuyRoomAllotment>(HotelBuyRoomAllotment);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelBuyRoomAllotment> GetAll(){
            try
            {
                return connection.Query<HotelBuyRoomAllotment>("HotelBuyRoomAllotmentGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBuyRoomAllotment> GetByAllotment(int Allotment){
            try
            {
                return connection.Query<HotelBuyRoomAllotment>("HotelBuyRoomAllotmentGetByAllotment", new
                {
Allotment = Allotment
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBuyRoomAllotment> GetByDay(DateTime Day){
            try
            {
                return connection.Query<HotelBuyRoomAllotment>("HotelBuyRoomAllotmentGetByDay", new
                {
Day = Day
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBuyRoomAllotment> GetByHotelBuyRoomId(int HotelBuyRoomId){
            try
            {
                return connection.Query<HotelBuyRoomAllotment>("HotelBuyRoomAllotmentGetByHotelBuyRoomId", new
                {
HotelBuyRoomId = HotelBuyRoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelBuyRoomAllotment GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelBuyRoomAllotment>("HotelBuyRoomAllotmentGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBuyRoomAllotment> GetByRelease(int Release){
            try
            {
                return connection.Query<HotelBuyRoomAllotment>("HotelBuyRoomAllotmentGetByRelease", new
                {
Release = Release
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBuyRoomAllotment> GetByStopSales(int StopSales){
            try
            {
                return connection.Query<HotelBuyRoomAllotment>("HotelBuyRoomAllotmentGetByStopSales", new
                {
StopSales = StopSales
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBuyRoomAllotment> GetDayBetween(DateTime DayStart,DateTime DayEnd){
            try
            {
                return connection.Query<HotelBuyRoomAllotment>("HotelBuyRoomAllotmentGetDayBetween", new
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
