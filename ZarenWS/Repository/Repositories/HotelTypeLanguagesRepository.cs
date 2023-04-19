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
    public class HotelTypeLanguagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelTypeLanguagesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelTypeLanguages HotelTypeLanguages)
    {
        try
        {
            return connection.Insert(HotelTypeLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelTypeLanguages HotelTypeLanguages)
    {
        try
        {
       return  connection.Update(HotelTypeLanguages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelTypeLanguages HotelTypeLanguages)
        {
            try
            {
            return  connection.Delete<HotelTypeLanguages>(HotelTypeLanguages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelTypeLanguages> GetAll(){
            try
            {
                return connection.Query<HotelTypeLanguages>("HotelTypeLanguagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTypeLanguages> GetByHotelTypeId(int HotelTypeId){
            try
            {
                return connection.Query<HotelTypeLanguages>("HotelTypeLanguagesGetByHotelTypeId", new
                {
HotelTypeId = HotelTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelTypeLanguages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelTypeLanguages>("HotelTypeLanguagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTypeLanguages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelTypeLanguages>("HotelTypeLanguagesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTypeLanguages> GetByName(string Name){
            try
            {
                return connection.Query<HotelTypeLanguages>("HotelTypeLanguagesGetByName", new
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
