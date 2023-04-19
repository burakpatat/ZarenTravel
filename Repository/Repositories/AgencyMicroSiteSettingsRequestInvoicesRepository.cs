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
    public class AgencyMicroSiteSettingsRequestInvoicesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsRequestInvoicesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsRequestInvoices AgencyMicroSiteSettingsRequestInvoices)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsRequestInvoices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsRequestInvoices AgencyMicroSiteSettingsRequestInvoices)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsRequestInvoices);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsRequestInvoices AgencyMicroSiteSettingsRequestInvoices)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsRequestInvoices>(AgencyMicroSiteSettingsRequestInvoices);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsRequestInvoices> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsRequestInvoices>("AgencyMicroSiteSettingsRequestInvoicesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsRequestInvoices GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsRequestInvoices>("AgencyMicroSiteSettingsRequestInvoicesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsRequestInvoices> GetByName(string Name){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsRequestInvoices>("AgencyMicroSiteSettingsRequestInvoicesGetByName", new
                {
Name = Name
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
