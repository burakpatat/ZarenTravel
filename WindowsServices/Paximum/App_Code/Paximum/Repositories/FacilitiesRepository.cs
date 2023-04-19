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
    public class FacilitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FacilitiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Facilities Facilities)
    {
        try
        {
            return connection.Insert(Facilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Facilities Facilities)
    {
        try
        {
       return  connection.Update(Facilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Facilities Facilities)
        {
            try
            {
            return  connection.Delete<Facilities>(Facilities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Facilities> GetAll(){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Facilities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Facilities>("FacilitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByIsPriced(bool IsPriced){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByIsPriced", new
                {
IsPriced = IsPriced
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByName(string Name){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetByNote(string Note){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetByNote", new
                {
Note = Note
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Facilities>("FacilitiesGetCreatedDateBetween", new
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
public List<Facilities> SelectedCategoryGetAll(){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetByApiId(int ApiId){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetByFacilityCategoryId(int FacilityCategoryId){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetByFacilityCategoryId", new
                {
FacilityCategoryId = FacilityCategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetByFacilityId(int FacilityId){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetByFacilityId", new
                {
FacilityId = FacilityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Facilities SelectedCategoryGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Facilities>("FacilitiesSelectedCategoryGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetBySystemId(int SystemId){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Facilities> SelectedCategoryGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Facilities>("FacilitiesSelectedCategoryGetCreatedDateBetween", new
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
