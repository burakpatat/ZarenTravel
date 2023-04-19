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
    public class AgencyMicroSiteSettingsOtherRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsOtherRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsOther AgencyMicroSiteSettingsOther)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsOther);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsOther AgencyMicroSiteSettingsOther)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsOther);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsOther AgencyMicroSiteSettingsOther)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsOther>(AgencyMicroSiteSettingsOther);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByAskForIdAndBirthdate(bool AskForIdAndBirthdate){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByAskForIdAndBirthdate", new
                {
AskForIdAndBirthdate = AskForIdAndBirthdate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsOther GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByIdeaBrochureIndexing(bool IdeaBrochureIndexing){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByIdeaBrochureIndexing", new
                {
IdeaBrochureIndexing = IdeaBrochureIndexing
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByPendingPaymentAutoCancellation(bool PendingPaymentAutoCancellation){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByPendingPaymentAutoCancellation", new
                {
PendingPaymentAutoCancellation = PendingPaymentAutoCancellation
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByShowAgencyIdInDropdownInsteadOfAgencyName(bool ShowAgencyIdInDropdownInsteadOfAgencyName){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByShowAgencyIdInDropdownInsteadOfAgencyName", new
                {
ShowAgencyIdInDropdownInsteadOfAgencyName = ShowAgencyIdInDropdownInsteadOfAgencyName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByShowImagePaymentMethodInFooter(bool ShowImagePaymentMethodInFooter){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByShowImagePaymentMethodInFooter", new
                {
ShowImagePaymentMethodInFooter = ShowImagePaymentMethodInFooter
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByShowTotalPriceInBrochure(bool ShowTotalPriceInBrochure){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByShowTotalPriceInBrochure", new
                {
ShowTotalPriceInBrochure = ShowTotalPriceInBrochure
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByShowWhatsAppGetButton(bool ShowWhatsAppGetButton){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByShowWhatsAppGetButton", new
                {
ShowWhatsAppGetButton = ShowWhatsAppGetButton
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsOther> GetByWhatsAppNumber(string WhatsAppNumber){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsOther>("AgencyMicroSiteSettingsOtherGetByWhatsAppNumber", new
                {
WhatsAppNumber = WhatsAppNumber
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
