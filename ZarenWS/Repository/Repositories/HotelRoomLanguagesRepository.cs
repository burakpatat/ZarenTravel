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
    public class HotelRoomLanguagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelRoomLanguagesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelRoomLanguages HotelRoomLanguages)
    {
        try
        {
            return connection.Insert(HotelRoomLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelRoomLanguages HotelRoomLanguages)
    {
        try
        {
       return  connection.Update(HotelRoomLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelRoomLanguages HotelRoomLanguages)
        {
            try
            {
            return  connection.Delete<HotelRoomLanguages>(HotelRoomLanguages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelRoomLanguages> GetAll(){
            try
            {
                return connection.Query<HotelRoomLanguages>("HotelRoomLanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomLanguages> GetByDescription(string Description){
            try
            {
                return connection.Query<HotelRoomLanguages>("HotelRoomLanguagesGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomLanguages> GetByHotelRoomId(int HotelRoomId){
            try
            {
                return connection.Query<HotelRoomLanguages>("HotelRoomLanguagesGetByHotelRoomId", new
                {
HotelRoomId = HotelRoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelRoomLanguages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelRoomLanguages>("HotelRoomLanguagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomLanguages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelRoomLanguages>("HotelRoomLanguagesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelRoomLanguages> GetByName(string Name){
            try
            {
                return connection.Query<HotelRoomLanguages>("HotelRoomLanguagesGetByName", new
                {
Name = Name
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
