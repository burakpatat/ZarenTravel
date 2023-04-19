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
    public class FlightProvidersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FlightProvidersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FlightProviders FlightProviders)
    {
        try
        {
            return connection.Insert(FlightProviders);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FlightProviders FlightProviders)
    {
        try
        {
       return  connection.Update(FlightProviders);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FlightProviders FlightProviders)
        {
            try
            {
            return  connection.Delete<FlightProviders>(FlightProviders);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FlightProviders> GetAll(){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetByApiId(int ApiId){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetByDisplayName(string DisplayName){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetByDisplayName", new
                {
DisplayName = DisplayName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FlightProviders GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FlightProviders>("FlightProvidersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetByItemsId(int ItemsId){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetByItemsId", new
                {
ItemsId = ItemsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetByName(string Name){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FlightProviders> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<FlightProviders>("FlightProvidersGetCreatedDateBetween", new
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
