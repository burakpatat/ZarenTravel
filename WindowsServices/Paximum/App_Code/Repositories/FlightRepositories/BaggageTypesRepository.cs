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
    public class BaggageTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BaggageTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BaggageTypes BaggageTypes)
    {
        try
        {
            return connection.Insert(BaggageTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BaggageTypes BaggageTypes)
    {
        try
        {
       return  connection.Update(BaggageTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BaggageTypes BaggageTypes)
        {
            try
            {
            return  connection.Delete<BaggageTypes>(BaggageTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BaggageTypes> GetAll(){
            try
            {
                return connection.Query<BaggageTypes>("BaggageTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageTypes> GetByApiId(int ApiId){
            try
            {
                return connection.Query<BaggageTypes>("BaggageTypesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageTypes> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<BaggageTypes>("BaggageTypesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageTypes> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<BaggageTypes>("BaggageTypesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageTypes> GetByDescription(string Description){
            try
            {
                return connection.Query<BaggageTypes>("BaggageTypesGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BaggageTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BaggageTypes>("BaggageTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageTypes> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<BaggageTypes>("BaggageTypesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageTypes> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<BaggageTypes>("BaggageTypesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageTypes> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<BaggageTypes>("BaggageTypesGetCreatedDateBetween", new
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
