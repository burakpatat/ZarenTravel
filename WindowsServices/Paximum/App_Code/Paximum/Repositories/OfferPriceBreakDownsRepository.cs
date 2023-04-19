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
    public class OfferPriceBreakDownsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public OfferPriceBreakDownsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(OfferPriceBreakDowns OfferPriceBreakDowns)
    {
        try
        {
            return connection.Insert(OfferPriceBreakDowns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(OfferPriceBreakDowns OfferPriceBreakDowns)
    {
        try
        {
       return  connection.Update(OfferPriceBreakDowns);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(OfferPriceBreakDowns OfferPriceBreakDowns)
        {
            try
            {
            return  connection.Delete<OfferPriceBreakDowns>(OfferPriceBreakDowns);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<OfferPriceBreakDowns> GetAll(){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetByApiId(int ApiId){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public OfferPriceBreakDowns GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetByOfferId(int OfferId){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByOfferId", new
                {
OfferId = OfferId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetByPriceBreakDownId(int PriceBreakDownId){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetByPriceBreakDownId", new
                {
PriceBreakDownId = PriceBreakDownId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<OfferPriceBreakDowns> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<OfferPriceBreakDowns>("OfferPriceBreakDownsGetCreatedDateBetween", new
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
