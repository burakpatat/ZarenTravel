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
    public class TextCategoriesRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public TextCategoriesRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(TextCategories TextCategories)
    {
        try
        {
            return connection.Insert(TextCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(TextCategories TextCategories)
    {
        try
        {
       return  connection.Update(TextCategories);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(TextCategories TextCategories)
        {
            try
            {
            return  connection.Delete<TextCategories>(TextCategories);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<TextCategories> GetAll(){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByApiId(int ApiId){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByCode(string Code){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByCode", new
                {
Code = Code
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public TextCategories GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<TextCategories>("TextCategoriesGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByName(string Name){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByName", new
                {
Name = Name
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetByPresentationId(int PresentationId){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetByPresentationId", new
                {
PresentationId = PresentationId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetBySystemId(string SystemId){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<TextCategories> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<TextCategories>("TextCategoriesGetCreatedDateBetween", new
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
