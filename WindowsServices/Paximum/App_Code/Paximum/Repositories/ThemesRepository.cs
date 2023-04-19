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
    public class ThemesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public ThemesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Themes Themes)
    {
        try
        {
            return connection.Insert(Themes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Themes Themes)
    {
        try
        {
       return  connection.Update(Themes);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Themes Themes)
        {
            try
            {
            return  connection.Delete<Themes>(Themes);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Themes> GetAll(){
            try
            {
                return connection.Query<Themes>("ThemesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Themes>("ThemesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Themes>("ThemesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Themes>("ThemesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Themes>("ThemesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Themes GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Themes>("ThemesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Themes>("ThemesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Themes>("ThemesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetByName(string Name){
            try
            {
                return connection.Query<Themes>("ThemesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<Themes>("ThemesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Themes> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Themes>("ThemesGetCreatedDateBetween", new
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
