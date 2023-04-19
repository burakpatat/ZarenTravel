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
    public class OfferCancellationPoliciesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public OfferCancellationPoliciesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(OfferCancellationPolicies OfferCancellationPolicies)
    {
        try
        {
            return connection.Insert(OfferCancellationPolicies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(OfferCancellationPolicies OfferCancellationPolicies)
    {
        try
        {
       return  connection.Update(OfferCancellationPolicies);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(OfferCancellationPolicies OfferCancellationPolicies)
        {
            try
            {
            return  connection.Delete<OfferCancellationPolicies>(OfferCancellationPolicies);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<OfferCancellationPolicies> GetAll(){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetByApiId(int ApiId){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetByCancellationPolicyId(int CancellationPolicyId){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetByCancellationPolicyId", new
                {
CancellationPolicyId = CancellationPolicyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public OfferCancellationPolicies GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<OfferCancellationPolicies>("OfferCancellationPoliciesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetByOfferId(int OfferId){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetByOfferId", new
                {
OfferId = OfferId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferCancellationPolicies> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<OfferCancellationPolicies>("OfferCancellationPoliciesGetCreatedDateBetween", new
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
