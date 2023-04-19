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
    public class CarRentalsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CarRentalsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CarRentals CarRentals)
    {
        try
        {
            return connection.Insert(CarRentals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CarRentals CarRentals)
    {
        try
        {
       return  connection.Update(CarRentals);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CarRentals CarRentals)
        {
            try
            {
            return  connection.Delete<CarRentals>(CarRentals);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CarRentals> GetAll(){
            try
            {
                return connection.Query<CarRentals>("CarRentalsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRentals> GetByCaRtActive(bool CaRtActive){
            try
            {
                return connection.Query<CarRentals>("CarRentalsGetByCaRtActive", new
                {
CaRtActive = CaRtActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRentals> GetByCaRtCode(string CaRtCode){
            try
            {
                return connection.Query<CarRentals>("CarRentalsGetByCaRtCode", new
                {
CaRtCode = CaRtCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRentals> GetByCaRtName(string CaRtName){
            try
            {
                return connection.Query<CarRentals>("CarRentalsGetByCaRtName", new
                {
CaRtName = CaRtName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRentals> GetByCaRtTimestamp(DateTime CaRtTimestamp){
            try
            {
                return connection.Query<CarRentals>("CarRentalsGetByCaRtTimestamp", new
                {
CaRtTimestamp = CaRtTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CarRentals GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CarRentals>("CarRentalsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CarRentals> GetCaRtTimestampBetween(DateTime CaRtTimestampStart,DateTime CaRtTimestampEnd){
            try
            {
                return connection.Query<CarRentals>("CarRentalsGetCaRtTimestampBetween", new
                {
CaRtTimestampStart = CaRtTimestampStart
,CaRtTimestampEnd = CaRtTimestampEnd
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
