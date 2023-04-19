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
    public class GeolocationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public GeolocationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Geolocations Geolocations)
    {
        try
        {
            return connection.Insert(Geolocations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Geolocations Geolocations)
    {
        try
        {
       return  connection.Update(Geolocations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Geolocations Geolocations)
        {
            try
            {
            return  connection.Delete<Geolocations>(Geolocations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Geolocations> GetAll(){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Geolocations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Geolocations>("GeolocationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetByLatitude(decimal Latitude){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetByLatitude", new
                {
Latitude = Latitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetByLongitude(decimal Longitude){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetByLongitude", new
                {
Longitude = Longitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Geolocations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Geolocations>("GeolocationsGetCreatedDateBetween", new
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
