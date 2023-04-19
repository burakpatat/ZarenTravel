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
    public class AgencyMicroSiteSettingsEmailVoucherRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsEmailVoucherRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsEmailVoucher AgencyMicroSiteSettingsEmailVoucher)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsEmailVoucher);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsEmailVoucher AgencyMicroSiteSettingsEmailVoucher)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsEmailVoucher);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsEmailVoucher AgencyMicroSiteSettingsEmailVoucher)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsEmailVoucher>(AgencyMicroSiteSettingsEmailVoucher);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetByAvoidSendBookingMailToOperator(bool AvoidSendBookingMailToOperator){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetByAvoidSendBookingMailToOperator", new
                {
AvoidSendBookingMailToOperator = AvoidSendBookingMailToOperator
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetByExcludePricesBookingsOnlinePDFVoucher(bool ExcludePricesBookingsOnlinePDFVoucher){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetByExcludePricesBookingsOnlinePDFVoucher", new
                {
ExcludePricesBookingsOnlinePDFVoucher = ExcludePricesBookingsOnlinePDFVoucher
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetByFromEmailAgency(bool FromEmailAgency){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetByFromEmailAgency", new
                {
FromEmailAgency = FromEmailAgency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetByHideCoverPageAndDayByDayPdf(bool HideCoverPageAndDayByDayPdf){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetByHideCoverPageAndDayByDayPdf", new
                {
HideCoverPageAndDayByDayPdf = HideCoverPageAndDayByDayPdf
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsEmailVoucher GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetByPrintPDFVoucherOneService(bool PrintPDFVoucherOneService){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetByPrintPDFVoucherOneService", new
                {
PrintPDFVoucherOneService = PrintPDFVoucherOneService
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetBySendBookingEmailFromAgency(bool SendBookingEmailFromAgency){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetBySendBookingEmailFromAgency", new
                {
SendBookingEmailFromAgency = SendBookingEmailFromAgency
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsEmailVoucher> GetBySendMoAppEmailReminder(bool SendMoAppEmailReminder){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsEmailVoucher>("AgencyMicroSiteSettingsEmailVoucherGetBySendMoAppEmailReminder", new
                {
SendMoAppEmailReminder = SendMoAppEmailReminder
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
