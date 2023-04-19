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
    public class PassengersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PassengersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Passengers Passengers)
    {
        try
        {
            return connection.Insert(Passengers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Passengers Passengers)
    {
        try
        {
       return  connection.Update(Passengers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Passengers Passengers)
        {
            try
            {
            return  connection.Delete<Passengers>(Passengers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Passengers> GetAll(){
            try
            {
                return connection.Query<Passengers>("PassengersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Passengers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Passengers>("PassengersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassemgerTimestamp(DateTime PassemgerTimestamp){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassemgerTimestamp", new
                {
PassemgerTimestamp = PassemgerTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassengerActive(bool PassengerActive){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassengerActive", new
                {
PassengerActive = PassengerActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassengerCelPhone(string PassengerCelPhone){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassengerCelPhone", new
                {
PassengerCelPhone = PassengerCelPhone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassengerEmail(string PassengerEmail){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassengerEmail", new
                {
PassengerEmail = PassengerEmail
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassengerFullName(string PassengerFullName){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassengerFullName", new
                {
PassengerFullName = PassengerFullName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassengerJobPosition(string PassengerJobPosition){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassengerJobPosition", new
                {
PassengerJobPosition = PassengerJobPosition
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassengerPhone(string PassengerPhone){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassengerPhone", new
                {
PassengerPhone = PassengerPhone
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetByPassengerVIP(bool PassengerVIP){
            try
            {
                return connection.Query<Passengers>("PassengersGetByPassengerVIP", new
                {
PassengerVIP = PassengerVIP
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Passengers> GetPassemgerTimestampBetween(DateTime PassemgerTimestampStart,DateTime PassemgerTimestampEnd){
            try
            {
                return connection.Query<Passengers>("PassengersGetPassemgerTimestampBetween", new
                {
PassemgerTimestampStart = PassemgerTimestampStart
,PassemgerTimestampEnd = PassemgerTimestampEnd
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
