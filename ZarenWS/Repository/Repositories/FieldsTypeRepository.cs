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
    public class FieldsTypeRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public FieldsTypeRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(FieldsType FieldsType)
    {
        try
        {
            return connection.Insert(FieldsType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(FieldsType FieldsType)
    {
        try
        {
       return  connection.Update(FieldsType);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(FieldsType FieldsType)
        {
            try
            {
            return  connection.Delete<FieldsType>(FieldsType);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<FieldsType> GetAll(){
            try
            {
                return connection.Query<FieldsType>("FieldsTypeGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FieldsType> GetByFiTyActive(bool FiTyActive){
            try
            {
                return connection.Query<FieldsType>("FieldsTypeGetByFiTyActive", new
                {
FiTyActive = FiTyActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FieldsType> GetByFiTyCode(string FiTyCode){
            try
            {
                return connection.Query<FieldsType>("FieldsTypeGetByFiTyCode", new
                {
FiTyCode = FiTyCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FieldsType> GetByFiTyName(string FiTyName){
            try
            {
                return connection.Query<FieldsType>("FieldsTypeGetByFiTyName", new
                {
FiTyName = FiTyName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FieldsType> GetByFiTyTimestamp(DateTime FiTyTimestamp){
            try
            {
                return connection.Query<FieldsType>("FieldsTypeGetByFiTyTimestamp", new
                {
FiTyTimestamp = FiTyTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public FieldsType GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<FieldsType>("FieldsTypeGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<FieldsType> GetFiTyTimestampBetween(DateTime FiTyTimestampStart,DateTime FiTyTimestampEnd){
            try
            {
                return connection.Query<FieldsType>("FieldsTypeGetFiTyTimestampBetween", new
                {
FiTyTimestampStart = FiTyTimestampStart
,FiTyTimestampEnd = FiTyTimestampEnd
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
