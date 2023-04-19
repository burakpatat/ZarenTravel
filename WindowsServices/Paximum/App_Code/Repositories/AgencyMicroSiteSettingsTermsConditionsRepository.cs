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
    public class AgencyMicroSiteSettingsTermsConditionsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSiteSettingsTermsConditionsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteSettingsTermsConditions AgencyMicroSiteSettingsTermsConditions)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteSettingsTermsConditions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteSettingsTermsConditions AgencyMicroSiteSettingsTermsConditions)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteSettingsTermsConditions);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteSettingsTermsConditions AgencyMicroSiteSettingsTermsConditions)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteSettingsTermsConditions>(AgencyMicroSiteSettingsTermsConditions);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteSettingsTermsConditions> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsTermsConditions>("AgencyMicroSiteSettingsTermsConditionsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsTermsConditions> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsTermsConditions>("AgencyMicroSiteSettingsTermsConditionsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsTermsConditions> GetByGDPRCheckBoxes(bool GDPRCheckBoxes){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsTermsConditions>("AgencyMicroSiteSettingsTermsConditionsGetByGDPRCheckBoxes", new
                {
GDPRCheckBoxes = GDPRCheckBoxes
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteSettingsTermsConditions GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteSettingsTermsConditions>("AgencyMicroSiteSettingsTermsConditionsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsTermsConditions> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsTermsConditions>("AgencyMicroSiteSettingsTermsConditionsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsTermsConditions> GetByPackageTerms(bool PackageTerms){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsTermsConditions>("AgencyMicroSiteSettingsTermsConditionsGetByPackageTerms", new
                {
PackageTerms = PackageTerms
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteSettingsTermsConditions> GetByVisaTerms(bool VisaTerms){
            try
            {
                return connection.Query<AgencyMicroSiteSettingsTermsConditions>("AgencyMicroSiteSettingsTermsConditionsGetByVisaTerms", new
                {
VisaTerms = VisaTerms
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
