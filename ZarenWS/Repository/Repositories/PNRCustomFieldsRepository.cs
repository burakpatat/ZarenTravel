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
    public class PNRCustomFieldsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PNRCustomFieldsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PNRCustomFields PNRCustomFields)
    {
        try
        {
            return connection.Insert(PNRCustomFields);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PNRCustomFields PNRCustomFields)
    {
        try
        {
       return  connection.Update(PNRCustomFields);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PNRCustomFields PNRCustomFields)
        {
            try
            {
            return  connection.Delete<PNRCustomFields>(PNRCustomFields);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PNRCustomFields> GetAll(){
            try
            {
                return connection.Query<PNRCustomFields>("PNRCustomFieldsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRCustomFields> GetByFiTyActive(bool FiTyActive){
            try
            {
                return connection.Query<PNRCustomFields>("PNRCustomFieldsGetByFiTyActive", new
                {
FiTyActive = FiTyActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRCustomFields> GetByFiTyId(int FiTyId){
            try
            {
                return connection.Query<PNRCustomFields>("PNRCustomFieldsGetByFiTyId", new
                {
FiTyId = FiTyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRCustomFields> GetByFiTyTimestamp(DateTime FiTyTimestamp){
            try
            {
                return connection.Query<PNRCustomFields>("PNRCustomFieldsGetByFiTyTimestamp", new
                {
FiTyTimestamp = FiTyTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PNRCustomFields GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PNRCustomFields>("PNRCustomFieldsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRCustomFields> GetByPnCuValue(string PnCuValue){
            try
            {
                return connection.Query<PNRCustomFields>("PNRCustomFieldsGetByPnCuValue", new
                {
PnCuValue = PnCuValue
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRCustomFields> GetByPNRId(int PNRId){
            try
            {
                return connection.Query<PNRCustomFields>("PNRCustomFieldsGetByPNRId", new
                {
PNRId = PNRId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PNRCustomFields> GetFiTyTimestampBetween(DateTime FiTyTimestampStart,DateTime FiTyTimestampEnd){
            try
            {
                return connection.Query<PNRCustomFields>("PNRCustomFieldsGetFiTyTimestampBetween", new
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
