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
    public class BaggageUnitTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BaggageUnitTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(BaggageUnitTypes BaggageUnitTypes)
    {
        try
        {
            return connection.Insert(BaggageUnitTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(BaggageUnitTypes BaggageUnitTypes)
    {
        try
        {
       return  connection.Update(BaggageUnitTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(BaggageUnitTypes BaggageUnitTypes)
        {
            try
            {
            return  connection.Delete<BaggageUnitTypes>(BaggageUnitTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<BaggageUnitTypes> GetAll(){
            try
            {
                return connection.Query<BaggageUnitTypes>("BaggageUnitTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageUnitTypes> GetByApiId(int ApiId){
            try
            {
                return connection.Query<BaggageUnitTypes>("BaggageUnitTypesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageUnitTypes> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<BaggageUnitTypes>("BaggageUnitTypesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageUnitTypes> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<BaggageUnitTypes>("BaggageUnitTypesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageUnitTypes> GetByDescriptions(string Descriptions){
            try
            {
                return connection.Query<BaggageUnitTypes>("BaggageUnitTypesGetByDescriptions", new
                {
Descriptions = Descriptions
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public BaggageUnitTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<BaggageUnitTypes>("BaggageUnitTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageUnitTypes> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<BaggageUnitTypes>("BaggageUnitTypesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageUnitTypes> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<BaggageUnitTypes>("BaggageUnitTypesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<BaggageUnitTypes> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<BaggageUnitTypes>("BaggageUnitTypesGetCreatedDateBetween", new
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
