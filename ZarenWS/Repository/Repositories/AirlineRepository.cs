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
    public class AirlineRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AirlineRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Airline Airline)
    {
        try
        {
            return connection.Insert(Airline);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Airline Airline)
    {
        try
        {
       return  connection.Update(Airline);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Airline Airline)
        {
            try
            {
            return  connection.Delete<Airline>(Airline);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Airline> GetTimestampBetween(DateTime AirlineTimestampStart,DateTime AirlineTimestampEnd){
            try
            {
                return connection.Query<Airline>("AirlineGetAirlineTimestampBetween", new
                {
AirlineTimestampStart = AirlineTimestampStart
,AirlineTimestampEnd = AirlineTimestampEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airline> GetAll(){
            try
            {
                return connection.Query<Airline>("AirlineGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airline> GetByActive(bool AirlineActive){
            try
            {
                return connection.Query<Airline>("AirlineGetByAirlineActive", new
                {
AirlineActive = AirlineActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airline> GetByCode(string AirlineCode){
            try
            {
                return connection.Query<Airline>("AirlineGetByAirlineCode", new
                {
AirlineCode = AirlineCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airline> GetByName(string AirlineName){
            try
            {
                return connection.Query<Airline>("AirlineGetByAirlineName", new
                {
AirlineName = AirlineName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airline> GetByPlate(string AirlinePlate){
            try
            {
                return connection.Query<Airline>("AirlineGetByAirlinePlate", new
                {
AirlinePlate = AirlinePlate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Airline> GetByTimestamp(DateTime AirlineTimestamp){
            try
            {
                return connection.Query<Airline>("AirlineGetByAirlineTimestamp", new
                {
AirlineTimestamp = AirlineTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Airline GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Airline>("AirlineGetByID", new
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
