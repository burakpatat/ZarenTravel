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
    public class AgencyMicroSiteDomainsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteDomainsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteDomains AgencyMicroSiteDomains)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteDomains);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteDomains AgencyMicroSiteDomains)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteDomains);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteDomains AgencyMicroSiteDomains)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteDomains>(AgencyMicroSiteDomains);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteDomains> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByAdwordsId(string AdwordsId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByAdwordsId", new
                {
AdwordsId = AdwordsId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByAdwordsLabel(string AdwordsLabel){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByAdwordsLabel", new
                {
AdwordsLabel = AdwordsLabel
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByBingAds(string BingAds){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByBingAds", new
                {
BingAds = BingAds
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByDefaultLanguageId(int DefaultLanguageId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByDefaultLanguageId", new
                {
DefaultLanguageId = DefaultLanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByDomainHostIP(string DomainHostIP){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByDomainHostIP", new
                {
DomainHostIP = DomainHostIP
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByDomainUrl(string DomainUrl){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByDomainUrl", new
                {
DomainUrl = DomainUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByFacebookDomainVerification(string FacebookDomainVerification){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByFacebookDomainVerification", new
                {
FacebookDomainVerification = FacebookDomainVerification
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByFacebookPixelId(string FacebookPixelId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByFacebookPixelId", new
                {
FacebookPixelId = FacebookPixelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByGoogleSiteVerification(string GoogleSiteVerification){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByGoogleSiteVerification", new
                {
GoogleSiteVerification = GoogleSiteVerification
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByGoogleTagManagerId(string GoogleTagManagerId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByGoogleTagManagerId", new
                {
GoogleTagManagerId = GoogleTagManagerId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByGtagId(string GtagId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByGtagId", new
                {
GtagId = GtagId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteDomains GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByKayakPartnerCode(string KayakPartnerCode){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByKayakPartnerCode", new
                {
KayakPartnerCode = KayakPartnerCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetBySiteMapJson(string SiteMapJson){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetBySiteMapJson", new
                {
SiteMapJson = SiteMapJson
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByTradeTrackerClientId(string TradeTrackerClientId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByTradeTrackerClientId", new
                {
TradeTrackerClientId = TradeTrackerClientId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByTradeTrackerPidOthers(string TradeTrackerPidOthers){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByTradeTrackerPidOthers", new
                {
TradeTrackerPidOthers = TradeTrackerPidOthers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByTradeTrackerProductOnlyAccommodation(string TradeTrackerProductOnlyAccommodation){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByTradeTrackerProductOnlyAccommodation", new
                {
TradeTrackerProductOnlyAccommodation = TradeTrackerProductOnlyAccommodation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteDomains> GetByVePixelId(string VePixelId){
            try
            {
                return connection.Query<AgencyMicroSiteDomains>("AgencyMicroSiteDomainsGetByVePixelId", new
                {
VePixelId = VePixelId
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
