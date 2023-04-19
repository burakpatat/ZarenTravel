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
    public class AgencyContractsInsuranceBasicDataRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyContractsInsuranceBasicDataRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyContractsInsuranceBasicData AgencyContractsInsuranceBasicData)
    {
        try
        {
            return connection.Insert(AgencyContractsInsuranceBasicData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyContractsInsuranceBasicData AgencyContractsInsuranceBasicData)
    {
        try
        {
       return  connection.Update(AgencyContractsInsuranceBasicData);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyContractsInsuranceBasicData AgencyContractsInsuranceBasicData)
        {
            try
            {
            return  connection.Delete<AgencyContractsInsuranceBasicData>(AgencyContractsInsuranceBasicData);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetAll(){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByCreateBy(int CreateBy){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByCreateBy", new
                {
CreateBy = CreateBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByCreateDate(DateTime CreateDate){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByCreateDate", new
                {
CreateDate = CreateDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyContractsInsuranceBasicData GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByImagePath(string ImagePath){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByImagePath", new
                {
ImagePath = ImagePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByImageUrl(string ImageUrl){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByImageUrl", new
                {
ImageUrl = ImageUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByInsuranceSelectedProductTypeId(int InsuranceSelectedProductTypeId){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByInsuranceSelectedProductTypeId", new
                {
InsuranceSelectedProductTypeId = InsuranceSelectedProductTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByInsuranceTypeId(int InsuranceTypeId){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByInsuranceTypeId", new
                {
InsuranceTypeId = InsuranceTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByIsActive(bool IsActive){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByIsActive", new
                {
IsActive = IsActive
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByPolicyName(string PolicyName){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByPolicyName", new
                {
PolicyName = PolicyName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByPolicyNumber(string PolicyNumber){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByPolicyNumber", new
                {
PolicyNumber = PolicyNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetBySelectByDefault(bool SelectByDefault){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetBySelectByDefault", new
                {
SelectByDefault = SelectByDefault
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetBySelectedInsuranceLanguageId(int SelectedInsuranceLanguageId){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetBySelectedInsuranceLanguageId", new
                {
SelectedInsuranceLanguageId = SelectedInsuranceLanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetByServiceProviderId(int ServiceProviderId){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetByServiceProviderId", new
                {
ServiceProviderId = ServiceProviderId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetBySupplierId(int SupplierId){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetBySupplierId", new
                {
SupplierId = SupplierId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyContractsInsuranceBasicData> GetCreateDateBetween(DateTime CreateDateStart,DateTime CreateDateEnd){
            try
            {
                return connection.Query<AgencyContractsInsuranceBasicData>("AgencyContractsInsuranceBasicDataGetCreateDateBetween", new
                {
CreateDateStart = CreateDateStart
,CreateDateEnd = CreateDateEnd
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
