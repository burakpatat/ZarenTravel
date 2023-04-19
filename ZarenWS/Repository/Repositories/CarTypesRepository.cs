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
    public class CarTypesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CarTypesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CarTypes CarTypes)
    {
        try
        {
            return connection.Insert(CarTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CarTypes CarTypes)
    {
        try
        {
       return  connection.Update(CarTypes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CarTypes CarTypes)
        {
            try
            {
            return  connection.Delete<CarTypes>(CarTypes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CarTypes> GetAll(){
            try
            {
                return connection.Query<CarTypes>("CarTypesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarTypes> GetByCaTyActive(bool CaTyActive){
            try
            {
                return connection.Query<CarTypes>("CarTypesGetByCaTyActive", new
                {
CaTyActive = CaTyActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarTypes> GetByCaTyCode(string CaTyCode){
            try
            {
                return connection.Query<CarTypes>("CarTypesGetByCaTyCode", new
                {
CaTyCode = CaTyCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarTypes> GetByCaTyDescription(string CaTyDescription){
            try
            {
                return connection.Query<CarTypes>("CarTypesGetByCaTyDescription", new
                {
CaTyDescription = CaTyDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarTypes> GetByCaTyTimestamp(DateTime CaTyTimestamp){
            try
            {
                return connection.Query<CarTypes>("CarTypesGetByCaTyTimestamp", new
                {
CaTyTimestamp = CaTyTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CarTypes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CarTypes>("CarTypesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarTypes> GetCaTyTimestampBetween(DateTime CaTyTimestampStart,DateTime CaTyTimestampEnd){
            try
            {
                return connection.Query<CarTypes>("CarTypesGetCaTyTimestampBetween", new
                {
CaTyTimestampStart = CaTyTimestampStart
,CaTyTimestampEnd = CaTyTimestampEnd
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
