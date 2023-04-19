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
    public class OffersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public OffersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Offers Offers)
    {
        try
        {
            return connection.Insert(Offers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Offers Offers)
    {
        try
        {
       return  connection.Update(Offers);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Offers Offers)
        {
            try
            {
            return  connection.Delete<Offers>(Offers);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Offers> GetAll(){
            try
            {
                return connection.Query<Offers>("OffersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByAgencyCommissionId(int AgencyCommissionId){
            try
            {
                return connection.Query<Offers>("OffersGetByAgencyCommissionId", new
                {
AgencyCommissionId = AgencyCommissionId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Offers>("OffersGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByAgencySupplementCommissionId(int AgencySupplementCommissionId){
            try
            {
                return connection.Query<Offers>("OffersGetByAgencySupplementCommissionId", new
                {
AgencySupplementCommissionId = AgencySupplementCommissionId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Offers>("OffersGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByAvailability(int Availability){
            try
            {
                return connection.Query<Offers>("OffersGetByAvailability", new
                {
Availability = Availability
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByCheckIn(DateTime CheckIn){
            try
            {
                return connection.Query<Offers>("OffersGetByCheckIn", new
                {
CheckIn = CheckIn
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByCheckOut(DateTime CheckOut){
            try
            {
                return connection.Query<Offers>("OffersGetByCheckOut", new
                {
CheckOut = CheckOut
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Offers>("OffersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Offers>("OffersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByExpresOn(DateTime ExpresOn){
            try
            {
                return connection.Query<Offers>("OffersGetByExpresOn", new
                {
ExpresOn = ExpresOn
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Offers GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Offers>("OffersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByIsAvailable(bool IsAvailable){
            try
            {
                return connection.Query<Offers>("OffersGetByIsAvailable", new
                {
IsAvailable = IsAvailable
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByIsRefundable(bool IsRefundable){
            try
            {
                return connection.Query<Offers>("OffersGetByIsRefundable", new
                {
IsRefundable = IsRefundable
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByIsSpecial(bool IsSpecial){
            try
            {
                return connection.Query<Offers>("OffersGetByIsSpecial", new
                {
IsSpecial = IsSpecial
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Offers>("OffersGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Offers>("OffersGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByNight(int Night){
            try
            {
                return connection.Query<Offers>("OffersGetByNight", new
                {
Night = Night
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByOfferCancellationPolicyId(int OfferCancellationPolicyId){
            try
            {
                return connection.Query<Offers>("OffersGetByOfferCancellationPolicyId", new
                {
OfferCancellationPolicyId = OfferCancellationPolicyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByOfferId(string OfferId){
            try
            {
                return connection.Query<Offers>("OffersGetByOfferId", new
                {
OfferId = OfferId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    public List<Offers> GetByOfferIdandSystemId(string OfferId, int SystemId)
    {
        try
        {
            return connection.Query<Offers>("OffersGetByOfferIdandSystemId", new
            {
                OfferId = OfferId,
                SystemId = SystemId
            }, commandType: CommandType.StoredProcedure).ToList();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public List<Offers> GetByOfferPriceBreakDownId(int OfferPriceBreakDownId){
            try
            {
                return connection.Query<Offers>("OffersGetByOfferPriceBreakDownId", new
                {
OfferPriceBreakDownId = OfferPriceBreakDownId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByOfferRoomsId(int OfferRoomsId){
            try
            {
                return connection.Query<Offers>("OffersGetByOfferRoomsId", new
                {
OfferRoomsId = OfferRoomsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByOwnOffer(bool OwnOffer){
            try
            {
                return connection.Query<Offers>("OffersGetByOwnOffer", new
                {
OwnOffer = OwnOffer
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByPriceId(int PriceId){
            try
            {
                return connection.Query<Offers>("OffersGetByPriceId", new
                {
PriceId = PriceId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetByProvider(int Provider){
            try
            {
                return connection.Query<Offers>("OffersGetByProvider", new
                {
Provider = Provider
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Offers>("OffersGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetCheckInBetween(DateTime CheckInStart,DateTime CheckInEnd){
            try
            {
                return connection.Query<Offers>("OffersGetCheckInBetween", new
                {
CheckInStart = CheckInStart
,CheckInEnd = CheckInEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetCheckOutBetween(DateTime CheckOutStart,DateTime CheckOutEnd){
            try
            {
                return connection.Query<Offers>("OffersGetCheckOutBetween", new
                {
CheckOutStart = CheckOutStart
,CheckOutEnd = CheckOutEnd
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Offers> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Offers>("OffersGetCreatedDateBetween", new
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
public List<Offers> GetExpresOnBetween(DateTime ExpresOnStart,DateTime ExpresOnEnd){
            try
            {
                return connection.Query<Offers>("OffersGetExpresOnBetween", new
                {
ExpresOnStart = ExpresOnStart
,ExpresOnEnd = ExpresOnEnd
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
