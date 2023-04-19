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
    public class AirPortsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AirPortsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AirPorts AirPorts)
    {
        try
        {
            return connection.Insert(AirPorts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AirPorts AirPorts)
    {
        try
        {
       return  connection.Update(AirPorts);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AirPorts AirPorts)
        {
            try
            {
            return  connection.Delete<AirPorts>(AirPorts);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AirPorts> GetAll(){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetByApiId(int ApiId){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetByCode(string Code){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetByCode", new
                {
Code = Code
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetByGeoLocationId(int GeoLocationId){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetByGeoLocationId", new
                {
GeoLocationId = GeoLocationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AirPorts GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AirPorts>("AirPortsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetByName(string Name){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AirPorts> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AirPorts>("AirPortsGetCreatedDateBetween", new
                {
CreatedDateStart = CreatedDateStart
,CreatedDateEnd = CreatedDateEnd
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
