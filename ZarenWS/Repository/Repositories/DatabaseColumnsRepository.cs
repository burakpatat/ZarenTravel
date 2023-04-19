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
    public class DatabaseColumnsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public DatabaseColumnsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(DatabaseColumns DatabaseColumns)
    {
        try
        {
            return connection.Insert(DatabaseColumns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(DatabaseColumns DatabaseColumns)
    {
        try
        {
       return  connection.Update(DatabaseColumns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(DatabaseColumns DatabaseColumns)
        {
            try
            {
            return  connection.Delete<DatabaseColumns>(DatabaseColumns);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<DatabaseColumns> GetAll(){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByCMSColumnTitle(string CMSColumnTitle){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByCMSColumnTitle", new
                {
CMSColumnTitle = CMSColumnTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByCMSInputType(int CMSInputType){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByCMSInputType", new
                {
CMSInputType = CMSInputType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByColumnName(string ColumnName){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByColumnName", new
                {
ColumnName = ColumnName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByDbType(int DbType){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByDbType", new
                {
DbType = DbType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByErrorDescription(string ErrorDescription){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByErrorDescription", new
                {
ErrorDescription = ErrorDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByHasDefaultValue(bool HasDefaultValue){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByHasDefaultValue", new
                {
HasDefaultValue = HasDefaultValue
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByHasShowedOnList(bool HasShowedOnList){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByHasShowedOnList", new
                {
HasShowedOnList = HasShowedOnList
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public DatabaseColumns GetByID(int ID){
            try
            {
                return connection.QueryFirstOrDefault<DatabaseColumns>("DatabaseColumnsGetByID", new
                {
ID = ID
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByIsFilter(bool IsFilter){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByIsFilter", new
                {
IsFilter = IsFilter
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByIsLanguageField(bool IsLanguageField){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByIsLanguageField", new
                {
IsLanguageField = IsLanguageField
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByIsNullable(bool IsNullable){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByIsNullable", new
                {
IsNullable = IsNullable
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByIsPrimary(bool IsPrimary){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByIsPrimary", new
                {
IsPrimary = IsPrimary
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByIsPublic(bool IsPublic){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByIsPublic", new
                {
IsPublic = IsPublic
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByIsRequired(bool IsRequired){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByIsRequired", new
                {
IsRequired = IsRequired
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByIsRoutingField(bool IsRoutingField){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByIsRoutingField", new
                {
IsRoutingField = IsRoutingField
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByIsSecondry(bool IsSecondry){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByIsSecondry", new
                {
IsSecondry = IsSecondry
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByJsonName(string JsonName){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByJsonName", new
                {
JsonName = JsonName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByMaxLength(int MaxLength){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByMaxLength", new
                {
MaxLength = MaxLength
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByParameterDescription(string ParameterDescription){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByParameterDescription", new
                {
ParameterDescription = ParameterDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByResize(string Resize){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByResize", new
                {
Resize = Resize
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByReturnColumnNameFromCMSTitle(bool ReturnColumnNameFromCMSTitle){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByReturnColumnNameFromCMSTitle", new
                {
ReturnColumnNameFromCMSTitle = ReturnColumnNameFromCMSTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetBySelectedDataSourceTable(string SelectedDataSourceTable){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetBySelectedDataSourceTable", new
                {
SelectedDataSourceTable = SelectedDataSourceTable
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetBySelectedText(string SelectedText){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetBySelectedText", new
                {
SelectedText = SelectedText
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetBySelectedValue(string SelectedValue){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetBySelectedValue", new
                {
SelectedValue = SelectedValue
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByTableID(int TableID){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByTableID", new
                {
TableID = TableID
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByTableOrder(int TableOrder){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByTableOrder", new
                {
TableOrder = TableOrder
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<DatabaseColumns> GetByTooltip(string Tooltip){
            try
            {
                return connection.Query<DatabaseColumns>("DatabaseColumnsGetByTooltip", new
                {
Tooltip = Tooltip
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
