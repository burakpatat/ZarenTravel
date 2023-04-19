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
    public class HotelPhotoLanguagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelPhotoLanguagesRepository(IConfiguration configuration)
        {
             strConnString = configuration.GetSection("ConnectionString").Value;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelPhotoLanguages HotelPhotoLanguages)
    {
        try
        {
            return connection.Insert(HotelPhotoLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelPhotoLanguages HotelPhotoLanguages)
    {
        try
        {
       return  connection.Update(HotelPhotoLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelPhotoLanguages HotelPhotoLanguages)
        {
            try
            {
            return  connection.Delete<HotelPhotoLanguages>(HotelPhotoLanguages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelPhotoLanguages> GetAll(){
            try
            {
                return connection.Query<HotelPhotoLanguages>("HotelPhotoLanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPhotoLanguages> GetByDescription(string Description){
            try
            {
                return connection.Query<HotelPhotoLanguages>("HotelPhotoLanguagesGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPhotoLanguages> GetByHotelPhotoId(int HotelPhotoId){
            try
            {
                return connection.Query<HotelPhotoLanguages>("HotelPhotoLanguagesGetByHotelPhotoId", new
                {
HotelPhotoId = HotelPhotoId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelPhotoLanguages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelPhotoLanguages>("HotelPhotoLanguagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPhotoLanguages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelPhotoLanguages>("HotelPhotoLanguagesGetByLanguageId", new
                {
LanguageId = LanguageId
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
