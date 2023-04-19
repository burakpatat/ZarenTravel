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
    public class AirSegmentsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AirSegmentsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AirSegments AirSegments)
    {
        try
        {
            return connection.Insert(AirSegments);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AirSegments AirSegments)
    {
        try
        {
       return  connection.Update(AirSegments);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AirSegments AirSegments)
        {
            try
            {
            return  connection.Delete<AirSegments>(AirSegments);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AirSegments> GetAiSeArrivalBetween(DateTime AiSeArrivalStart,DateTime AiSeArrivalEnd){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetAiSeArrivalBetween", new
                {
AiSeArrivalStart = AiSeArrivalStart
,AiSeArrivalEnd = AiSeArrivalEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetAiSeDepartureBetween(DateTime AiSeDepartureStart,DateTime AiSeDepartureEnd){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetAiSeDepartureBetween", new
                {
AiSeDepartureStart = AiSeDepartureStart
,AiSeDepartureEnd = AiSeDepartureEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetAiSeTimestampBetween(DateTime AiSeTimestampStart,DateTime AiSeTimestampEnd){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetAiSeTimestampBetween", new
                {
AiSeTimestampStart = AiSeTimestampStart
,AiSeTimestampEnd = AiSeTimestampEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetAll(){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAirId(int AirId){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAirId", new
                {
AirId = AirId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAirlineId(int AirlineId){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAirlineId", new
                {
AirlineId = AirlineId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAirportIdDestination(int AirportIdDestination){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAirportIdDestination", new
                {
AirportIdDestination = AirportIdDestination
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAirportIdOrigin(int AirportIdOrigin){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAirportIdOrigin", new
                {
AirportIdOrigin = AirportIdOrigin
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAiSeActive(bool AiSeActive){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAiSeActive", new
                {
AiSeActive = AiSeActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAiSeArrival(DateTime AiSeArrival){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAiSeArrival", new
                {
AiSeArrival = AiSeArrival
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAiSeClass(bool AiSeClass){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAiSeClass", new
                {
AiSeClass = AiSeClass
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAiSeDeparture(DateTime AiSeDeparture){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAiSeDeparture", new
                {
AiSeDeparture = AiSeDeparture
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAiSeFlightNumber(string AiSeFlightNumber){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAiSeFlightNumber", new
                {
AiSeFlightNumber = AiSeFlightNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByAiSeTimestamp(DateTime AiSeTimestamp){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByAiSeTimestamp", new
                {
AiSeTimestamp = AiSeTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AirSegments GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AirSegments>("AirSegmentsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByTerminalIdDestination(int TerminalIdDestination){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByTerminalIdDestination", new
                {
TerminalIdDestination = TerminalIdDestination
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirSegments> GetByTerminalIdOrigin(int TerminalIdOrigin){
            try
            {
                return connection.Query<AirSegments>("AirSegmentsGetByTerminalIdOrigin", new
                {
TerminalIdOrigin = TerminalIdOrigin
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
