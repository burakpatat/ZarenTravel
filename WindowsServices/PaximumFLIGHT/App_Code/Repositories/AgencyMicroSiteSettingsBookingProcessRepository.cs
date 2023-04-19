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
    public class AgencyMicroSiteSettingsBookingProcessRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsBookingProcessRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsBookingProcess AgencyMicroSiteSettingsBookingProcess)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsBookingProcess);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsBookingProcess AgencyMicroSiteSettingsBookingProcess)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsBookingProcess);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsBookingProcess AgencyMicroSiteSettingsBookingProcess)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsBookingProcess>(AgencyMicroSiteSettingsBookingProcess);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByAllowB2CUserInvoice(int AllowB2CUserInvoice){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByAllowB2CUserInvoice", new
                {
AllowB2CUserInvoice = AllowB2CUserInvoice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByB2BUsersManuelServicesEnable(bool B2BUsersManuelServicesEnable){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByB2BUsersManuelServicesEnable", new
                {
B2BUsersManuelServicesEnable = B2BUsersManuelServicesEnable
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByDefaultReplicatorbookingmodeForB2B(int DefaultReplicatorbookingmodeForB2B){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByDefaultReplicatorbookingmodeForB2B", new
                {
DefaultReplicatorbookingmodeForB2B = DefaultReplicatorbookingmodeForB2B
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByDefaultReplicatorbookingmodeForB2C(int DefaultReplicatorbookingmodeForB2C){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByDefaultReplicatorbookingmodeForB2C", new
                {
DefaultReplicatorbookingmodeForB2C = DefaultReplicatorbookingmodeForB2C
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByEnableCrossSellCrossSelling(bool EnableCrossSellCrossSelling){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellCrossSelling", new
                {
EnableCrossSellCrossSelling = EnableCrossSellCrossSelling
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByEnableCrossSellRentalCars(bool EnableCrossSellRentalCars){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellRentalCars", new
                {
EnableCrossSellRentalCars = EnableCrossSellRentalCars
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByEnableCrossSellTicket(bool EnableCrossSellTicket){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellTicket", new
                {
EnableCrossSellTicket = EnableCrossSellTicket
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByEnableCrossSellTransfers(bool EnableCrossSellTransfers){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellTransfers", new
                {
EnableCrossSellTransfers = EnableCrossSellTransfers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByEnableCrossSellTransports(bool EnableCrossSellTransports){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByEnableCrossSellTransports", new
                {
EnableCrossSellTransports = EnableCrossSellTransports
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByForOnRequestContracts(bool ForOnRequestContracts){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByForOnRequestContracts", new
                {
ForOnRequestContracts = ForOnRequestContracts
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsBookingProcess GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByMaxToleranceAmountId(int MaxToleranceAmountId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByMaxToleranceAmountId", new
                {
MaxToleranceAmountId = MaxToleranceAmountId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByMaxToleranceCurrencyId(int MaxToleranceCurrencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByMaxToleranceCurrencyId", new
                {
MaxToleranceCurrencyId = MaxToleranceCurrencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByMaxTolerancePrice(decimal MaxTolerancePrice){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByMaxTolerancePrice", new
                {
MaxTolerancePrice = MaxTolerancePrice
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByNotifyChangesRequotingSavedIdea(bool NotifyChangesRequotingSavedIdea){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByNotifyChangesRequotingSavedIdea", new
                {
NotifyChangesRequotingSavedIdea = NotifyChangesRequotingSavedIdea
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByPaymentOption(int PaymentOption){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByPaymentOption", new
                {
PaymentOption = PaymentOption
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByRequireAgencyBookingProcess(bool RequireAgencyBookingProcess){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByRequireAgencyBookingProcess", new
                {
RequireAgencyBookingProcess = RequireAgencyBookingProcess
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetBySelectAppearDigitalBrochuresForB2BUsers(int SelectAppearDigitalBrochuresForB2BUsers){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetBySelectAppearDigitalBrochuresForB2BUsers", new
                {
SelectAppearDigitalBrochuresForB2BUsers = SelectAppearDigitalBrochuresForB2BUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetBySelectAppearDigitalBrochuresForB2CUsers(int SelectAppearDigitalBrochuresForB2CUsers){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetBySelectAppearDigitalBrochuresForB2CUsers", new
                {
SelectAppearDigitalBrochuresForB2CUsers = SelectAppearDigitalBrochuresForB2CUsers
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetBySetFlightTaxesAsNonCommissionAble(bool SetFlightTaxesAsNonCommissionAble){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetBySetFlightTaxesAsNonCommissionAble", new
                {
SetFlightTaxesAsNonCommissionAble = SetFlightTaxesAsNonCommissionAble
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsBookingProcess> GetByShowFareBreakdownOnTransports(bool ShowFareBreakdownOnTransports){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsBookingProcess>("AgencyMicroSiteSettingsBookingProcessGetByShowFareBreakdownOnTransports", new
                {
ShowFareBreakdownOnTransports = ShowFareBreakdownOnTransports
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
