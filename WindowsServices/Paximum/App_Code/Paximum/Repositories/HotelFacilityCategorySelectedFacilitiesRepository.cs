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
    public class HotelFacilityCategorySelectedFacilitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelFacilityCategorySelectedFacilitiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelFacilityCategorySelectedFacilities HotelFacilityCategorySelectedFacilities)
    {
        try
        {
            return connection.Insert(HotelFacilityCategorySelectedFacilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelFacilityCategorySelectedFacilities HotelFacilityCategorySelectedFacilities)
    {
        try
        {
       return  connection.Update(HotelFacilityCategorySelectedFacilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelFacilityCategorySelectedFacilities HotelFacilityCategorySelectedFacilities)
        {
            try
            {
            return  connection.Delete<HotelFacilityCategorySelectedFacilities>(HotelFacilityCategorySelectedFacilities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetAll(){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetByCategoryId(int CategoryId){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByCategoryId", new
                {
CategoryId = CategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetByFacilityId(int FacilityId){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByFacilityId", new
                {
FacilityId = FacilityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelFacilityCategorySelectedFacilities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetByName(string Name){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetByType(int Type){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelFacilityCategorySelectedFacilities> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelFacilityCategorySelectedFacilities>("HotelFacilityCategorySelectedFacilitiesGetCreatedDateBetween", new
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
