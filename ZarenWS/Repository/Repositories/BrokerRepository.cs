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
    public class BrokerRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public BrokerRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Broker Broker)
    {
        try
        {
            return connection.Insert(Broker);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Broker Broker)
    {
        try
        {
       return  connection.Update(Broker);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Broker Broker)
        {
            try
            {
            return  connection.Delete<Broker>(Broker);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Broker> GetAll(){
            try
            {
                return connection.Query<Broker>("BrokerGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Broker> GetTimestampBetween(DateTime BrokerTimestampStart,DateTime BrokerTimestampEnd){
            try
            {
                return connection.Query<Broker>("BrokerGetBrokerTimestampBetween", new
                {
BrokerTimestampStart = BrokerTimestampStart
,BrokerTimestampEnd = BrokerTimestampEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Broker> GetByActive(bool BrokerActive){
            try
            {
                return connection.Query<Broker>("BrokerGetByBrokerActive", new
                {
BrokerActive = BrokerActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Broker> GetByCode(string BrokerCode){
            try
            {
                return connection.Query<Broker>("BrokerGetByBrokerCode", new
                {
BrokerCode = BrokerCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Broker> GetByName(string BrokerName){
            try
            {
                return connection.Query<Broker>("BrokerGetByBrokerName", new
                {
BrokerName = BrokerName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Broker> GetByTimestamp(DateTime BrokerTimestamp){
            try
            {
                return connection.Query<Broker>("BrokerGetByBrokerTimestamp", new
                {
BrokerTimestamp = BrokerTimestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Broker GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Broker>("BrokerGetByID", new
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
