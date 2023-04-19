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
    public class AirportRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AirportRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Airport Airport)
    {
        try
        {
            return connection.Insert(Airport);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Airport Airport)
    {
        try
        {
       return  connection.Update(Airport);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Airport Airport)
        {
            try
            {
            return  connection.Delete<Airport>(Airport);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Airport> GetTimestampBetween(DateTime AirportTimestampStart,DateTime AirportTimestampEnd){
            try
            {
                return connection.Query<Airport>("AirportGetAirportTimestampBetween", new
                {
AirportTimestampStart = AirportTimestampStart
,AirportTimestampEnd = AirportTimestampEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airport> GetAll(){
            try
            {
                return connection.Query<Airport>("AirportGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airport> GetByActive(bool AirportActive){
            try
            {
                return connection.Query<Airport>("AirportGetByAirportActive", new
                {
AirportActive = AirportActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airport> GetByCode(string AirportCode){
            try
            {
                return connection.Query<Airport>("AirportGetByAirportCode", new
                {
AirportCode = AirportCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airport> GetByName(string AirportName){
            try
            {
                return connection.Query<Airport>("AirportGetByAirportName", new
                {
AirportName = AirportName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airport> GetByTimestamp(DateTime AirportTimestamp){
            try
            {
                return connection.Query<Airport>("AirportGetByAirportTimestamp", new
                {
AirportTimestamp = AirportTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airport> GetByCityId(int CityId){
            try
            {
                return connection.Query<Airport>("AirportGetByCityId", new
                {
CityId = CityId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airport> GetByCountryId(int CountryId){
            try
            {
                return connection.Query<Airport>("AirportGetByCountryId", new
                {
CountryId = CountryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Airport GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Airport>("AirportGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

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
