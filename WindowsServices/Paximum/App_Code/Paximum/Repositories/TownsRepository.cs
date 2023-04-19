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
    public class TownsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public TownsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Towns Towns)
    {
        try
        {
            return connection.Insert(Towns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Towns Towns)
    {
        try
        {
       return  connection.Update(Towns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Towns Towns)
        {
            try
            {
            return  connection.Delete<Towns>(Towns);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Towns> GetAll(){
            try
            {
                return connection.Query<Towns>("TownsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Towns>("TownsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Towns>("TownsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Towns>("TownsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Towns>("TownsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Towns GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Towns>("TownsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Towns>("TownsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByLatitude(decimal Latitude){
            try
            {
                return connection.Query<Towns>("TownsGetByLatitude", new
                {
Latitude = Latitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByLongitude(decimal Longitude){
            try
            {
                return connection.Query<Towns>("TownsGetByLongitude", new
                {
Longitude = Longitude
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Towns>("TownsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByName(string Name){
            try
            {
                return connection.Query<Towns>("TownsGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetByProvider(int Provider){
            try
            {
                return connection.Query<Towns>("TownsGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Towns>("TownsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Towns> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Towns>("TownsGetCreatedDateBetween", new
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
