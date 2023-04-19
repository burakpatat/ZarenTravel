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
    public class HotelSeasonMediaFilesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelSeasonMediaFilesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelSeasonMediaFiles HotelSeasonMediaFiles)
    {
        try
        {
            return connection.Insert(HotelSeasonMediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelSeasonMediaFiles HotelSeasonMediaFiles)
    {
        try
        {
       return  connection.Update(HotelSeasonMediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelSeasonMediaFiles HotelSeasonMediaFiles)
        {
            try
            {
            return  connection.Delete<HotelSeasonMediaFiles>(HotelSeasonMediaFiles);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelSeasonMediaFiles> GetAll(){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetByFileType(int FileType){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByFileType", new
                {
FileType = FileType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelSeasonMediaFiles GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetBySeasonId(int SeasonId){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetBySeasonId", new
                {
SeasonId = SeasonId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetByType(int Type){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetByUrl(string Url){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByUrl", new
                {
Url = Url
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetByUrlFull(string UrlFull){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetByUrlFull", new
                {
UrlFull = UrlFull
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelSeasonMediaFiles> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelSeasonMediaFiles>("HotelSeasonMediaFilesGetCreatedDateBetween", new
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
