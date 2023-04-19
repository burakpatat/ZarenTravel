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
    public class PresentationsRepository : IDisposable
    {
        private SqlConnection connection;
        private readonly string strConnString;
        public PresentationsRepository()
        {
            strConnString = ConfigurationManager.ConnectionStrings[0].ConnectionString;
            connection = new SqlConnection(strConnString);
        }
  public long Insert(Presentations Presentations)
    {
        try
        {
            return connection.Insert(Presentations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
  public bool Update(Presentations Presentations)
    {
        try
        {
       return  connection.Update(Presentations);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
        public bool Delete(Presentations Presentations)
        {
            try
            {
            return  connection.Delete<Presentations>(Presentations);
            }
            catch (Exception)
            {
                return false;
            }
        }
public List<Presentations> GetAll(){
            try
            {
                return connection.Query<Presentations>("PresentationsGetAll", commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetByAgencyId(int AgencyId){
            try
            {
                return connection.Query<Presentations>("PresentationsGetByAgencyId", new
                {
AgencyId = AgencyId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetByApiId(int ApiId){
            try
            {
                return connection.Query<Presentations>("PresentationsGetByApiId", new
                {
ApiId = ApiId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetByCreatedBy(int CreatedBy){
            try
            {
                return connection.Query<Presentations>("PresentationsGetByCreatedBy", new
                {
CreatedBy = CreatedBy
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetByCreatedDate(DateTime CreatedDate){
            try
            {
                return connection.Query<Presentations>("PresentationsGetByCreatedDate", new
                {
CreatedDate = CreatedDate
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public Presentations GetByID(int Id){
            try
            {
                return connection.QueryFirstOrDefault<Presentations>("PresentationsGetByID", new
                {
Id = Id
                }, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetByLanguageId(int LanguageId){
            try
            {
                return connection.Query<Presentations>("PresentationsGetByLanguageId", new
                {
LanguageId = LanguageId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetByMicroSiteId(int MicroSiteId){
            try
            {
                return connection.Query<Presentations>("PresentationsGetByMicroSiteId", new
                {
MicroSiteId = MicroSiteId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetBySystemId(int SystemId){
            try
            {
                return connection.Query<Presentations>("PresentationsGetBySystemId", new
                {
SystemId = SystemId
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetByText(string Text){
            try
            {
                return connection.Query<Presentations>("PresentationsGetByText", new
                {
Text = Text
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetByTextType(int TextType){
            try
            {
                return connection.Query<Presentations>("PresentationsGetByTextType", new
                {
TextType = TextType
                }, commandType: CommandType.StoredProcedure).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
public List<Presentations> GetCreatedDateBetween(DateTime CreatedDateStart,DateTime CreatedDateEnd){
            try
            {
                return connection.Query<Presentations>("PresentationsGetCreatedDateBetween", new
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
