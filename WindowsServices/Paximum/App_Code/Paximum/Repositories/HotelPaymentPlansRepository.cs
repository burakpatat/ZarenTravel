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
    public class HotelPaymentPlansRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelPaymentPlansRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelPaymentPlans HotelPaymentPlans)
    {
        try
        {
            return connection.Insert(HotelPaymentPlans);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelPaymentPlans HotelPaymentPlans)
    {
        try
        {
       return  connection.Update(HotelPaymentPlans);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelPaymentPlans HotelPaymentPlans)
        {
            try
            {
            return  connection.Delete<HotelPaymentPlans>(HotelPaymentPlans);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelPaymentPlans> GetAll(){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelPaymentPlans GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelPaymentPlans>("HotelPaymentPlansGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetByPaymentPlanInfoId(int PaymentPlanInfoId){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetByPaymentPlanInfoId", new
                {
PaymentPlanInfoId = PaymentPlanInfoId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelPaymentPlans> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelPaymentPlans>("HotelPaymentPlansGetCreatedDateBetween", new
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
