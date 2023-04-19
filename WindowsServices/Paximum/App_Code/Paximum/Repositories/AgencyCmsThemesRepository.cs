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
    public class AgencyCmsThemesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public AgencyCmsThemesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(AgencyCmsThemes AgencyCmsThemes)
    {
        try
        {
            return connection.Insert(AgencyCmsThemes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(AgencyCmsThemes AgencyCmsThemes)
    {
        try
        {
       return  connection.Update(AgencyCmsThemes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(AgencyCmsThemes AgencyCmsThemes)
        {
            try
            {
            return  connection.Delete<AgencyCmsThemes>(AgencyCmsThemes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<AgencyCmsThemes> GetAll(){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsThemes> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsThemes> GetByIcon(string Icon){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetByIcon", new
                {
Icon = Icon
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public AgencyCmsThemes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<AgencyCmsThemes>("AgencyCmsThemesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsThemes> GetByImageLink(string ImageLink){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetByImageLink", new
                {
ImageLink = ImageLink
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsThemes> GetByImagePath(string ImagePath){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetByImagePath", new
                {
ImagePath = ImagePath
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsThemes> GetByIsMainTheme(bool IsMainTheme){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetByIsMainTheme", new
                {
IsMainTheme = IsMainTheme
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsThemes> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsThemes> GetByName(string Name){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<AgencyCmsThemes> GetByOrders(int Orders){
            try
            {
                return connection.Query<AgencyCmsThemes>("AgencyCmsThemesGetByOrders", new
                {
Orders = Orders
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
