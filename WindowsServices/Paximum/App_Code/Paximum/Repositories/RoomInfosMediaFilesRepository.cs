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
    public class RoomInfosMediaFilesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public RoomInfosMediaFilesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(RoomInfosMediaFiles RoomInfosMediaFiles)
    {
        try
        {
            return connection.Insert(RoomInfosMediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(RoomInfosMediaFiles RoomInfosMediaFiles)
    {
        try
        {
       return  connection.Update(RoomInfosMediaFiles);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(RoomInfosMediaFiles RoomInfosMediaFiles)
        {
            try
            {
            return  connection.Delete<RoomInfosMediaFiles>(RoomInfosMediaFiles);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<RoomInfosMediaFiles> GetAll(){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetByApiId(int ApiId){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public RoomInfosMediaFiles GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetByMedaFileId(int MedaFileId){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByMedaFileId", new
                {
MedaFileId = MedaFileId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetByRoomInfoId(int RoomInfoId){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetByRoomInfoId", new
                {
RoomInfoId = RoomInfoId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfosMediaFiles> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<RoomInfosMediaFiles>("RoomInfosMediaFilesGetCreatedDateBetween", new
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
