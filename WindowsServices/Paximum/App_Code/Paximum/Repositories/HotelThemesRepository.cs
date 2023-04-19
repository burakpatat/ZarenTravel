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
    public class HotelThemesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public HotelThemesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(HotelThemes HotelThemes)
    {
        try
        {
            return connection.Insert(HotelThemes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(HotelThemes HotelThemes)
    {
        try
        {
       return  connection.Update(HotelThemes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(HotelThemes HotelThemes)
        {
            try
            {
            return  connection.Delete<HotelThemes>(HotelThemes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<HotelThemes> GetAll(){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetByApiId(int ApiId){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetByHotelId(int HotelId){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetByHotelId", new
                {
HotelId = HotelId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public HotelThemes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<HotelThemes>("HotelThemesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetByThemesId(int ThemesId){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetByThemesId", new
                {
ThemesId = ThemesId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<HotelThemes> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<HotelThemes>("HotelThemesGetCreatedDateBetween", new
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
