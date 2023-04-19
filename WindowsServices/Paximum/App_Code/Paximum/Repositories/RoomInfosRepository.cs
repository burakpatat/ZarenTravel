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
    public class RoomInfosRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public RoomInfosRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(RoomInfos RoomInfos)
    {
        try
        {
            return connection.Insert(RoomInfos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(RoomInfos RoomInfos)
    {
        try
        {
       return  connection.Update(RoomInfos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(RoomInfos RoomInfos)
        {
            try
            {
            return  connection.Delete<RoomInfos>(RoomInfos);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<RoomInfos> GetAll(){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByApiId(int ApiId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public RoomInfos GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<RoomInfos>("RoomInfosGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByMediaFilesId(int MediaFilesId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByMediaFilesId", new
                {
MediaFilesId = MediaFilesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByName(string Name){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByRoomPresentationsId(int RoomPresentationsId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByRoomPresentationsId", new
                {
RoomPresentationsId = RoomPresentationsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetByRoomsFacilitiesId(int RoomsFacilitiesId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetByRoomsFacilitiesId", new
                {
RoomsFacilitiesId = RoomsFacilitiesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosGetCreatedDateBetween", new
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
public List<RoomInfos> MediaFilesGetAll(){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetByApiId(int ApiId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public RoomInfos MediaFilesGetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<RoomInfos>("RoomInfosMediaFilesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetByMedaFileId(int MedaFileId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetByMedaFileId", new
                {
MedaFileId = MedaFileId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetByRoomInfoId(int RoomInfoId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetByRoomInfoId", new
                {
RoomInfoId = RoomInfoId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetBySystemId(int SystemId){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfos> MediaFilesGetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<RoomInfos>("RoomInfosMediaFilesGetCreatedDateBetween", new
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
