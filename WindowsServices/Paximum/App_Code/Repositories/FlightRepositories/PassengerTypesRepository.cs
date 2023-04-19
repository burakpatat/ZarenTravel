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
    public class PassengerTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PassengerTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PassengerTypes PassengerTypes)
    {
        try
        {
            return connection.Insert(PassengerTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PassengerTypes PassengerTypes)
    {
        try
        {
       return  connection.Update(PassengerTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PassengerTypes PassengerTypes)
        {
            try
            {
            return  connection.Delete<PassengerTypes>(PassengerTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PassengerTypes> GetAll(){
            try
            {
                return connection.Query<PassengerTypes>("PassengerTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerTypes> GetByApiId(int ApiId){
            try
            {
                return connection.Query<PassengerTypes>("PassengerTypesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerTypes> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<PassengerTypes>("PassengerTypesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerTypes> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<PassengerTypes>("PassengerTypesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerTypes> GetByDescription(string Description){
            try
            {
                return connection.Query<PassengerTypes>("PassengerTypesGetByDescription", new
                {
Description = Description
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PassengerTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PassengerTypes>("PassengerTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerTypes> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<PassengerTypes>("PassengerTypesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerTypes> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<PassengerTypes>("PassengerTypesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PassengerTypes> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<PassengerTypes>("PassengerTypesGetCreatedDateBetween", new
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
