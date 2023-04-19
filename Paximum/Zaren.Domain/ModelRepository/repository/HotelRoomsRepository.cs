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
    public class HotelRoomsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelRoomsRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelRooms HotelRooms)
    {
        try
        {
            return connection.Insert(HotelRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelRooms HotelRooms)
    {
        try
        {
       return  connection.Update(HotelRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelRooms HotelRooms)
        {
            try
            {
            return  connection.Delete<HotelRooms>(HotelRooms);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelRooms> GetAll(){
            try
            {
                return connection.Query<HotelRooms>("HotelRoomsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRooms> GetByAdults(int Adults){
            try
            {
                return connection.Query<HotelRooms>("HotelRoomsGetByAdults", new
                {
Adults = Adults
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRooms> GetByChildren(int Children){
            try
            {
                return connection.Query<HotelRooms>("HotelRoomsGetByChildren", new
                {
Children = Children
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRooms> GetByHotelBuyRoomId(int HotelBuyRoomId){
            try
            {
                return connection.Query<HotelRooms>("HotelRoomsGetByHotelBuyRoomId", new
                {
HotelBuyRoomId = HotelBuyRoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelRooms GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelRooms>("HotelRoomsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRooms> GetByInfants(int Infants){
            try
            {
                return connection.Query<HotelRooms>("HotelRoomsGetByInfants", new
                {
Infants = Infants
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRooms> GetByName(string Name){
            try
            {
                return connection.Query<HotelRooms>("HotelRoomsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRooms> GetByRoomId(int RoomId){
            try
            {
                return connection.Query<HotelRooms>("HotelRoomsGetByRoomId", new
                {
RoomId = RoomId
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
