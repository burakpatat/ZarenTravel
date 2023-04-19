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
    public class SeasonsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SeasonsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Seasons Seasons)
    {
        try
        {
            return connection.Insert(Seasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Seasons Seasons)
    {
        try
        {
       return  connection.Update(Seasons);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Seasons Seasons)
        {
            try
            {
            return  connection.Delete<Seasons>(Seasons);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Seasons> GetAll(){
            try
            {
                return connection.Query<Seasons>("SeasonsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetBeginDateBetween(DateTime BeginDateStart,DateTime BeginDateEnd){
            try
            {
                return connection.Query<Seasons>("SeasonsGetBeginDateBetween", new
                {
BeginDateStart = BeginDateStart
,BeginDateEnd = BeginDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByBeginDate(DateTime BeginDate){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByBeginDate", new
                {
BeginDate = BeginDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByEndDate(DateTime EndDate){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByEndDate", new
                {
EndDate = EndDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByFacilitySelectedCategoryId(int FacilitySelectedCategoryId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByFacilitySelectedCategoryId", new
                {
FacilitySelectedCategoryId = FacilitySelectedCategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Seasons GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Seasons>("SeasonsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetByName(string Name){
            try
            {
                return connection.Query<Seasons>("SeasonsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetBySeasonMediaFileId(int SeasonMediaFileId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetBySeasonMediaFileId", new
                {
SeasonMediaFileId = SeasonMediaFileId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetBySeasonTextCategoryId(int SeasonTextCategoryId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetBySeasonTextCategoryId", new
                {
SeasonTextCategoryId = SeasonTextCategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetBySeasonThemeId(int SeasonThemeId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetBySeasonThemeId", new
                {
SeasonThemeId = SeasonThemeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Seasons>("SeasonsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Seasons> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Seasons>("SeasonsGetCreatedDateBetween", new
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
public List<Seasons> GetEndDateBetween(DateTime EndDateStart,DateTime EndDateEnd){
            try
            {
                return connection.Query<Seasons>("SeasonsGetEndDateBetween", new
                {
EndDateStart = EndDateStart
,EndDateEnd = EndDateEnd
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
