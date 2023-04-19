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
    public class ExtrasTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ExtrasTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(ExtrasType ExtrasType)
    {
        try
        {
            return connection.Insert(ExtrasType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(ExtrasType ExtrasType)
    {
        try
        {
       return  connection.Update(ExtrasType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(ExtrasType ExtrasType)
        {
            try
            {
            return  connection.Delete<ExtrasType>(ExtrasType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<ExtrasType> GetAll(){
            try
            {
                return connection.Query<ExtrasType>("ExtrasTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExtrasType> GetByExTyActive(bool ExTyActive){
            try
            {
                return connection.Query<ExtrasType>("ExtrasTypeGetByExTyActive", new
                {
ExTyActive = ExTyActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExtrasType> GetByExTyCode(string ExTyCode){
            try
            {
                return connection.Query<ExtrasType>("ExtrasTypeGetByExTyCode", new
                {
ExTyCode = ExTyCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExtrasType> GetByExTyName(string ExTyName){
            try
            {
                return connection.Query<ExtrasType>("ExtrasTypeGetByExTyName", new
                {
ExTyName = ExTyName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExtrasType> GetByExTyTimestamp(DateTime ExTyTimestamp){
            try
            {
                return connection.Query<ExtrasType>("ExtrasTypeGetByExTyTimestamp", new
                {
ExTyTimestamp = ExTyTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public ExtrasType GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<ExtrasType>("ExtrasTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<ExtrasType> GetExTyTimestampBetween(DateTime ExTyTimestampStart,DateTime ExTyTimestampEnd){
            try
            {
                return connection.Query<ExtrasType>("ExtrasTypeGetExTyTimestampBetween", new
                {
ExTyTimestampStart = ExTyTimestampStart
,ExTyTimestampEnd = ExTyTimestampEnd
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
