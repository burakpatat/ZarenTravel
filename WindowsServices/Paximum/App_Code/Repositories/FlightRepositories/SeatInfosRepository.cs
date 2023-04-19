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
    public class SeatInfosRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SeatInfosRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SeatInfos SeatInfos)
    {
        try
        {
            return connection.Insert(SeatInfos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SeatInfos SeatInfos)
    {
        try
        {
       return  connection.Update(SeatInfos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SeatInfos SeatInfos)
        {
            try
            {
            return  connection.Delete<SeatInfos>(SeatInfos);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SeatInfos> GetAll(){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeatInfos> GetByApiId(int ApiId){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeatInfos> GetByAvailableSeatCount(int AvailableSeatCount){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetByAvailableSeatCount", new
                {
AvailableSeatCount = AvailableSeatCount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeatInfos> GetByAvailableSeatCountTypeId(int AvailableSeatCountTypeId){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetByAvailableSeatCountTypeId", new
                {
AvailableSeatCountTypeId = AvailableSeatCountTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeatInfos> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeatInfos> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SeatInfos GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SeatInfos>("SeatInfosGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeatInfos> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeatInfos> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeatInfos> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SeatInfos>("SeatInfosGetCreatedDateBetween", new
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
