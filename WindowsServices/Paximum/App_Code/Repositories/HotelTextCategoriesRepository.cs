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
    public class HotelTextCategoriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelTextCategoriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelTextCategories HotelTextCategories)
    {
        try
        {
            return connection.Insert(HotelTextCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelTextCategories HotelTextCategories)
    {
        try
        {
       return  connection.Update(HotelTextCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelTextCategories HotelTextCategories)
        {
            try
            {
            return  connection.Delete<HotelTextCategories>(HotelTextCategories);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelTextCategories> GetAll(){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategories> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategories> GetByCode(string Code){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetByCode", new
                {
Code = Code
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategories> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategories> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelTextCategories GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelTextCategories>("HotelTextCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategories> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategories> GetByName(string Name){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategories> GetByType(int Type){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategories> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelTextCategories>("HotelTextCategoriesGetCreatedDateBetween", new
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
