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
    public class AgencyMicroSiteSettingsInvoiceRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsInvoiceRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsInvoice AgencyMicroSiteSettingsInvoice)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsInvoice);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsInvoice AgencyMicroSiteSettingsInvoice)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsInvoice);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsInvoice AgencyMicroSiteSettingsInvoice)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsInvoice>(AgencyMicroSiteSettingsInvoice);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByAddress(string Address){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByBankDetails(string BankDetails){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByBankDetails", new
                {
BankDetails = BankDetails
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByBillingDetails(string BillingDetails){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByBillingDetails", new
                {
BillingDetails = BillingDetails
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByCity(string City){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByCity", new
                {
City = City
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByCountry(int Country){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByDirectOperatorToAgencyBilling(bool DirectOperatorToAgencyBilling){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByDirectOperatorToAgencyBilling", new
                {
DirectOperatorToAgencyBilling = DirectOperatorToAgencyBilling
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByEmail(string Email){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsInvoice GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByLegalFooter(string LegalFooter){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByLegalFooter", new
                {
LegalFooter = LegalFooter
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByMailBody(string MailBody){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByMailBody", new
                {
MailBody = MailBody
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByName(string Name){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByNumberPrefix(string NumberPrefix){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByNumberPrefix", new
                {
NumberPrefix = NumberPrefix
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByTaxesByPercentage(decimal TaxesByPercentage){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByTaxesByPercentage", new
                {
TaxesByPercentage = TaxesByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByTaxesDetails(string TaxesDetails){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByTaxesDetails", new
                {
TaxesDetails = TaxesDetails
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsInvoice> GetByVAT(string VAT){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsInvoice>("AgencyMicroSiteSettingsInvoiceGetByVAT", new
                {
VAT = VAT
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
