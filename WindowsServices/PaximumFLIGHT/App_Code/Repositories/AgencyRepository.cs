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
    public class AgencyRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Agency Agency)
    {
        try
        {
            return connection.Insert(Agency);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Agency Agency)
    {
        try
        {
       return  connection.Update(Agency);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Agency Agency)
        {
            try
            {
            return  connection.Delete<Agency>(Agency);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Agency> GetAll(){
            try
            {
                return connection.Query<Agency>("AgencyGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByAddress(string Address){
            try
            {
                return connection.Query<Agency>("AgencyGetByAddress", new
                {
Address = Address
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByManager(int AgencyManager){
            try
            {
                return connection.Query<Agency>("AgencyGetByAgencyManager", new
                {
AgencyManager = AgencyManager
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByBillingEmails(string BillingEmails){
            try
            {
                return connection.Query<Agency>("AgencyGetByBillingEmails", new
                {
BillingEmails = BillingEmails
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByBusinessName(string BusinessName){
            try
            {
                return connection.Query<Agency>("AgencyGetByBusinessName", new
                {
BusinessName = BusinessName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByCity(string City){
            try
            {
                return connection.Query<Agency>("AgencyGetByCity", new
                {
City = City
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByContactPersonLastName(string ContactPersonLastName){
            try
            {
                return connection.Query<Agency>("AgencyGetByContactPersonLastName", new
                {
ContactPersonLastName = ContactPersonLastName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByContactPersonName(string ContactPersonName){
            try
            {
                return connection.Query<Agency>("AgencyGetByContactPersonName", new
                {
ContactPersonName = ContactPersonName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByCountry(int Country){
            try
            {
                return connection.Query<Agency>("AgencyGetByCountry", new
                {
Country = Country
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDeferredPaymentAllowed(bool DeferredPaymentAllowed){
            try
            {
                return connection.Query<Agency>("AgencyGetByDeferredPaymentAllowed", new
                {
DeferredPaymentAllowed = DeferredPaymentAllowed
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDeferredPaymentDays(int DeferredPaymentDays){
            try
            {
                return connection.Query<Agency>("AgencyGetByDeferredPaymentDays", new
                {
DeferredPaymentDays = DeferredPaymentDays
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDeferredPaymentLimit(decimal DeferredPaymentLimit){
            try
            {
                return connection.Query<Agency>("AgencyGetByDeferredPaymentLimit", new
                {
DeferredPaymentLimit = DeferredPaymentLimit
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDeferredPaymentLimitCurrency(int DeferredPaymentLimitCurrency){
            try
            {
                return connection.Query<Agency>("AgencyGetByDeferredPaymentLimitCurrency", new
                {
DeferredPaymentLimitCurrency = DeferredPaymentLimitCurrency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByDocumentNumber(string DocumentNumber){
            try
            {
                return connection.Query<Agency>("AgencyGetByDocumentNumber", new
                {
DocumentNumber = DocumentNumber
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByEmail(string Email){
            try
            {
                return connection.Query<Agency>("AgencyGetByEmail", new
                {
Email = Email
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByExternalId(int ExternalId){
            try
            {
                return connection.Query<Agency>("AgencyGetByExternalId", new
                {
ExternalId = ExternalId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByGDSIdentifierForGalileo(string GDSIdentifierForGalileo){
            try
            {
                return connection.Query<Agency>("AgencyGetByGDSIdentifierForGalileo", new
                {
GDSIdentifierForGalileo = GDSIdentifierForGalileo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByHasCreditOrDepositPaymentAllowed(bool HasCreditOrDepositPaymentAllowed){
            try
            {
                return connection.Query<Agency>("AgencyGetByHasCreditOrDepositPaymentAllowed", new
                {
HasCreditOrDepositPaymentAllowed = HasCreditOrDepositPaymentAllowed
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Agency GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Agency>("AgencyGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByInvoiceName(string InvoiceName){
            try
            {
                return connection.Query<Agency>("AgencyGetByInvoiceName", new
                {
InvoiceName = InvoiceName
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByInvoiceTypeId(int InvoiceTypeId){
            try
            {
                return connection.Query<Agency>("AgencyGetByInvoiceTypeId", new
                {
InvoiceTypeId = InvoiceTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByManagementGroup(string ManagementGroup){
            try
            {
                return connection.Query<Agency>("AgencyGetByManagementGroup", new
                {
ManagementGroup = ManagementGroup
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByMinimumFirstPaymentAmount(int MinimumFirstPaymentAmount){
            try
            {
                return connection.Query<Agency>("AgencyGetByMinimumFirstPaymentAmount", new
                {
MinimumFirstPaymentAmount = MinimumFirstPaymentAmount
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByMinimumFirstPaymentIsByPercentage(bool MinimumFirstPaymentIsByPercentage){
            try
            {
                return connection.Query<Agency>("AgencyGetByMinimumFirstPaymentIsByPercentage", new
                {
MinimumFirstPaymentIsByPercentage = MinimumFirstPaymentIsByPercentage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByPhoneNo(string PhoneNo){
            try
            {
                return connection.Query<Agency>("AgencyGetByPhoneNo", new
                {
PhoneNo = PhoneNo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByPostalCode(string PostalCode){
            try
            {
                return connection.Query<Agency>("AgencyGetByPostalCode", new
                {
PostalCode = PostalCode
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByProvience(string Provience){
            try
            {
                return connection.Query<Agency>("AgencyGetByProvience", new
                {
Provience = Provience
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByRegion(string Region){
            try
            {
                return connection.Query<Agency>("AgencyGetByRegion", new
                {
Region = Region
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByRemarks(string Remarks){
            try
            {
                return connection.Query<Agency>("AgencyGetByRemarks", new
                {
Remarks = Remarks
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByStatu(int Statu){
            try
            {
                return connection.Query<Agency>("AgencyGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetBySummerHours(string SummerHours){
            try
            {
                return connection.Query<Agency>("AgencyGetBySummerHours", new
                {
SummerHours = SummerHours
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByTaxes(double Taxes){
            try
            {
                return connection.Query<Agency>("AgencyGetByTaxes", new
                {
Taxes = Taxes
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByWhatsAppNo(string WhatsAppNo){
            try
            {
                return connection.Query<Agency>("AgencyGetByWhatsAppNo", new
                {
WhatsAppNo = WhatsAppNo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Agency> GetByWinterHours(string WinterHours){
            try
            {
                return connection.Query<Agency>("AgencyGetByWinterHours", new
                {
WinterHours = WinterHours
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
