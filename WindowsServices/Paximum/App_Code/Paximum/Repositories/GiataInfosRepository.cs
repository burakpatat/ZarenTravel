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
    public class GiataInfosRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public GiataInfosRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(GiataInfos GiataInfos)
    {
        try
        {
            return connection.Insert(GiataInfos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(GiataInfos GiataInfos)
    {
        try
        {
       return  connection.Update(GiataInfos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(GiataInfos GiataInfos)
        {
            try
            {
            return  connection.Delete<GiataInfos>(GiataInfos);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<GiataInfos> GetAll(){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetByApiId(int ApiId){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetByDestinationId(int DestinationId){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetByDestinationId", new
                {
DestinationId = DestinationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetByHotelId(int? HotelId){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public GiataInfos GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<GiataInfos>("GiataInfosGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GiataInfos> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<GiataInfos>("GiataInfosGetCreatedDateBetween", new
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
