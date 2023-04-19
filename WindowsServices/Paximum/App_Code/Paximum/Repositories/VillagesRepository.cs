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
    public class VillagesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public VillagesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Villages Villages)
    {
        try
        {
            return connection.Insert(Villages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Villages Villages)
    {
        try
        {
       return  connection.Update(Villages);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Villages Villages)
        {
            try
            {
            return  connection.Delete<Villages>(Villages);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Villages> GetAll(){
            try
            {
                return connection.Query<Villages>("VillagesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Villages>("VillagesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Villages>("VillagesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Villages>("VillagesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Villages>("VillagesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Villages GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Villages>("VillagesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Villages>("VillagesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Villages>("VillagesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetByName(string Name){
            try
            {
                return connection.Query<Villages>("VillagesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetByProvider(int Provider){
            try
            {
                return connection.Query<Villages>("VillagesGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Villages>("VillagesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Villages> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Villages>("VillagesGetCreatedDateBetween", new
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
