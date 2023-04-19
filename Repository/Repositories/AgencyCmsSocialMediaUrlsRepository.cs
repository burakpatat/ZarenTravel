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
    public class AgencyCmsSocialMediaUrlsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyCmsSocialMediaUrlsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyCmsSocialMediaUrls AgencyCmsSocialMediaUrls)
    {
        try
        {
            return connection.Insert(AgencyCmsSocialMediaUrls);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyCmsSocialMediaUrls AgencyCmsSocialMediaUrls)
    {
        try
        {
       return  connection.Update(AgencyCmsSocialMediaUrls);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyCmsSocialMediaUrls AgencyCmsSocialMediaUrls)
        {
            try
            {
            return  connection.Delete<AgencyCmsSocialMediaUrls>(AgencyCmsSocialMediaUrls);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetAll(){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByFacebookUrl(string FacebookUrl){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByFacebookUrl", new
                {
FacebookUrl = FacebookUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByHomeUrl(string HomeUrl){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByHomeUrl", new
                {
HomeUrl = HomeUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyCmsSocialMediaUrls GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByInstagramUrl(string InstagramUrl){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByInstagramUrl", new
                {
InstagramUrl = InstagramUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByLinkedInUrl(string LinkedInUrl){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByLinkedInUrl", new
                {
LinkedInUrl = LinkedInUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByPinterestUrl(string PinterestUrl){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByPinterestUrl", new
                {
PinterestUrl = PinterestUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByTwitterUrl(string TwitterUrl){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByTwitterUrl", new
                {
TwitterUrl = TwitterUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByViemoUrl(string ViemoUrl){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByViemoUrl", new
                {
ViemoUrl = ViemoUrl
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsSocialMediaUrls> GetByYoutubeUrl(string YoutubeUrl){
            try
            {
                return connection.Query<AgencyCmsSocialMediaUrls>("AgencyCmsSocialMediaUrlsGetByYoutubeUrl", new
                {
YoutubeUrl = YoutubeUrl
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
