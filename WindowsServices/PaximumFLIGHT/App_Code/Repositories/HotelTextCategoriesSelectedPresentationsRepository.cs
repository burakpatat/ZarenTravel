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
    public class HotelTextCategoriesSelectedPresentationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelTextCategoriesSelectedPresentationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelTextCategoriesSelectedPresentations HotelTextCategoriesSelectedPresentations)
    {
        try
        {
            return connection.Insert(HotelTextCategoriesSelectedPresentations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelTextCategoriesSelectedPresentations HotelTextCategoriesSelectedPresentations)
    {
        try
        {
       return  connection.Update(HotelTextCategoriesSelectedPresentations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelTextCategoriesSelectedPresentations HotelTextCategoriesSelectedPresentations)
        {
            try
            {
            return  connection.Delete<HotelTextCategoriesSelectedPresentations>(HotelTextCategoriesSelectedPresentations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetAll(){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetByHotelTextCategoriesId(int HotelTextCategoriesId){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetByHotelTextCategoriesId", new
                {
HotelTextCategoriesId = HotelTextCategoriesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelTextCategoriesSelectedPresentations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetByPresentationId(int PresentationId){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetByPresentationId", new
                {
PresentationId = PresentationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetByType(int Type){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelTextCategoriesSelectedPresentations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelTextCategoriesSelectedPresentations>("HotelTextCategoriesSelectedPresentationsGetCreatedDateBetween", new
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
