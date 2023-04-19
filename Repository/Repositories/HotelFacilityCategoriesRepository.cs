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
    public class HotelFacilityCategoriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelFacilityCategoriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelFacilityCategories HotelFacilityCategories)
    {
        try
        {
            return connection.Insert(HotelFacilityCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelFacilityCategories HotelFacilityCategories)
    {
        try
        {
       return  connection.Update(HotelFacilityCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelFacilityCategories HotelFacilityCategories)
        {
            try
            {
            return  connection.Delete<HotelFacilityCategories>(HotelFacilityCategories);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelFacilityCategories> GetAll(){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategories> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategories> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategories> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelFacilityCategories GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelFacilityCategories>("HotelFacilityCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategories> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategories> GetByName(string Name){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategories> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategories> GetByType(int Type){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategories> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelFacilityCategories>("HotelFacilityCategoriesGetCreatedDateBetween", new
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
