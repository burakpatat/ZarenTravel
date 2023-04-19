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
    public class AgencyGroupRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyGroupRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyGroup AgencyGroup)
    {
        try
        {
            return connection.Insert(AgencyGroup);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyGroup AgencyGroup)
    {
        try
        {
       return  connection.Update(AgencyGroup);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyGroup AgencyGroup)
        {
            try
            {
            return  connection.Delete<AgencyGroup>(AgencyGroup);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyGroup> GetAll(){
            try
            {
                return connection.Query<AgencyGroup>("AgencyGroupGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyGroup> GetByActive(bool Active){
            try
            {
                return connection.Query<AgencyGroup>("AgencyGroupGetByActive", new
                {
Active = Active
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyGroup GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyGroup>("AgencyGroupGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyGroup> GetByName(string Name){
            try
            {
                return connection.Query<AgencyGroup>("AgencyGroupGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyGroup> GetByTimestamp(DateTime Timestamp){
            try
            {
                return connection.Query<AgencyGroup>("AgencyGroupGetByTimestamp", new
                {
Timestamp = Timestamp
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyGroup> GetTimestampBetween(DateTime TimestampStart,DateTime TimestampEnd){
            try
            {
                return connection.Query<AgencyGroup>("AgencyGroupGetTimestampBetween", new
                {
TimestampStart = TimestampStart
,TimestampEnd = TimestampEnd
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
