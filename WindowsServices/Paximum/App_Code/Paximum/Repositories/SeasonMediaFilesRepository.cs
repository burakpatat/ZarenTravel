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
    public class SeasonMediaFilesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SeasonMediaFilesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SeasonMediaFiles SeasonMediaFiles)
    {
        try
        {
            return connection.Insert(SeasonMediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SeasonMediaFiles SeasonMediaFiles)
    {
        try
        {
       return  connection.Update(SeasonMediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SeasonMediaFiles SeasonMediaFiles)
        {
            try
            {
            return  connection.Delete<SeasonMediaFiles>(SeasonMediaFiles);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SeasonMediaFiles> GetAll(){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetByApiId(int ApiId){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SeasonMediaFiles GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SeasonMediaFiles>("SeasonMediaFilesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetByMediaFileId(int MediaFileId){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetByMediaFileId", new
                {
MediaFileId = MediaFileId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetBySeasonId(int SeasonId){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetBySeasonId", new
                {
SeasonId = SeasonId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonMediaFiles> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SeasonMediaFiles>("SeasonMediaFilesGetCreatedDateBetween", new
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
