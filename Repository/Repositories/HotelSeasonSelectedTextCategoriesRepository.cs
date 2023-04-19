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
    public class HotelSeasonSelectedTextCategoriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelSeasonSelectedTextCategoriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelSeasonSelectedTextCategories HotelSeasonSelectedTextCategories)
    {
        try
        {
            return connection.Insert(HotelSeasonSelectedTextCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelSeasonSelectedTextCategories HotelSeasonSelectedTextCategories)
    {
        try
        {
       return  connection.Update(HotelSeasonSelectedTextCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelSeasonSelectedTextCategories HotelSeasonSelectedTextCategories)
        {
            try
            {
            return  connection.Delete<HotelSeasonSelectedTextCategories>(HotelSeasonSelectedTextCategories);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetAll(){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelSeasonSelectedTextCategories GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetBySeasonId(int SeasonId){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetBySeasonId", new
                {
SeasonId = SeasonId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetByTextCategoriesId(int TextCategoriesId){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetByTextCategoriesId", new
                {
TextCategoriesId = TextCategoriesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetByType(int Type){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonSelectedTextCategories> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelSeasonSelectedTextCategories>("HotelSeasonSelectedTextCategoriesGetCreatedDateBetween", new
                {
CreatedDateStart = CreatedDateStart
,CreatedDateEnd = CreatedDateEnd
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
