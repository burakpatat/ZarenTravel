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
    public class MediaFilesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public MediaFilesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(MediaFiles MediaFiles)
    {
        try
        {
            return connection.Insert(MediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(MediaFiles MediaFiles)
    {
        try
        {
       return  connection.Update(MediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(MediaFiles MediaFiles)
        {
            try
            {
            return  connection.Delete<MediaFiles>(MediaFiles);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<MediaFiles> GetAll(){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByApiId(int ApiId){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByFileType(int FileType){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByFileType", new
                {
FileType = FileType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public MediaFiles GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<MediaFiles>("MediaFilesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByUrl(string Url){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByUrl", new
                {
Url = Url
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetByUrlFull(string UrlFull){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetByUrlFull", new
                {
UrlFull = UrlFull
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<MediaFiles> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<MediaFiles>("MediaFilesGetCreatedDateBetween", new
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
