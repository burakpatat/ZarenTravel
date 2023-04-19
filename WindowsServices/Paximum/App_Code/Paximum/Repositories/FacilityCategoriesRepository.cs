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
    public class FacilityCategoriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FacilityCategoriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FacilityCategories FacilityCategories)
    {
        try
        {
            return connection.Insert(FacilityCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FacilityCategories FacilityCategories)
    {
        try
        {
       return  connection.Update(FacilityCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FacilityCategories FacilityCategories)
        {
            try
            {
            return  connection.Delete<FacilityCategories>(FacilityCategories);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FacilityCategories> GetAll(){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetByApiId(int ApiId){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FacilityCategories GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FacilityCategories>("FacilityCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetByName(string Name){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilityCategories> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<FacilityCategories>("FacilityCategoriesGetCreatedDateBetween", new
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
