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
    public class HotelCategoriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelCategoriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelCategories HotelCategories)
    {
        try
        {
            return connection.Insert(HotelCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelCategories HotelCategories)
    {
        try
        {
       return  connection.Update(HotelCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelCategories HotelCategories)
        {
            try
            {
            return  connection.Delete<HotelCategories>(HotelCategories);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelCategories> GetAll(){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetByCode(string Code){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetByCode", new
                {
Code = Code
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelCategories GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelCategories>("HotelCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetByName(string Name){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelCategories> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelCategories>("HotelCategoriesGetCreatedDateBetween", new
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
