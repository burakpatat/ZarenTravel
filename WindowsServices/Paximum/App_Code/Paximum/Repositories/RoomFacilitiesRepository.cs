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
    public class RoomFacilitiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public RoomFacilitiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(RoomFacilities RoomFacilities)
    {
        try
        {
            return connection.Insert(RoomFacilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(RoomFacilities RoomFacilities)
    {
        try
        {
       return  connection.Update(RoomFacilities);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(RoomFacilities RoomFacilities)
        {
            try
            {
            return  connection.Delete<RoomFacilities>(RoomFacilities);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<RoomFacilities> GetAll(){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetByApiId(int ApiId){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetByFacilityId(int FacilityId){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetByFacilityId", new
                {
FacilityId = FacilityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public RoomFacilities GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<RoomFacilities>("RoomFacilitiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetByRoomId(int RoomId){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetByRoomId", new
                {
RoomId = RoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<RoomFacilities> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<RoomFacilities>("RoomFacilitiesGetCreatedDateBetween", new
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
