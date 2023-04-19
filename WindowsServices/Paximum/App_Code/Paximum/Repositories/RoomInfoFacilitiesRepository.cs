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
    public class RoomInfoFacilitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public RoomInfoFacilitiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(RoomInfoFacilities RoomInfoFacilities)
    {
        try
        {
            return connection.Insert(RoomInfoFacilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(RoomInfoFacilities RoomInfoFacilities)
    {
        try
        {
       return  connection.Update(RoomInfoFacilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(RoomInfoFacilities RoomInfoFacilities)
        {
            try
            {
            return  connection.Delete<RoomInfoFacilities>(RoomInfoFacilities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<RoomInfoFacilities> GetAll(){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetByApiId(int ApiId){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public RoomInfoFacilities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<RoomInfoFacilities>("RoomInfoFacilitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetByRoomId(int RoomId){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetByRoomId", new
                {
RoomId = RoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetByRoomInfosId(int RoomInfosId){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetByRoomInfosId", new
                {
RoomInfosId = RoomInfosId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomInfoFacilities> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<RoomInfoFacilities>("RoomInfoFacilitiesGetCreatedDateBetween", new
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
