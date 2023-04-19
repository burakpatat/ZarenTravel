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
    public class OfferRoomsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public OfferRoomsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(OfferRooms OfferRooms)
    {
        try
        {
            return connection.Insert(OfferRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(OfferRooms OfferRooms)
    {
        try
        {
       return  connection.Update(OfferRooms);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(OfferRooms OfferRooms)
        {
            try
            {
            return  connection.Delete<OfferRooms>(OfferRooms);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<OfferRooms> GetAll(){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetByApiId(int ApiId){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public OfferRooms GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<OfferRooms>("OfferRoomsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetByOfferId(int OfferId){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetByOfferId", new
                {
OfferId = OfferId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetByRoomId(int RoomId){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetByRoomId", new
                {
RoomId = RoomId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferRooms> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<OfferRooms>("OfferRoomsGetCreatedDateBetween", new
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
