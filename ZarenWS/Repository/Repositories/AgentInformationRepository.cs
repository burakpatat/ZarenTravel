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
    public class AgentInformationRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgentInformationRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgentInformation AgentInformation)
    {
        try
        {
            return connection.Insert(AgentInformation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgentInformation AgentInformation)
    {
        try
        {
       return  connection.Update(AgentInformation);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgentInformation AgentInformation)
        {
            try
            {
            return  connection.Delete<AgentInformation>(AgentInformation);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgentInformation> GetAll(){
            try
            {
                return connection.Query<AgentInformation>("AgentInformationGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgentInformation> GetByAgentName(string AgentName){
            try
            {
                return connection.Query<AgentInformation>("AgentInformationGetByAgentName", new
                {
AgentName = AgentName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgentInformation> GetByAgentStation(string AgentStation){
            try
            {
                return connection.Query<AgentInformation>("AgentInformationGetByAgentStation", new
                {
AgentStation = AgentStation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgentInformation> GetByFILE_ID(int FILE_ID){
            try
            {
                return connection.Query<AgentInformation>("AgentInformationGetByFILE_ID", new
                {
FILE_ID = FILE_ID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgentInformation> GetByFILE_NAME(string FILE_NAME){
            try
            {
                return connection.Query<AgentInformation>("AgentInformationGetByFILE_NAME", new
                {
FILE_NAME = FILE_NAME
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgentInformation GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgentInformation>("AgentInformationGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgentInformation> GetByRecordDateStamp(DateTime RecordDateStamp){
            try
            {
                return connection.Query<AgentInformation>("AgentInformationGetByRecordDateStamp", new
                {
RecordDateStamp = RecordDateStamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgentInformation> GetRecordDateStampBetween(DateTime RecordDateStampStart,DateTime RecordDateStampEnd){
            try
            {
                return connection.Query<AgentInformation>("AgentInformationGetRecordDateStampBetween", new
                {
RecordDateStampStart = RecordDateStampStart
,RecordDateStampEnd = RecordDateStampEnd
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
