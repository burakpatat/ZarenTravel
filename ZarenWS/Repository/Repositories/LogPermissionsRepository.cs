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
    public class LogPermissionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public LogPermissionsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(LogPermissions LogPermissions)
    {
        try
        {
            return connection.Insert(LogPermissions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(LogPermissions LogPermissions)
    {
        try
        {
       return  connection.Update(LogPermissions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(LogPermissions LogPermissions)
        {
            try
            {
            return  connection.Delete<LogPermissions>(LogPermissions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<LogPermissions> GetAll(){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByCanClassInit(int CanClassInit){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByCanClassInit", new
                {
CanClassInit = CanClassInit
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByCanClassList(int CanClassList){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByCanClassList", new
                {
CanClassList = CanClassList
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByCanGetList(int CanGetList){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByCanGetList", new
                {
CanGetList = CanGetList
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByCanGetOne(int CanGetOne){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByCanGetOne", new
                {
CanGetOne = CanGetOne
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByCanView(int CanView){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByCanView", new
                {
CanView = CanView
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByChangeDate(DateTime ChangeDate){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByChangeDate", new
                {
ChangeDate = ChangeDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByDatabaseTables(int DatabaseTables){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByDatabaseTables", new
                {
DatabaseTables = DatabaseTables
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public LogPermissions GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<LogPermissions>("LogPermissionsGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByModifyBy(int ModifyBy){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByModifyBy", new
                {
ModifyBy = ModifyBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByModifyDate(DateTime ModifyDate){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByModifyDate", new
                {
ModifyDate = ModifyDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByNote(string Note){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByNote", new
                {
Note = Note
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByProducts(int Products){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByProducts", new
                {
Products = Products
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetByUserID(int UserID){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetByUserID", new
                {
UserID = UserID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetChangeDateBetween(DateTime ChangeDateStart,DateTime ChangeDateEnd){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetChangeDateBetween", new
                {
ChangeDateStart = ChangeDateStart
,ChangeDateEnd = ChangeDateEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<LogPermissions> GetModifyDateBetween(DateTime ModifyDateStart,DateTime ModifyDateEnd){
            try
            {
                return connection.Query<LogPermissions>("LogPermissionsGetModifyDateBetween", new
                {
ModifyDateStart = ModifyDateStart
,ModifyDateEnd = ModifyDateEnd
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
