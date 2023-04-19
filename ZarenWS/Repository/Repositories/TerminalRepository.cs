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
    public class TerminalRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public TerminalRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Terminal Terminal)
    {
        try
        {
            return connection.Insert(Terminal);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Terminal Terminal)
    {
        try
        {
       return  connection.Update(Terminal);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Terminal Terminal)
        {
            try
            {
            return  connection.Delete<Terminal>(Terminal);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Terminal> GetAll(){
            try
            {
                return connection.Query<Terminal>("TerminalGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Terminal> GetByAirportId(int AirportId){
            try
            {
                return connection.Query<Terminal>("TerminalGetByAirportId", new
                {
AirportId = AirportId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Terminal GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Terminal>("TerminalGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Terminal> GetByActive(bool TerminalActive){
            try
            {
                return connection.Query<Terminal>("TerminalGetByTerminalActive", new
                {
TerminalActive = TerminalActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Terminal> GetByCode(string TerminalCode){
            try
            {
                return connection.Query<Terminal>("TerminalGetByTerminalCode", new
                {
TerminalCode = TerminalCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Terminal> GetByName(string TerminalName){
            try
            {
                return connection.Query<Terminal>("TerminalGetByTerminalName", new
                {
TerminalName = TerminalName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Terminal> GetByTimestamp(DateTime TerminalTimestamp){
            try
            {
                return connection.Query<Terminal>("TerminalGetByTerminalTimestamp", new
                {
TerminalTimestamp = TerminalTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Terminal> GetTimestampBetween(DateTime TerminalTimestampStart,DateTime TerminalTimestampEnd){
            try
            {
                return connection.Query<Terminal>("TerminalGetTerminalTimestampBetween", new
                {
TerminalTimestampStart = TerminalTimestampStart
,TerminalTimestampEnd = TerminalTimestampEnd
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
