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
    public class RoomMediaFilesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public RoomMediaFilesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(RoomMediaFiles RoomMediaFiles)
    {
        try
        {
            return connection.Insert(RoomMediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(RoomMediaFiles RoomMediaFiles)
    {
        try
        {
       return  connection.Update(RoomMediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(RoomMediaFiles RoomMediaFiles)
        {
            try
            {
            return  connection.Delete<RoomMediaFiles>(RoomMediaFiles);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<RoomMediaFiles> GetAll(){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetByApiId(int ApiId){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public RoomMediaFiles GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<RoomMediaFiles>("RoomMediaFilesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetByMediaFileId(int MediaFileId){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetByMediaFileId", new
                {
MediaFileId = MediaFileId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetByRoomId(int RoomId){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetByRoomId", new
                {
RoomId = RoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomMediaFiles> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<RoomMediaFiles>("RoomMediaFilesGetCreatedDateBetween", new
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
