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
    public class CancellationPoliciesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public CancellationPoliciesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(CancellationPolicies CancellationPolicies)
    {
        try
        {
            return connection.Insert(CancellationPolicies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(CancellationPolicies CancellationPolicies)
    {
        try
        {
       return  connection.Update(CancellationPolicies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(CancellationPolicies CancellationPolicies)
        {
            try
            {
            return  connection.Delete<CancellationPolicies>(CancellationPolicies);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<CancellationPolicies> GetAll(){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByApiId(int ApiId){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByDueDate(DateTime DueDate){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByDueDate", new
                {
DueDate = DueDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public CancellationPolicies GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<CancellationPolicies>("CancellationPoliciesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByPriceId(int PriceId){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByPriceId", new
                {
PriceId = PriceId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetByProvider(int Provider){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<CancellationPolicies> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetCreatedDateBetween", new
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
public List<CancellationPolicies> GetDueDateBetween(DateTime DueDateStart,DateTime DueDateEnd){
            try
            {
                return connection.Query<CancellationPolicies>("CancellationPoliciesGetDueDateBetween", new
                {
DueDateStart = DueDateStart
,DueDateEnd = DueDateEnd
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
