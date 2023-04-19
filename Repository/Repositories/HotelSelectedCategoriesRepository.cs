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
    public class HotelSelectedCategoriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelSelectedCategoriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelSelectedCategories HotelSelectedCategories)
    {
        try
        {
            return connection.Insert(HotelSelectedCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelSelectedCategories HotelSelectedCategories)
    {
        try
        {
       return  connection.Update(HotelSelectedCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelSelectedCategories HotelSelectedCategories)
        {
            try
            {
            return  connection.Delete<HotelSelectedCategories>(HotelSelectedCategories);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelSelectedCategories> GetAll(){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSelectedCategories> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSelectedCategories> GetByCategoryId(int CategoryId){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetByCategoryId", new
                {
CategoryId = CategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSelectedCategories> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSelectedCategories> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSelectedCategories> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelSelectedCategories GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelSelectedCategories>("HotelSelectedCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSelectedCategories> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSelectedCategories> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSelectedCategories> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelSelectedCategories>("HotelSelectedCategoriesGetCreatedDateBetween", new
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
