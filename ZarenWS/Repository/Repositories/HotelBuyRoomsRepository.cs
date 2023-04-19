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
    public class HotelBuyRoomsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelBuyRoomsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelBuyRooms HotelBuyRooms)
    {
        try
        {
            return connection.Insert(HotelBuyRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelBuyRooms HotelBuyRooms)
    {
        try
        {
       return  connection.Update(HotelBuyRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelBuyRooms HotelBuyRooms)
        {
            try
            {
            return  connection.Delete<HotelBuyRooms>(HotelBuyRooms);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelBuyRooms> GetAll(){
            try
            {
                return connection.Query<HotelBuyRooms>("HotelBuyRoomsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBuyRooms> GetByBuyRoomId(int BuyRoomId){
            try
            {
                return connection.Query<HotelBuyRooms>("HotelBuyRoomsGetByBuyRoomId", new
                {
BuyRoomId = BuyRoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelBuyRooms> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelBuyRooms>("HotelBuyRoomsGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelBuyRooms GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelBuyRooms>("HotelBuyRoomsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

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
