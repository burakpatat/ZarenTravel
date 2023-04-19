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
    public class FacilitiesSelectedCategoryRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FacilitiesSelectedCategoryRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FacilitiesSelectedCategory FacilitiesSelectedCategory)
    {
        try
        {
            return connection.Insert(FacilitiesSelectedCategory);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FacilitiesSelectedCategory FacilitiesSelectedCategory)
    {
        try
        {
       return  connection.Update(FacilitiesSelectedCategory);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FacilitiesSelectedCategory FacilitiesSelectedCategory)
        {
            try
            {
            return  connection.Delete<FacilitiesSelectedCategory>(FacilitiesSelectedCategory);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FacilitiesSelectedCategory> GetAll(){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetByApiId(int ApiId){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetByFacilityCategoryId(int FacilityCategoryId){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByFacilityCategoryId", new
                {
FacilityCategoryId = FacilityCategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetByFacilityId(int FacilityId){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByFacilityId", new
                {
FacilityId = FacilityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FacilitiesSelectedCategory GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FacilitiesSelectedCategory> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<FacilitiesSelectedCategory>("FacilitiesSelectedCategoryGetCreatedDateBetween", new
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
