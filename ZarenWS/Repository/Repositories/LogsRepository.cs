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
    public class LogsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public LogsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Logs Logs)
    {
        try
        {
            return connection.Insert(Logs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Logs Logs)
    {
        try
        {
       return  connection.Update(Logs);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Logs Logs)
        {
            try
            {
            return  connection.Delete<Logs>(Logs);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Logs> GetAll(){
            try
            {
                return connection.Query<Logs>("LogsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByDate(DateTime Date){
            try
            {
                return connection.Query<Logs>("LogsGetByDate", new
                {
Date = Date
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByDescription(string Description){
            try
            {
                return connection.Query<Logs>("LogsGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Logs GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<Logs>("LogsGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByLogMethod(string LogMethod){
            try
            {
                return connection.Query<Logs>("LogsGetByLogMethod", new
                {
LogMethod = LogMethod
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByLogPath(string LogPath){
            try
            {
                return connection.Query<Logs>("LogsGetByLogPath", new
                {
LogPath = LogPath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByType(int Type){
            try
            {
                return connection.Query<Logs>("LogsGetByType", new
                {
Type = Type
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByUrlOriginalString(string UrlOriginalString){
            try
            {
                return connection.Query<Logs>("LogsGetByUrlOriginalString", new
                {
UrlOriginalString = UrlOriginalString
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByUserAgent(string UserAgent){
            try
            {
                return connection.Query<Logs>("LogsGetByUserAgent", new
                {
UserAgent = UserAgent
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByUserHostAddress(string UserHostAddress){
            try
            {
                return connection.Query<Logs>("LogsGetByUserHostAddress", new
                {
UserHostAddress = UserHostAddress
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetByUserID(int UserID){
            try
            {
                return connection.Query<Logs>("LogsGetByUserID", new
                {
UserID = UserID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Logs> GetDateBetween(DateTime DateStart,DateTime DateEnd){
            try
            {
                return connection.Query<Logs>("LogsGetDateBetween", new
                {
DateStart = DateStart
,DateEnd = DateEnd
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
