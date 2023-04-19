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
    public class ItemsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ItemsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Items Items)
    {
        try
        {
            return connection.Insert(Items);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Items Items)
    {
        try
        {
       return  connection.Update(Items);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Items Items)
        {
            try
            {
            return  connection.Delete<Items>(Items);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Items> GetAll(){
            try
            {
                return connection.Query<Items>("ItemsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Items>("ItemsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Items>("ItemsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByCityId(int CityId){
            try
            {
                return connection.Query<Items>("ItemsGetByCityId", new
                {
CityId = CityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByCoutryId(int CoutryId){
            try
            {
                return connection.Query<Items>("ItemsGetByCoutryId", new
                {
CoutryId = CoutryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Items>("ItemsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Items>("ItemsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByGeolocationId(int GeolocationId){
            try
            {
                return connection.Query<Items>("ItemsGetByGeolocationId", new
                {
GeolocationId = GeolocationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByGiataInfoId(int GiataInfoId){
            try
            {
                return connection.Query<Items>("ItemsGetByGiataInfoId", new
                {
GiataInfoId = GiataInfoId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Items GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Items>("ItemsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Items>("ItemsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Items>("ItemsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByProvider(int Provider){
            try
            {
                return connection.Query<Items>("ItemsGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByStateId(int StateId){
            try
            {
                return connection.Query<Items>("ItemsGetByStateId", new
                {
StateId = StateId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Items>("ItemsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetByType(int Type){
            try
            {
                return connection.Query<Items>("ItemsGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Items> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Items>("ItemsGetCreatedDateBetween", new
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
