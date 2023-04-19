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
    public class AgencyCmsDevicesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyCmsDevicesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyCmsDevices AgencyCmsDevices)
    {
        try
        {
            return connection.Insert(AgencyCmsDevices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyCmsDevices AgencyCmsDevices)
    {
        try
        {
       return  connection.Update(AgencyCmsDevices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyCmsDevices AgencyCmsDevices)
        {
            try
            {
            return  connection.Delete<AgencyCmsDevices>(AgencyCmsDevices);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyCmsDevices> GetAll(){
            try
            {
                return connection.Query<AgencyCmsDevices>("AgencyCmsDevicesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyCmsDevices GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyCmsDevices>("AgencyCmsDevicesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsDevices> GetByName(string Name){
            try
            {
                return connection.Query<AgencyCmsDevices>("AgencyCmsDevicesGetByName", new
                {
Name = Name
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
