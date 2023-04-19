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
    public class GroupKeysRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public GroupKeysRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(GroupKeys GroupKeys)
    {
        try
        {
            return connection.Insert(GroupKeys);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(GroupKeys GroupKeys)
    {
        try
        {
       return  connection.Update(GroupKeys);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(GroupKeys GroupKeys)
        {
            try
            {
            return  connection.Delete<GroupKeys>(GroupKeys);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<GroupKeys> GetAll(){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetByApiId(int ApiId){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetByFlightOffersId(int FlightOffersId){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetByFlightOffersId", new
                {
FlightOffersId = FlightOffersId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetByFlightsId(int FlightsId){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetByFlightsId", new
                {
FlightsId = FlightsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public GroupKeys GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<GroupKeys>("GroupKeysGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetByName(string Name){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetByOffersId(int OffersId){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetByOffersId", new
                {
OffersId = OffersId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<GroupKeys> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<GroupKeys>("GroupKeysGetCreatedDateBetween", new
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
