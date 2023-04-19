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
    public class BookingRoomsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BookingRoomsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BookingRooms BookingRooms)
    {
        try
        {
            return connection.Insert(BookingRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BookingRooms BookingRooms)
    {
        try
        {
       return  connection.Update(BookingRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BookingRooms BookingRooms)
        {
            try
            {
            return  connection.Delete<BookingRooms>(BookingRooms);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BookingRooms> GetAll(){
            try
            {
                return connection.Query<BookingRooms>("BookingRoomsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingRooms> GetByBoardTypeId(int BoardTypeId){
            try
            {
                return connection.Query<BookingRooms>("BookingRoomsGetByBoardTypeId", new
                {
BoardTypeId = BoardTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingRooms> GetByBookingId(int BookingId){
            try
            {
                return connection.Query<BookingRooms>("BookingRoomsGetByBookingId", new
                {
BookingId = BookingId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingRooms> GetByCost(decimal Cost){
            try
            {
                return connection.Query<BookingRooms>("BookingRoomsGetByCost", new
                {
Cost = Cost
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingRooms> GetByHotelRoomId(int HotelRoomId){
            try
            {
                return connection.Query<BookingRooms>("BookingRoomsGetByHotelRoomId", new
                {
HotelRoomId = HotelRoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BookingRooms GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BookingRooms>("BookingRoomsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BookingRooms> GetByPrice(int Price){
            try
            {
                return connection.Query<BookingRooms>("BookingRoomsGetByPrice", new
                {
Price = Price
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
