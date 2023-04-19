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
    public class PaymentPlanInfosRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PaymentPlanInfosRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(PaymentPlanInfos PaymentPlanInfos)
    {
        try
        {
            return connection.Insert(PaymentPlanInfos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(PaymentPlanInfos PaymentPlanInfos)
    {
        try
        {
       return  connection.Update(PaymentPlanInfos);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(PaymentPlanInfos PaymentPlanInfos)
        {
            try
            {
            return  connection.Delete<PaymentPlanInfos>(PaymentPlanInfos);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<PaymentPlanInfos> GetAll(){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByApiId(int ApiId){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByDay(int Day){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByDay", new
                {
Day = Day
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public PaymentPlanInfos GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<PaymentPlanInfos>("PaymentPlanInfosGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByPaymentTimeStatus(int PaymentTimeStatus){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByPaymentTimeStatus", new
                {
PaymentTimeStatus = PaymentTimeStatus
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByPhase(int Phase){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByPhase", new
                {
Phase = Phase
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetByPriceId(int PriceId){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetByPriceId", new
                {
PriceId = PriceId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<PaymentPlanInfos> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<PaymentPlanInfos>("PaymentPlanInfosGetCreatedDateBetween", new
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
