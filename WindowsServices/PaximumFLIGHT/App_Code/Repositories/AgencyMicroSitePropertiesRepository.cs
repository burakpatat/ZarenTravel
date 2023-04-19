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
    public class AgencyMicroSitePropertiesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyMicroSitePropertiesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyMicroSiteProperties AgencyMicroSiteProperties)
    {
        try
        {
            return connection.Insert(AgencyMicroSiteProperties);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyMicroSiteProperties AgencyMicroSiteProperties)
    {
        try
        {
       return  connection.Update(AgencyMicroSiteProperties);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyMicroSiteProperties AgencyMicroSiteProperties)
        {
            try
            {
            return  connection.Delete<AgencyMicroSiteProperties>(AgencyMicroSiteProperties);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyMicroSiteProperties> GetAll(){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByAgencyMicroSiteId(int AgencyMicroSiteId){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByAgencyMicroSiteId", new
                {
AgencyMicroSiteId = AgencyMicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByDefaultLogo(string DefaultLogo){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByDefaultLogo", new
                {
DefaultLogo = DefaultLogo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByFavicon(string Favicon){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByFavicon", new
                {
Favicon = Favicon
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByHasLogoOnHeader(bool HasLogoOnHeader){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByHasLogoOnHeader", new
                {
HasLogoOnHeader = HasLogoOnHeader
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyMicroSiteProperties GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByMetaDescription(string MetaDescription){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByMetaDescription", new
                {
MetaDescription = MetaDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByMetaTitle(string MetaTitle){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByMetaTitle", new
                {
MetaTitle = MetaTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByMobileLogo(string MobileLogo){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByMobileLogo", new
                {
MobileLogo = MobileLogo
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByOgDescription(string OgDescription){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByOgDescription", new
                {
OgDescription = OgDescription
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByOgImage(string OgImage){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByOgImage", new
                {
OgImage = OgImage
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByOgTitle(string OgTitle){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByOgTitle", new
                {
OgTitle = OgTitle
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyMicroSiteProperties> GetByWhiteLogo(string WhiteLogo){
            try
            {
                return connection.Query<AgencyMicroSiteProperties>("AgencyMicroSitePropertiesGetByWhiteLogo", new
                {
WhiteLogo = WhiteLogo
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
