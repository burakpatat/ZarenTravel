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
    public class AirExtrasRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AirExtrasRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AirExtras AirExtras)
    {
        try
        {
            return connection.Insert(AirExtras);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AirExtras AirExtras)
    {
        try
        {
       return  connection.Update(AirExtras);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AirExtras AirExtras)
        {
            try
            {
            return  connection.Delete<AirExtras>(AirExtras);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AirExtras> GetAiExTimestampBetween(DateTime AiExTimestampStart,DateTime AiExTimestampEnd){
            try
            {
                return connection.Query<AirExtras>("AirExtrasGetAiExTimestampBetween", new
                {
AiExTimestampStart = AiExTimestampStart
,AiExTimestampEnd = AiExTimestampEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirExtras> GetAll(){
            try
            {
                return connection.Query<AirExtras>("AirExtrasGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirExtras> GetByAiExActive(bool AiExActive){
            try
            {
                return connection.Query<AirExtras>("AirExtrasGetByAiExActive", new
                {
AiExActive = AiExActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirExtras> GetByAiExDescription(string AiExDescription){
            try
            {
                return connection.Query<AirExtras>("AirExtrasGetByAiExDescription", new
                {
AiExDescription = AiExDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirExtras> GetByAiExFare(decimal AiExFare){
            try
            {
                return connection.Query<AirExtras>("AirExtrasGetByAiExFare", new
                {
AiExFare = AiExFare
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirExtras> GetByAiExTimestamp(DateTime AiExTimestamp){
            try
            {
                return connection.Query<AirExtras>("AirExtrasGetByAiExTimestamp", new
                {
AiExTimestamp = AiExTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirExtras> GetByAirId(int AirId){
            try
            {
                return connection.Query<AirExtras>("AirExtrasGetByAirId", new
                {
AirId = AirId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirExtras> GetByExTyId(int ExTyId){
            try
            {
                return connection.Query<AirExtras>("AirExtrasGetByExTyId", new
                {
ExTyId = ExTyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AirExtras GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AirExtras>("AirExtrasGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

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
