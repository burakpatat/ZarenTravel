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
    public class AgencyMicroSiteApiProductProvidersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteApiProductProvidersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteApiProductProviders AgencyMicroSiteApiProductProviders)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteApiProductProviders);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteApiProductProviders AgencyMicroSiteApiProductProviders)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteApiProductProviders);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteApiProductProviders AgencyMicroSiteApiProductProviders)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteApiProductProviders>(AgencyMicroSiteApiProductProviders);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetByApiId(int ApiId){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetByApiProductId(int ApiProductId){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByApiProductId", new
                {
ApiProductId = ApiProductId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetByHasConsolidate(bool HasConsolidate){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByHasConsolidate", new
                {
HasConsolidate = HasConsolidate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteApiProductProviders GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetByPriority(int Priority){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetByPriority", new
                {
Priority = Priority
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteApiProductProviders> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AgencyMicroSiteApiProductProviders>("AgencyMicroSiteApiProductProvidersGetCreatedDateBetween", new
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
