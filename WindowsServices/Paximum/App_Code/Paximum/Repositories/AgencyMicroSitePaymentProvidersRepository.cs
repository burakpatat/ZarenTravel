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
    public class AgencyMicroSitePaymentProvidersRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSitePaymentProvidersRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSitePaymentProviders AgencyMicroSitePaymentProviders)
    {
        try
        {
            return connection.Insert(AgencyMicroSitePaymentProviders);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSitePaymentProviders AgencyMicroSitePaymentProviders)
    {
        try
        {
       return  connection.Update(AgencyMicroSitePaymentProviders);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSitePaymentProviders AgencyMicroSitePaymentProviders)
        {
            try
            {
            return  connection.Delete<AgencyMicroSitePaymentProviders>(AgencyMicroSitePaymentProviders);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSitePaymentProviders> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitePaymentProviders> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitePaymentProviders> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitePaymentProviders> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSitePaymentProviders GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitePaymentProviders> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitePaymentProviders> GetByPaymentTypeId(int PaymentTypeId){
            try
            {
                return connection.Query<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetByPaymentTypeId", new
                {
PaymentTypeId = PaymentTypeId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitePaymentProviders> GetByStatu(int Statu){
            try
            {
                return connection.Query<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetByStatu", new
                {
Statu = Statu
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSitePaymentProviders> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<AgencyMicroSitePaymentProviders>("AgencyMicroSitePaymentProvidersGetCreatedDateBetween", new
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
