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
    public class RoomPresentationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public RoomPresentationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(RoomPresentations RoomPresentations)
    {
        try
        {
            return connection.Insert(RoomPresentations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(RoomPresentations RoomPresentations)
    {
        try
        {
       return  connection.Update(RoomPresentations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(RoomPresentations RoomPresentations)
        {
            try
            {
            return  connection.Delete<RoomPresentations>(RoomPresentations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<RoomPresentations> GetAll(){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetByApiId(int ApiId){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public RoomPresentations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<RoomPresentations>("RoomPresentationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetByPresentationId(int PresentationId){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetByPresentationId", new
                {
PresentationId = PresentationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetByRoomInfoId(int RoomInfoId){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetByRoomInfoId", new
                {
RoomInfoId = RoomInfoId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomPresentations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<RoomPresentations>("RoomPresentationsGetCreatedDateBetween", new
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
