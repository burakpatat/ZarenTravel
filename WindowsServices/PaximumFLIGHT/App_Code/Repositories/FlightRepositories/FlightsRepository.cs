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
    public class FlightsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FlightsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Flights Flights)
    {
        try
        {
            return connection.Insert(Flights);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Flights Flights)
    {
        try
        {
       return  connection.Update(Flights);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Flights Flights)
        {
            try
            {
            return  connection.Delete<Flights>(Flights);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Flights> GetAll(){
            try
            {
                return connection.Query<Flights>("FlightsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Flights>("FlightsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetByAvailableSeatCount(int AvailableSeatCount){
            try
            {
                return connection.Query<Flights>("FlightsGetByAvailableSeatCount", new
                {
AvailableSeatCount = AvailableSeatCount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetByAvailableSeatCountType(int AvailableSeatCountType){
            try
            {
                return connection.Query<Flights>("FlightsGetByAvailableSeatCountType", new
                {
AvailableSeatCountType = AvailableSeatCountType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Flights>("FlightsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Flights>("FlightsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Flights GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Flights>("FlightsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Flights>("FlightsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetByProvider(int Provider){
            try
            {
                return connection.Query<Flights>("FlightsGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Flights>("FlightsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Flights> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Flights>("FlightsGetCreatedDateBetween", new
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
