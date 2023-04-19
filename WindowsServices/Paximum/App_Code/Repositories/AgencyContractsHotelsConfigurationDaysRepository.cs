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
    public class AgencyContractsHotelsConfigurationDaysRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsHotelsConfigurationDaysRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsHotelsConfigurationDays AgencyContractsHotelsConfigurationDays)
    {
        try
        {
            return connection.Insert(AgencyContractsHotelsConfigurationDays);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsHotelsConfigurationDays AgencyContractsHotelsConfigurationDays)
    {
        try
        {
       return  connection.Update(AgencyContractsHotelsConfigurationDays);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsHotelsConfigurationDays AgencyContractsHotelsConfigurationDays)
        {
            try
            {
            return  connection.Delete<AgencyContractsHotelsConfigurationDays>(AgencyContractsHotelsConfigurationDays);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsHotelsConfigurationDays> GetAll(){
            try
            {
                return connection.Query<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfigurationDays> GetByFriday(bool Friday){
            try
            {
                return connection.Query<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetByFriday", new
                {
Friday = Friday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsHotelsConfigurationDays GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfigurationDays> GetByMonday(bool Monday){
            try
            {
                return connection.Query<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetByMonday", new
                {
Monday = Monday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfigurationDays> GetBySaturday(bool Saturday){
            try
            {
                return connection.Query<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetBySaturday", new
                {
Saturday = Saturday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfigurationDays> GetBySunday(bool Sunday){
            try
            {
                return connection.Query<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetBySunday", new
                {
Sunday = Sunday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfigurationDays> GetByThursday(bool Thursday){
            try
            {
                return connection.Query<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetByThursday", new
                {
Thursday = Thursday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfigurationDays> GetByTuesday(bool Tuesday){
            try
            {
                return connection.Query<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetByTuesday", new
                {
Tuesday = Tuesday
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsHotelsConfigurationDays> GetByWednesday(bool Wednesday){
            try
            {
                return connection.Query<AgencyContractsHotelsConfigurationDays>("AgencyContractsHotelsConfigurationDaysGetByWednesday", new
                {
Wednesday = Wednesday
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
