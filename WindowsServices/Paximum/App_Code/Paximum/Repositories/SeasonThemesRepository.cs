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
    public class SeasonThemesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SeasonThemesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SeasonThemes SeasonThemes)
    {
        try
        {
            return connection.Insert(SeasonThemes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SeasonThemes SeasonThemes)
    {
        try
        {
       return  connection.Update(SeasonThemes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SeasonThemes SeasonThemes)
        {
            try
            {
            return  connection.Delete<SeasonThemes>(SeasonThemes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SeasonThemes> GetAll(){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetByApiId(int ApiId){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SeasonThemes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SeasonThemes>("SeasonThemesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetBySeasonId(int SeasonId){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetBySeasonId", new
                {
SeasonId = SeasonId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetByThemeId(int ThemeId){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetByThemeId", new
                {
ThemeId = ThemeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonThemes> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SeasonThemes>("SeasonThemesGetCreatedDateBetween", new
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
