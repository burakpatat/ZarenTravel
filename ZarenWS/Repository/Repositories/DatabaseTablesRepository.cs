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
    public class DatabaseTablesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DatabaseTablesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(DatabaseTables DatabaseTables)
    {
        try
        {
            return connection.Insert(DatabaseTables);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(DatabaseTables DatabaseTables)
    {
        try
        {
       return  connection.Update(DatabaseTables);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(DatabaseTables DatabaseTables)
        {
            try
            {
            return  connection.Delete<DatabaseTables>(DatabaseTables);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<DatabaseTables> GetAll(){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByCanGenerate(bool CanGenerate){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByCanGenerate", new
                {
CanGenerate = CanGenerate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByCMSGridSize(int CMSGridSize){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByCMSGridSize", new
                {
CMSGridSize = CMSGridSize
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByCMSIcon(string CMSIcon){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByCMSIcon", new
                {
CMSIcon = CMSIcon
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByCMSLinkedTables(string CMSLinkedTables){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByCMSLinkedTables", new
                {
CMSLinkedTables = CMSLinkedTables
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByCreateDate(DateTime CreateDate){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByCreateDate", new
                {
CreateDate = CreateDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByDisplayName(string DisplayName){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByDisplayName", new
                {
DisplayName = DisplayName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByForUser(bool ForUser){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByForUser", new
                {
ForUser = ForUser
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByFrontPageName(string FrontPageName){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByFrontPageName", new
                {
FrontPageName = FrontPageName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByHasMultiLanguage(bool HasMultiLanguage){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByHasMultiLanguage", new
                {
HasMultiLanguage = HasMultiLanguage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public DatabaseTables GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<DatabaseTables>("DatabaseTablesGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByIsRouting(bool IsRouting){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByIsRouting", new
                {
IsRouting = IsRouting
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByParentTable(int ParentTable){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByParentTable", new
                {
ParentTable = ParentTable
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByTableName(string TableName){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByTableName", new
                {
TableName = TableName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseTables> GetCreateDateBetween(DateTime CreateDateStart,DateTime CreateDateEnd){
            try
            {
                return connection.Query<DatabaseTables>("DatabaseTablesGetCreateDateBetween", new
                {
CreateDateStart = CreateDateStart
,CreateDateEnd = CreateDateEnd
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
