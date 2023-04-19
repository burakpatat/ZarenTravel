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
    public class SeasonTextCategoryRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public SeasonTextCategoryRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(SeasonTextCategory SeasonTextCategory)
    {
        try
        {
            return connection.Insert(SeasonTextCategory);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(SeasonTextCategory SeasonTextCategory)
    {
        try
        {
       return  connection.Update(SeasonTextCategory);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(SeasonTextCategory SeasonTextCategory)
        {
            try
            {
            return  connection.Delete<SeasonTextCategory>(SeasonTextCategory);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<SeasonTextCategory> GetAll(){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetByApiId(int ApiId){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public SeasonTextCategory GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<SeasonTextCategory>("SeasonTextCategoryGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetBySeasonId(int SeasonId){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetBySeasonId", new
                {
SeasonId = SeasonId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetByTextCategoryId(int TextCategoryId){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetByTextCategoryId", new
                {
TextCategoryId = TextCategoryId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<SeasonTextCategory> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<SeasonTextCategory>("SeasonTextCategoryGetCreatedDateBetween", new
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
