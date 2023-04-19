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
    public class FlightGeoLocationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FlightGeoLocationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FlightGeoLocations FlightGeoLocations)
    {
        try
        {
            return connection.Insert(FlightGeoLocations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FlightGeoLocations FlightGeoLocations)
    {
        try
        {
       return  connection.Update(FlightGeoLocations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FlightGeoLocations FlightGeoLocations)
        {
            try
            {
            return  connection.Delete<FlightGeoLocations>(FlightGeoLocations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FlightGeoLocations> GetAll(){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightGeoLocations> GetByApiId(int ApiId){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightGeoLocations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightGeoLocations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FlightGeoLocations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FlightGeoLocations>("FlightGeoLocationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightGeoLocations> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightGeoLocations> GetByLatitude(double Latitude){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetByLatitude", new
                {
Latitude = Latitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightGeoLocations> GetByLongitude(double Longitude){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetByLongitude", new
                {
Longitude = Longitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightGeoLocations> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightGeoLocations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<FlightGeoLocations>("FlightGeoLocationsGetCreatedDateBetween", new
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
