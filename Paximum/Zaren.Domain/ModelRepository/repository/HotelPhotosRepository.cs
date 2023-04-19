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
    public class HotelPhotosRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelPhotosRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelPhotos HotelPhotos)
    {
        try
        {
            return connection.Insert(HotelPhotos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelPhotos HotelPhotos)
    {
        try
        {
       return  connection.Update(HotelPhotos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelPhotos HotelPhotos)
        {
            try
            {
            return  connection.Delete<HotelPhotos>(HotelPhotos);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelPhotos> GetAll(){
            try
            {
                return connection.Query<HotelPhotos>("HotelPhotosGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPhotos> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelPhotos>("HotelPhotosGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPhotos> GetByHotelRoomId(int HotelRoomId){
            try
            {
                return connection.Query<HotelPhotos>("HotelPhotosGetByHotelRoomId", new
                {
HotelRoomId = HotelRoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelPhotos GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelPhotos>("HotelPhotosGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPhotos> GetByOrder(int Order){
            try
            {
                return connection.Query<HotelPhotos>("HotelPhotosGetByOrder", new
                {
Order = Order
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPhotos> GetByPath(string Path){
            try
            {
                return connection.Query<HotelPhotos>("HotelPhotosGetByPath", new
                {
Path = Path
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
